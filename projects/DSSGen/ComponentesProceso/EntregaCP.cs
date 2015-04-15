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
    }
}
