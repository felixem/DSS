using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un dropdownlist una lista asignaturas-anyo
    public class BinderListaAsignaturaAnyoDropDownList : IBinderListaAsignaturaAnyo
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaAsignaturaAnyoDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void Vincular(IList<AsignaturaAnyoEN> lista)
        {
            //Vincular con el dropdownlist
            foreach (AsignaturaAnyoEN x in lista)
            {
                drop.Items.Add(new ListItem(x.Asignatura.Nombre.ToString() + "(" + x.Anyo.Anyo.ToString() + ")",
                x.Id.ToString()));
            }
        }
    }
}
