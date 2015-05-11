using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
   public class BinderEvaluacion:IBinderEvaluacion
    {
       private TextBox TextBox_nombre;
       private DropDownList ddl_ano;
       private DropDownList ddl_mes;
       private DropDownList ddl_dia;
       private DropDownList ddl_anoc;
       private DropDownList ddl_mesc;
       private DropDownList ddl_diac;
       private CheckBox CheckBox_abierto;

       //Crear el vinculador a partir de sus textboxes
       public BinderEvaluacion(TextBox nombre, DropDownList Ano, DropDownList Mes, DropDownList Dia,
            DropDownList AnoC, DropDownList MesC, DropDownList DiaC, CheckBox abierto) 
       {
           TextBox_nombre = nombre;
           ddl_ano = Ano;
           ddl_mes = Mes;
           ddl_dia = Dia;
           ddl_anoc = AnoC;
           ddl_mesc = MesC;
           ddl_diac = DiaC;
           CheckBox_abierto = abierto;
       }
       public void Vincular(EvaluacionEN en)
       {
           TextBox_nombre.Text = en.Nombre;
           CheckBox_abierto.Checked = en.Abierta;
           ddl_ano.SelectedValue = en.Fecha_inicio.Value.Year.ToString();
           ddl_mes.SelectedValue= en.Fecha_inicio.Value.Month.ToString();
           ddl_dia.SelectedValue = en.Fecha_inicio.Value.Day.ToString();
           ddl_anoc.SelectedValue = en.Fecha_fin.Value.Year.ToString();
           ddl_mesc.SelectedValue = en.Fecha_fin.Value.Month.ToString();
           ddl_diac.SelectedValue = en.Fecha_fin.Value.Day.ToString();
       }
    }
}
