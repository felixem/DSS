using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un dropdownlist una lista de evaluaciones
    public class BinderListaEvaluacionDropDownList : IBinderListaEvaluacion
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaEvaluacionDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void Vincular(IList<EvaluacionEN> lista)
        {
            //Vincular con el dropdownlist
            foreach (EvaluacionEN x in lista)
            {
                drop.Items.Add(new ListItem(x.Id.ToString()));
            }
        }
    }
}
