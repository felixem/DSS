using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;

namespace Fachadas.Moodle
{
    public class FachadaEntrega
    {
        //Metodo que registra la entrega en BD
        public bool RegistrarEntrega(string p_nombre, string p_descripcion, 
            Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, 
            float p_puntuacion_maxima, string p_profesor, int p_evaluacion)
        {
            try
            {
                EntregaCP entrega = new EntregaCP();
                entrega.CrearEntrega(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_puntuacion_maxima, p_profesor, p_evaluacion);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
