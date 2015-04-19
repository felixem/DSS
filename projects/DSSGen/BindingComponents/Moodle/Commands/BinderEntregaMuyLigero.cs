using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderEntregaMuyLigero : IBinderEntrega
    {
        //Variables privadas
        private TextBox TextBox_Entrega;

        //Crear el vinculador a partir de sus textboxes
        public BinderEntregaMuyLigero(TextBox TextBox_Entrega)
        {
            this.TextBox_Entrega = TextBox_Entrega;
        }

        //Vincular la entrega
        public void Vincular(EntregaEN entrega)
        {
            //Vincular con los textboxes
            TextBox_Entrega.Text = entrega.Nombre;
        }
    }
}
