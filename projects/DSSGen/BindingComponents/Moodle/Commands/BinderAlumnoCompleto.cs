using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderAlumnoCompleto : IBinderAlumno
    {
        //Variables privadas
        private TextBox TextBox_NomAlu;
        private TextBox TextBox_ApellAlu;
        private DropDownList ddl_ano;
        private DropDownList ddl_mes;
        private DropDownList ddl_dia;
        private TextBox TextBox_DNIAlu;
        private TextBox TextBox_EmailAlu;
        private TextBox TextBox_CodAlu;
        private CheckBox CheckBox_Baneado;
        private TextBox TextBox_CodExpediente;

        //Crear el vinculador a partir de sus textboxes
        public BinderAlumnoCompleto(TextBox TextBox_NomAlu,
            TextBox TextBox_ApellAlu, DropDownList Ano, DropDownList Mes, DropDownList Dia, TextBox TextBox_DNIAlu,
            TextBox TextBox_EmailAlu, TextBox TextBox_CodAlu, CheckBox CheckBox_Baneado,
            TextBox TextBox_CodExpediente)
        {
            this.TextBox_NomAlu = TextBox_NomAlu;
            this.TextBox_ApellAlu = TextBox_ApellAlu;
            this.ddl_ano = Ano;
            this.ddl_mes = Mes;
            this.ddl_dia = Dia;
            this.TextBox_DNIAlu = TextBox_DNIAlu;
            this.TextBox_EmailAlu = TextBox_EmailAlu;
            this.TextBox_CodAlu = TextBox_CodAlu;
            this.CheckBox_Baneado = CheckBox_Baneado;
            this.TextBox_CodExpediente = TextBox_CodExpediente;
        }

        //Vincular el alumno
        public void Vincular(AlumnoEN alumno)
        {
            //Vincular con los textboxes
            TextBox_NomAlu.Text = alumno.Nombre;
            TextBox_ApellAlu.Text = alumno.Apellidos;
            ddl_ano.SelectedValue = alumno.Fecha_nacimiento.Value.Year.ToString();
            ddl_mes.SelectedValue = alumno.Fecha_nacimiento.Value.Month.ToString();
            ddl_dia.SelectedValue = alumno.Fecha_nacimiento.Value.Day.ToString();
            TextBox_DNIAlu.Text = alumno.Dni;
            TextBox_EmailAlu.Text = alumno.Email;
            TextBox_CodAlu.Text = alumno.Cod_alumno.ToString();
            CheckBox_Baneado.Checked = alumno.Baneado;
            TextBox_CodExpediente.Text = alumno.Expediente.Cod_expediente;
        }
    }
}
