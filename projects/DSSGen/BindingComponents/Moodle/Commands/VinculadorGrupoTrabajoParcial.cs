using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class VinculadorGrupoTrabajoParcial : IVinculadorGrupoTrabajo
    {
        //Variables privadas
        private TextBox TextBox_CodGrupo;
        private TextBox TextBox_NomGrupo;
        private TextBox TextBox_Asignatura;

        
        //Crear el vinculador a partir de sus textboxes
        public VinculadorGrupoTrabajoParcial(TextBox TextBox_CodGrupo,
            TextBox TextBox_NomGrupo, TextBox TextBox_Asignatura)
        {
            this.TextBox_CodGrupo = TextBox_CodGrupo;
            this.TextBox_NomGrupo = TextBox_NomGrupo;
            this.TextBox_Asignatura = TextBox_Asignatura;
        }

        //Vincular el grupo de trabajo
        public void Vincular(GrupoTrabajoEN grupo)
        {
            //Vincular con los textboxes
            TextBox_CodGrupo.Text = grupo.Cod_grupo;
            TextBox_NomGrupo.Text = grupo.Nombre;
            string anyo = grupo.Asignatura.Anyo.Anyo;
            TextBox_Asignatura.Text = grupo.Asignatura.Asignatura.Nombre.ToString() + "(" + anyo + ")";
        }
    }
}
