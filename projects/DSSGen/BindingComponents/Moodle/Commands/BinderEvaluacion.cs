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
       private TextBox TexBox_inicio;
       private TextBox TexBox_fin;
       private CheckBox CheckBox_abierto;

       //Crear el vinculador a partir de sus textboxes
       public BinderEvaluacion(TextBox nombre, TextBox inicio, TextBox fin, CheckBox abierto) 
       {
           TextBox_nombre = nombre;
           TexBox_inicio = inicio;
           TexBox_fin = fin;
           CheckBox_abierto = abierto;
       }
       public void Vincular(EvaluacionEN en)
       {
           TextBox_nombre.Text = en.Nombre;
           TexBox_inicio.Text = en.Fecha_inicio.ToString();
           TexBox_fin.Text = en.Fecha_fin.ToString();
           CheckBox_abierto.Checked = en.Abierta;
       }
    }
}
