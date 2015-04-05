using System;
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
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numBases = consulta.Total(session);

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

                //Crear bolsa
                BolsaPreguntasCAD bolsaCad = new BolsaPreguntasCAD(session);
                BolsaPreguntasCEN bolsaCen = new BolsaPreguntasCEN(bolsaCad);
                idBolsa = bolsaCen.New_(nombre, descripcion, fecha_creacion, fecha_modificacion, asignatura);

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

        //Método utilizado para crear una pregunta
        private void CrearPreguntas(IList<PreguntaEN> preguntas, int idBolsa)
        {
            //Crear preguntas
            PreguntaCAD preguntaCad = new PreguntaCAD(session);
            PreguntaCEN preguntaCen = new PreguntaCEN(preguntaCad);
            foreach (PreguntaEN preg in preguntas)
            {
                //Crear pregunta
                int idPreg = preguntaCen.New_(preg.Contenido, preg.Explicacion, idBolsa);
                int idRespCorrecta = -1;

                //Crear respuestas
                foreach (RespuestaEN resp in preg.Respuestas)
                {
                    RespuestaCAD resCad = new RespuestaCAD(session);
                    RespuestaCEN resCen = new RespuestaCEN(resCad);
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
    }
}
