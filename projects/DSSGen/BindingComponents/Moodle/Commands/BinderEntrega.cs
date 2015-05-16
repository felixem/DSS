using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderEntrega : IBinderEntrega
    {
        //Variables privadas
        private TextBox TextBox_Nom;
        private TextBox TextBox_Desc;
        private DropDownList ddl_ano;
        private DropDownList ddl_mes;
        private DropDownList ddl_dia;
        private DropDownList ddl_anoc;
        private DropDownList ddl_mesc;
        private DropDownList ddl_diac;
        private TextBox TextBox_PuntMax;

        private TextBox TextBox_Anyo;
        private TextBox TextBox_Asignatura;
        private TextBox TextBox_Evaluacion;
        private TextBox TextBox_Profesor;
        private TextBox TextBox_CodEntrega;

        //Crear el vinculador a partir de sus textboxes
        public BinderEntrega(TextBox TextBox_Nom,
            TextBox TextBox_Desc, DropDownList Ano, DropDownList Mes, DropDownList Dia,
            DropDownList AnoC, DropDownList MesC, DropDownList DiaC,
            TextBox TextBox_PuntMax,
            TextBox TextBox_Anyo, TextBox TextBox_Asignatura, TextBox TextBox_Evaluacion, TextBox TextBox_Profesor, TextBox TextBox_CodEntrega)
        {
            this.TextBox_Nom = TextBox_Nom;
            this.TextBox_Desc = TextBox_Desc;
            ddl_ano = Ano;
            ddl_mes = Mes;
            ddl_dia = Dia;
            ddl_anoc = AnoC;
            ddl_mesc = MesC;
            ddl_diac = DiaC;
            this.TextBox_PuntMax = TextBox_PuntMax;

            this.TextBox_Anyo = TextBox_Anyo;
            this.TextBox_Asignatura = TextBox_Asignatura;
            this.TextBox_Evaluacion = TextBox_Evaluacion;
            this.TextBox_Profesor = TextBox_Profesor;
            this.TextBox_CodEntrega = TextBox_CodEntrega;
        }

        //Vincular el control
        public void Vincular(EntregaEN en)
        {
            //Vincular con los textboxes
            TextBox_Nom.Text = en.Nombre;
            TextBox_Desc.Text = en.Descripcion;
            ddl_ano.SelectedValue = en.Fecha_apertura.Value.Year.ToString();
            ddl_mes.SelectedValue = en.Fecha_apertura.Value.Month.ToString();
            ddl_dia.SelectedValue = en.Fecha_apertura.Value.Day.ToString();
            ddl_anoc.SelectedValue = en.Fecha_cierre.Value.Year.ToString();
            ddl_mesc.SelectedValue = en.Fecha_cierre.Value.Month.ToString();
            ddl_diac.SelectedValue = en.Fecha_cierre.Value.Day.ToString();
            TextBox_PuntMax.Text = en.Puntuacion_maxima.ToString();


            TextBox_Anyo.Text = en.Evaluacion.Asignatura.Anyo.Anyo.ToString();
            TextBox_Asignatura.Text = en.Evaluacion.Asignatura.Asignatura.Nombre.ToString() + "(" + TextBox_Anyo.Text + ")";
            TextBox_Evaluacion.Text = en.Evaluacion.Evaluacion.Nombre.ToString();
            TextBox_Profesor.Text = en.Profesor.Nombre;
            TextBox_CodEntrega.Text = en.Id.ToString();
        }
    }
}
