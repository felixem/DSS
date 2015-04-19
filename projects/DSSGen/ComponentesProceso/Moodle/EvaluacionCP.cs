using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using ComponentesProceso.Moodle.Commands;

namespace ComponentesProceso.Moodle
{
    public class EvaluacionCP:BasicCP
    {
        //Constructor
        public EvaluacionCP() : base() { }

        //Constructor con sesión
        public EvaluacionCP(ISession sesion) : base(sesion) { }

        public int CrearEvaluacion(string p_nombre, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_abierta, int p_anyo_academico)
        {
            int resultado;

            try
            {
                SessionInitializeTransaction();

                //Creo el evaluacion
                EvaluacionCAD cad = new EvaluacionCAD(session);
                EvaluacionCEN cen = new EvaluacionCEN(cad);
                resultado = cen.New_(p_nombre, p_fecha_inicio, p_fecha_fin, p_abierta, p_anyo_academico);

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
        public void ModificarEvaluacion(int id,string p_nombre, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_abierta)
        {
              try
            {
                SessionInitializeTransaction();

                //Creo el evaluacion
                EvaluacionCAD cad = new EvaluacionCAD(session);
                EvaluacionCEN cen = new EvaluacionCEN(cad);
                cen.Modify(id,p_nombre,p_fecha_inicio,p_fecha_fin,p_abierta);

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
        }
        //Devolver el resultado de una consulta individual sobre una evaluacion
        public EvaluacionEN DameEvaluacion(IDameEvaluacion consulta)
        {
            EvaluacionEN en = null;
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
        //Devolver el resultado de la consulta especificada devolviendo la cantidad de Evaluaciones que satisfacen la consulta
        public System.Collections.Generic.IList<EvaluacionEN> DameTodosTotal(IDameTodosEvaluacion consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<EvaluacionEN> lista = null;
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
        //Borrar evaluación a partir de su código de Evaluacion
        public void BorrarEvaluacion(int cod)
        {
            try
            {
                SessionInitializeTransaction();

                EvaluacionCAD cad = new EvaluacionCAD(session);
                EvaluacionCEN cen = new EvaluacionCEN(cad);
                //Ejecutar la modificación
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
        //Devolver el resultado de la consulta especificada devolviendo la cantidad de Evaluaciones que satisfacen la consulta
        public System.Collections.Generic.IList<EvaluacionEN> DameTodosPorAnyo(IDameTodosEvaluacion consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<EvaluacionEN> lista = null;
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
    }
}
