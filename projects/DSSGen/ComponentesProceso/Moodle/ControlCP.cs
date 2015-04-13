using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    public class ControlCP : BasicCP
    {
        //Constructor
        public ControlCP() : base() { }

        //Constructor con sesión
        public ControlCP(ISession sesion) : base(sesion) { }

        //Registra el control en la BD y devuelve su resultado
        public int CrearControl(string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima, float p_penalizacion_fallo, int p_sistema_evaluacion)
        {
            int resultado;

            try
            {
                SessionInitializeTransaction();

                //Creo el control
                ControlCAD cad = new ControlCAD(session);
                ControlCEN cen = new ControlCEN(cad);
                resultado = cen.New_(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo, p_sistema_evaluacion);

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
    
        //Modifica el control en la BD
        public void ModificarControl(int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura,
            Nullable<DateTime> p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima,
            float p_penalizacion_fallo)
        {
            try
            {
                SessionInitializeTransaction();

                ControlCAD cad = new ControlCAD(session);
                ControlCEN cen = new ControlCEN(cad);
                //Ejecutar la modificación
                cen.Modify(p_oid, p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo);

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

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de Controles que satisfacen la consulta
        public System.Collections.Generic.IList<ControlEN> DameTodosTotal(IDameTodosControl consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<ControlEN> lista = null;
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

        //Devolver el resultado de una consulta individual sobre un Control
        public ControlEN DameControl(IDameControl consulta)
        {
            ControlEN en = null;
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

        //Borrar Control a partir de su código de Control
        public void BorrarControl(int cod)
        {
            try
            {
                SessionInitializeTransaction();

                ControlCAD cad = new ControlCAD(session);
                ControlCEN cen = new ControlCEN(cad);
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
    }
}