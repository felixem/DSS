using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderProfesorCompleto : IBinderProfesor
    {
        //Variables privadas
        private TextBox TextBox_NomProf;
        private TextBox TextBox_ApellProf;
        private DropDownList ddl_ano;
        private DropDownList ddl_mes;
        private DropDownList ddl_dia;
        private TextBox TextBox_DNIProf;
        private TextBox TextBox_EmailProf;
        private TextBox TextBox_CodProf;

        //Crear el vinculador a partir de sus textboxes
        public BinderProfesorCompleto(TextBox TextBox_NomProf,
            TextBox TextBox_ApellProf, DropDownList Ano, DropDownList Mes, DropDownList Dia, TextBox TextBox_DNIProf,
            TextBox TextBox_EmailProf, TextBox TextBox_CodProf)
        {
            this.TextBox_NomProf = TextBox_NomProf;
            this.TextBox_ApellProf = TextBox_ApellProf;
            this.ddl_ano = Ano;
            this.ddl_mes = Mes;
            this.ddl_dia = Dia;
            this.TextBox_DNIProf = TextBox_DNIProf;
            this.TextBox_EmailProf = TextBox_EmailProf;
            this.TextBox_CodProf = TextBox_CodProf;
        }

        //Vincular el profesor
        public void Vincular(ProfesorEN profesor)
        {
            //Vincular con los textboxes
            TextBox_NomProf.Text = profesor.Nombre;
            TextBox_ApellProf.Text = profesor.Apellidos;
            ddl_ano.SelectedValue = profesor.Fecha_nacimiento.Value.Year.ToString();
            ddl_mes.SelectedValue = profesor.Fecha_nacimiento.Value.Month.ToString();
            ddl_dia.SelectedValue = profesor.Fecha_nacimiento.Value.Day.ToString();
            TextBox_DNIProf.Text = profesor.Dni;
            TextBox_EmailProf.Text = profesor.Email;
            TextBox_CodProf.Text = profesor.Cod_profesor.ToString();
        }
    }
}
