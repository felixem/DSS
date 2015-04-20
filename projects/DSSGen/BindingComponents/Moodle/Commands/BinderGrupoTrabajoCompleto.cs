using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderGrupoTrabajoCompleto : IBinderGrupoTrabajo
    {
        //Variables privadas
        private TextBox TextBox_CodGrupo;
        private TextBox TextBox_NomGrupo;
        private TextBox TextBox_DescGrupo;
        private TextBox TextBox_Capacidad;
        private TextBox TextBox_Anyo;
        private TextBox TextBox_Asignatura;

        //Crear el vinculador a partir de sus textboxes
        public BinderGrupoTrabajoCompleto(TextBox TextBox_CodGrupo,
            TextBox TextBox_NomGrupo, TextBox TextBox_DescGrupo, TextBox TextBox_Capacidad,
            TextBox TextBox_Anyo, TextBox TextBox_Asignatura)
        {
            this.TextBox_CodGrupo = TextBox_CodGrupo;
            this.TextBox_NomGrupo = TextBox_NomGrupo;
            this.TextBox_DescGrupo = TextBox_DescGrupo;
            this.TextBox_Capacidad = TextBox_Capacidad;
            this.TextBox_Anyo = TextBox_Anyo;
            this.TextBox_Asignatura = TextBox_Asignatura;
        }

        //Vincular el grupo de trabajo
        public void Vincular(GrupoTrabajoEN grupo)
        {
            //Vincular con los textboxes
            TextBox_CodGrupo.Text = grupo.Cod_grupo;
            TextBox_NomGrupo.Text = grupo.Nombre;
            TextBox_DescGrupo.Text = grupo.Descripcion;
            TextBox_Capacidad.Text = grupo.Capacidad.ToString();
            TextBox_Anyo.Text = grupo.Asignatura.Anyo.Anyo.ToString();
            TextBox_Asignatura.Text = grupo.Asignatura.Asignatura.Nombre.ToString() + "(" + TextBox_Anyo.Text + ")";
        }
    }
}
