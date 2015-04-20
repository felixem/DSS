using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderGrupoTrabajoParcial : IBinderGrupoTrabajo
    {
        //Variables privadas
        private TextBox TextBox_NomGrupo;
        private TextBox TextBox_Capacidad;

        
        //Crear el vinculador a partir de sus textboxes
        public BinderGrupoTrabajoParcial(TextBox TextBox_NomGrupo, TextBox TextBox_Capacidad)
        {
            this.TextBox_NomGrupo = TextBox_NomGrupo;
            this.TextBox_Capacidad = TextBox_Capacidad;
        }

        //Vincular el grupo de trabajo
        public void Vincular(GrupoTrabajoEN grupo)
        {
            //Vincular con los textboxes
            TextBox_NomGrupo.Text = grupo.Nombre + "(" + grupo.Cod_grupo + ")";
            TextBox_Capacidad.Text = "" + grupo.Alumnos.Count + "/" + grupo.Capacidad;
        }
    }
}
