using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un grid una lista
    public class BinderListaEntregaAlumnoGrid : IBinderListaEntregaAlumno
    {
        //Variables
        private GridView grid;

        //Constructor
        public BinderListaEntregaAlumnoGrid(GridView grid)
        {
            this.grid = grid;
        }

        //Vincular la lista
        public void Vincular(IList<EntregaAlumnoEN> lista)
        {
            //Vincular con el grid view
            grid.DataSource = lista;
            grid.DataBind();
        }
    }
}

