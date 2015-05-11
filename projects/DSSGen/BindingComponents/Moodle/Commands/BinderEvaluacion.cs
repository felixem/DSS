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
       private CheckBox CheckBox_abierto;

       //Crear el vinculador a partir de sus textboxes
       public BinderEvaluacion(TextBox nombre, CheckBox abierto) 
       {
           TextBox_nombre = nombre;
           CheckBox_abierto = abierto;
       }
       public void Vincular(EvaluacionEN en)
       {
           TextBox_nombre.Text = en.Nombre;
           CheckBox_abierto.Checked = en.Abierta;
       }
    }
}
