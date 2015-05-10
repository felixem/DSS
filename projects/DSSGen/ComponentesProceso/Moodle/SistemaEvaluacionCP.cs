using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso de curso
    public class SistemaEvaluacionCP : BasicCP
    {
        //Constructor
        public SistemaEvaluacionCP() : base() { }

        //Constructor con sesión
        public SistemaEvaluacionCP(ISession sesion) : base(sesion) { }

        //Crear sistema de evaluación
        public int CrearSistema(float puntuacion, int asignaturaanyo, int evaluacion)
        {
            int resultado;

            try
            {
                SessionInitializeTransaction();

                //Comprobar si existe la asignatura
                AsignaturaAnyoCAD asigAnyoCad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN asigAnyoCen = new AsignaturaAnyoCEN(asigAnyoCad);
                if (asigAnyoCen.ReadOID(asignaturaanyo) == null)
                    throw new Exception("La asignatura no existe");

                //Comprobar si existe la evaluación
                EvaluacionCAD evalCad = new EvaluacionCAD(session);
                EvaluacionCEN evalCen = new EvaluacionCEN(evalCad);
                if (evalCen.ReadOID(evaluacion) == null)
                    throw new Exception("La evaluación no existe");

                //Comprobar si ya existía una relación entre la asignaturaanyo y la evaluación
                SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
                SistemaEvaluacionCEN cen = new SistemaEvaluacionCEN(cad);
                if (cen.ReadRelation(asignaturaanyo, evaluacion) != null)
                    throw new Exception("La vinculación entre la asignatura y la evaluación ya existe");

                //Crear el sistema de evaluación
                resultado = cen.New_(puntuacion, asignaturaanyo, evaluacion);

                SessionCommit();
            }
            catch (Exception e)
            {
                SessionRollBack();
                throw e;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
            return resultado;
        }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de sistemas evaluacion que satisfacen la consulta
        public System.Collections.Generic.IList<SistemaEvaluacionEN> DameTodosTotal(IDameTodosSistemaEvaluacion consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<SistemaEvaluacionEN> lista = null;
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
        //Devolver el resultado de una consulta individual sobre un sistema de evaluacion
        public SistemaEvaluacionEN DameSistema(IDameSistemaEvaluacion consulta)
        {
            SistemaEvaluacionEN en = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                en = consulta.Execute(session);

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

            return en;
        }

        //Modificar sistema de evaluación
        public void ModificarSistemaEvaluacion(int p_oid, float p_maxima)
        {
            try
            {
                SessionInitializeTransaction();

                SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
                SistemaEvaluacionCEN cen = new SistemaEvaluacionCEN(cad);

                //Comprobar la existencia del sistema
                if (cen.ReadOID(p_oid) == null)
                    throw new Exception("El sistema de evaluación no existe");

                //Ejecutar la modificación
                cen.Modify(p_oid, p_maxima);

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
        }
        //Borrar el sistema de evaluación
        public void BorrarSistemaEvaluacion(int cod)
        {
            try
            {
                SessionInitializeTransaction();

                SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
                SistemaEvaluacionCEN cen = new SistemaEvaluacionCEN(cad);

                //Comprobar la existencia del sistema
                if (cen.ReadOID(cod) == null)
                    throw new Exception("El sistema de evaluación no existe");

                //Ejecutar el borrado
                cen.Destroy(cod);

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
        }
    }
}
