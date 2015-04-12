using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un grid una lista de profesores
    public class BinderListaProfesorGrid : IBinderListaProfesor
    {
        //Variables
        private GridView grid;

        //Constructor
        public BinderListaProfesorGrid(GridView grid)
        {
            this.grid = grid;
        }

        //Vincular la lista
        public void Vincular(IList<ProfesorEN> lista)
        {
            //Vincular con el grid view
            grid.DataSource = lista;
            grid.DataBind();
        }
    }
}
