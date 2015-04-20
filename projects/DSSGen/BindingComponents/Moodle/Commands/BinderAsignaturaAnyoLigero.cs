using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderAsignaturaAnyoLigero : IBinderAsignaturaAnyo
    {
        //Variables privadas
        private TextBox TextBox_Asignatura;

        //Crear el vinculador a partir de sus textboxes
        public BinderAsignaturaAnyoLigero(TextBox TextBox_Asignatura)
        {
            this.TextBox_Asignatura = TextBox_Asignatura;
        }

        //Vincular la asignatura
        public void Vincular(AsignaturaAnyoEN asignatura)
        {
            //Vincular con los textboxes
            TextBox_Asignatura.Text = asignatura.Asignatura.Nombre + "(" + asignatura.Anyo.Anyo + ")";
        }
    }
}
