using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using ComponentesProceso.Moodle.Commands;

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

                //Creo el alumno    
                ControlCEN controlCen = new ControlCEN();
                resultado = controlCen.New_(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo, p_sistema_evaluacion);

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