﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Excepciones;
using ComponentesProceso.Moodle.Commands;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para la base de preguntas
    public class BolsaPreguntasCP : BasicCP
    {
        //Constructor
        public BolsaPreguntasCP() : base() { }

        //Constructor con sesión
        public BolsaPreguntasCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de bolsas que satisfacen la consulta
        public System.Collections.Generic.IList<BolsaPreguntasEN> DameTodosTotal(IDameTodosBolsaPreguntas consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numElementos = consulta.Total(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return lista;
        }

        //Crear bolsa de preguntas con el conjunto de preguntas y respuestas
        public int CrearBolsa(String nombre, String descripcion, DateTime? fecha_creacion,
            DateTime? fecha_modificacion, int asignatura, IList<PreguntaEN> preguntas)
        {
            int idBolsa = -1;
            try
            {
                SessionInitializeTransaction();

                //Comprobar si existe la asignatura
                AsignaturaCAD asigCad = new AsignaturaCAD(session);
                AsignaturaCEN asigCen = new AsignaturaCEN(asigCad);
                if (asigCen.ReadOID(asignatura) == null)
                    throw new Exception("La asignatura no existe");

                //Crear bolsa
                BolsaPreguntasCAD cad = new BolsaPreguntasCAD(session);
                BolsaPreguntasCEN cen = new BolsaPreguntasCEN(cad);
                idBolsa = cen.New_(nombre, descripcion, fecha_creacion, fecha_modificacion, asignatura);

                //Crear preguntas
                this.CrearPreguntas(preguntas, idBolsa);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            return idBolsa;
        }

        //Modificar bolsa de preguntas con el conjunto de preguntas y respuestas nuevas, modificadas y borradas
        public int ModificarBolsa(int idBolsa, String nombre, String descripcion, DateTime? fecha_creacion,
            DateTime? fecha_modificacion, int asignaturaOriginal, int asignaturaNueva, IList<PreguntaEN> preguntasNuevas,
            IList<PreguntaEN> preguntasModificadas, IList<PreguntaEN> preguntasBorradas)
        {
            try
            {
                SessionInitializeTransaction();

                //Modificar valores de bolsa
                BolsaPreguntasCAD cad = new BolsaPreguntasCAD(session);
                BolsaPreguntasCEN cen = new BolsaPreguntasCEN(cad);
                BolsaPreguntasEN bolsaEn = cen.ReadOID(idBolsa);

                //Comprobar si existe la bolsa
                if (bolsaEn == null)
                    throw new Exception("La bolsa no existe");

                cen.Modify(idBolsa, nombre, descripcion, fecha_creacion, fecha_modificacion);

                //Relacionar la bolsa con la nueva asignatura y desvincularla con la anterior
                if (bolsaEn.Asignatura.Id != asignaturaOriginal)
                    throw new Exception("No se pudo desvincular la bolsa con la asignatura original");

                cen.Unrelationer_asignatura(idBolsa, asignaturaOriginal);

                AsignaturaCAD asigCad = new AsignaturaCAD(session);
                AsignaturaCEN asigCen = new AsignaturaCEN(asigCad);

                if (asigCen.ReadOID(asignaturaNueva) == null)
                    throw new Exception("No existe la asignatura");
                cen.Relationer_asignatura(idBolsa, asignaturaNueva);

                //Crear las preguntas nuevas
                this.CrearPreguntas(preguntasNuevas, idBolsa);
                //Cargar los cambios de las preguntas modificadas
                this.ModificarPreguntas(preguntasModificadas, idBolsa);
                //Borrar las preguntas eliminadas
                this.BorrarPreguntas(preguntasBorradas, idBolsa);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            return idBolsa;
        }

        //Método utilizado para crear preguntas
        private void CrearPreguntas(IList<PreguntaEN> preguntas, int idBolsa)
        {
            //Crear preguntas
            PreguntaCAD preguntaCad = new PreguntaCAD(session);
            PreguntaCEN preguntaCen = new PreguntaCEN(preguntaCad);
            RespuestaCAD resCad = new RespuestaCAD(session);
            RespuestaCEN resCen = new RespuestaCEN(resCad);

            foreach (PreguntaEN preg in preguntas)
            {
                //Crear pregunta
                int idPreg = preguntaCen.New_(preg.Contenido, preg.Explicacion, idBolsa);
                int idRespCorrecta = -1;

                //Crear respuestas
                foreach (RespuestaEN resp in preg.Respuestas)
                {
                    int idRes = resCen.New_(resp.Contenido, idPreg);
                    //Establecer el id de la respuesta correcta si lo fuese
                    if (resp.Id.Equals(preg.Respuesta_correcta.Id))
                        idRespCorrecta = idRes;
                }

                //Establecer una relación entre una pregunta y su respuesta correcta
                preguntaCen.Relationer_respuesta_correcta(idPreg, idRespCorrecta);

                //Realizar un update automático en la sesion
                session.Flush();
            }
        }

        //Método utilizado para modificar una lista de preguntas
        private void ModificarPreguntas(IList<PreguntaEN> preguntas, int idBolsa)
        {
            //Crear preguntas
            PreguntaCAD preguntaCad = new PreguntaCAD(session);
            PreguntaCEN preguntaCen = new PreguntaCEN(preguntaCad);
            RespuestaCAD resCad = new RespuestaCAD(session);
            RespuestaCEN resCen = new RespuestaCEN(resCad);

            foreach (PreguntaEN preg in preguntas)
            {
                //Modificar pregunta
                int idPreg = preg.Id;
                preguntaCen.Modify(idPreg,preg.Contenido,preg.Explicacion);

                int idRespCorrecta = preg.Respuesta_correcta.Id;
                //Relacionar con el id de la respuesta correcta
                preguntaCen.Relationer_respuesta_correcta(idPreg, idRespCorrecta);

                //Modificar respuestas
                foreach (RespuestaEN resp in preg.Respuestas)
                {
                    int idRes = resp.Id;
                    String contenido = resp.Contenido;
                    //Modificar la respuesta
                    resCen.Modify(idRes,contenido);
                }
            }
        }

        //Método utilizado para borrar una lista de preguntas
        private void BorrarPreguntas(IList<PreguntaEN> preguntas, int idBolsa)
        {
            //Borrar preguntas
            PreguntaCAD preguntaCad = new PreguntaCAD(session);
            PreguntaCEN preguntaCen = new PreguntaCEN(preguntaCad);
            foreach (PreguntaEN preg in preguntas)
            {
                //Borrar pregunta
                int idPreg = preg.Id;
                preguntaCen.Destroy(preg.Id);

                //Realizar un update automático en la sesion
                session.Flush();
            }
        }

        //Borrar bolsa de preguntas
        public void BorrarBolsa(int id)
        {
            try
            {
                SessionInitializeTransaction();

                //Crear bolsa
                BolsaPreguntasCAD bolsaCad = new BolsaPreguntasCAD(session);
                BolsaPreguntasCEN bolsaCen = new BolsaPreguntasCEN(bolsaCad);
                BolsaPreguntasEN bolsa = bolsaCen.ReadOID(id);

                //Comprobar si existe la bolsa
                if (bolsa == null)
                    throw new Exception("La bolsa no existe");

                //Borrar las preguntas
                PreguntaCAD preguntaCad = new PreguntaCAD(session);
                PreguntaCEN preguntaCen = new PreguntaCEN(preguntaCad);

                IList<int> listaPreguntas = new List<int>();
                //Anotar las ids para desvincular
                foreach (PreguntaEN pregunta in bolsa.Preguntas)
                    listaPreguntas.Add(pregunta.Id);

                //Desvincular las preguntas de la bolsa
                bolsaCen.Unrelationer_preguntas(id,listaPreguntas);
                session.Flush();

                //Borrar las preguntas
                foreach (PreguntaEN pregunta in bolsa.Preguntas)
                {
                    preguntaCen.Destroy(pregunta.Id);
                    session.Flush();
                }

                //Borrar la bolsa
                bolsaCen.Destroy(id);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
        }
    }
}
