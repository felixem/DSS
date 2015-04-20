using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un dropdownlist una lista de sistemas de evaluacion
    public class BinderListaSistemaEvaluacionDropDownList : IBinderListaSistemaEvaluacion
    {
        //Variables
        private DropDownList drop;

        //Constructor
        public BinderListaSistemaEvaluacionDropDownList(DropDownList drop)
        {
            this.drop = drop;
        }

        //Vincular la lista
        public void Vincular(IList<SistemaEvaluacionEN> lista)
        {
            //Vincular con el dropdownlist
            foreach (SistemaEvaluacionEN x in lista)
            {
                drop.Items.Add(new ListItem(x.Evaluacion.Nombre.ToString(), x.Id.ToString()));
            }
        }
    }
}

