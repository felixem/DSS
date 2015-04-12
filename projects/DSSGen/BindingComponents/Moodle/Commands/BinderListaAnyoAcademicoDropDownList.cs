using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un dropdownlist una lista de años académicos
    public class BinderListaAnyoAcademicoDropDownList : IBinderListaAnyoAcademico
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaAnyoAcademicoDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void Vincular(IList<AnyoAcademicoEN> lista)
        {
            //Vincular con el dropdownlist
            foreach (AnyoAcademicoEN x in lista)
            {
                drop.Items.Add(new ListItem(x.Anyo.ToString(), x.Id.ToString()));
            }
        }
    }
}
