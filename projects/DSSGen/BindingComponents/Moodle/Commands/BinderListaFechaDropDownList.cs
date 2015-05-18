using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;
using System.Collections;
using WebUtilities;


namespace BindingComponents.Moodle.Commands
{
    public class BinderListaFechaDropDownList : IBinderListaFecha
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaFechaDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void VincularAnyos(ArrayList lista)
        {
            //Vincular con el dropdownlist
            foreach (int x in lista)
            {
                drop.Items.Add(new ListItem(x.ToString()));
            }
            drop.SelectedValue = DateTime.Now.Year.ToString();
        }
        //Vincular la lista
        public void Vincular(ArrayList lista)
        {
            //Vincular con el dropdownlist
            foreach (int x in lista)
            {
                drop.Items.Add(new ListItem(x.ToString()));
            }
            drop.SelectedValue = DateTime.Now.Day.ToString();
        }
        public void VincularMes(ArrayList lista)
        {
            Mes mes;
            //Vincular con el dropdownlist
            foreach (int x in lista)
            {
                mes = (Mes)x;
                drop.Items.Add(new ListItem(mes.ToString(),x.ToString()));
            }

            drop.SelectedIndex = DateTime.Now.Month-1;
        }

    }
}
