using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    public class BinderSistemaEvaluacion : IBinderSistemaEvaluacion
    {
        private TextBox puntuacion;

        //Crear el vinculador a partir de sus textboxes
        public BinderSistemaEvaluacion(TextBox puntuacion)
        {
            this.puntuacion = puntuacion;
        }
        public void Vincular(SistemaEvaluacionEN en)
        {
            puntuacion.Text = en.Puntuacion_maxima.ToString();
        }
    }
}
