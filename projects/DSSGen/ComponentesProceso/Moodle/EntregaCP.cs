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
    public class EntregaCP : BasicCP
    {
        //Constructor
        public EntregaCP() : base() { }

        //Constructor con sesión
        public EntregaCP(ISession sesion) : base(sesion) { }

        //Registra la entrega en la BD y devuelve su resultado
        public int CrearEntrega(string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, float p_puntuacion_maxima, string p_profesor, int p_evaluacion)
        {
            int resultado;

            try
            {
                SessionInitializeTransaction();

                //Creo el control
                EntregaCAD cad = new EntregaCAD(session);
                EntregaCEN cen = new EntregaCEN(cad);
                resultado = cen.New_(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_puntuacion_maxima, p_profesor, p_evaluacion);

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

        //Borrar Entrega a partir de su código de Entrega
        public void BorrarEntrega(int cod)
        {
            try
            {
                SessionInitializeTransaction();

                EntregaCAD cad = new EntregaCAD(session);
                EntregaCEN cen = new EntregaCEN(cad);
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

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de Entrega que satisfacen la consulta
        public System.Collections.Generic.IList<EntregaEN> DameTodosTotal(IDameTodosEntrega consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<EntregaEN> lista = null;
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
        public EntregaEN DameEntrega(IDameEntrega consulta)
        {
            EntregaEN en = null;
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

        //Modifica el entrega en la BD
        public void ModificarEntrega(int p_oid, string p_nombre, string p_descripcion, 
            Nullable<DateTime> p_fecha_apertura, 
            Nullable<DateTime> p_fecha_cierre, float p_puntuacion_maxima)
        {
            try
            {
                SessionInitializeTransaction();

                EntregaCAD cad = new EntregaCAD(session);
                EntregaCEN cen = new EntregaCEN(cad);
                //Ejecutar la modificación
                cen.Modify(p_oid, p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_puntuacion_maxima);

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
