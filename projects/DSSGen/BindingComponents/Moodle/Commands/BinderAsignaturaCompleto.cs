using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderAsignaturaCompleto : IBinderAsignatura
    {
        //Variables privadas
        private TextBox TextBox_Curso;
        private TextBox TextBox_IdAsig;
        private TextBox TextBox_CodAsig;
        private TextBox TextBox_NomAsig;
        private TextBox TextBox_DescAsig;
        private CheckBox CheckBox_OptativaAsig;
        private CheckBox CheckBox_VigenteAsig;

        //Crear el vinculador a partir de sus textboxes
        public BinderAsignaturaCompleto(TextBox TextBox_Curso, TextBox TextBox_IdAsig,
            TextBox TextBox_CodAsig, TextBox TextBox_NomAsig, TextBox TextBox_DescAsig,
            CheckBox CheckBox_OptativaAsig, CheckBox CheckBox_VigenteAsig)
        {
            this.TextBox_Curso = TextBox_Curso;
            this.TextBox_IdAsig = TextBox_IdAsig;
            this.TextBox_CodAsig = TextBox_CodAsig;
            this.TextBox_NomAsig = TextBox_NomAsig;
            this.TextBox_DescAsig = TextBox_DescAsig;
            this.CheckBox_OptativaAsig = CheckBox_OptativaAsig;
            this.CheckBox_VigenteAsig = CheckBox_VigenteAsig;
        }

        //Vincular la asignatura
        public void Vincular(AsignaturaEN asignatura)
        {
            //Vincular con los textboxes
            TextBox_Curso.Text = asignatura.Curso.Nombre;
            TextBox_IdAsig.Text = asignatura.Id.ToString();
            TextBox_CodAsig.Text = asignatura.Cod_asignatura;
            TextBox_NomAsig.Text = asignatura.Nombre;
            TextBox_DescAsig.Text = asignatura.Descripcion;
            CheckBox_OptativaAsig.Checked = asignatura.Optativa;
            CheckBox_VigenteAsig.Checked = asignatura.Vigente;
        }
    }
}
