using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un dropdownlist una lista de profesores
    public class BinderListaProfesorDropDownList : IBinderListaProfesor
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaProfesorDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void Vincular(IList<ProfesorEN> lista)
        {
            //Vincular con el dropdownlist
            foreach (ProfesorEN x in lista)
            {
                drop.Items.Add(new ListItem(x.Nombre + " " + x.Apellidos, x.Email.ToString()));
            }
        }
    }
}
