using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un dropdownlist una lista de cursos
    public class BinderListaCursoDropDownList : IBinderListaCurso
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaCursoDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void Vincular(IList<CursoEN> lista)
        {
            //Vincular con el dropdownlist
            foreach (CursoEN x in lista)
            {
                drop.Items.Add(new ListItem(x.Nombre, x.Id.ToString()));
            }
        }
    }
}
