using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase para volcar sobre un grid una lista de años académicos
    public class BinderListaAnyoAcademicoGrid : IBinderListaAnyoAcademico
    {
        //Variables
        private GridView grid;

        //Constructor
        public BinderListaAnyoAcademicoGrid(GridView grid)
        {
            this.grid = grid;
        }

        //Vincular la lista
        public void Vincular(IList<AnyoAcademicoEN> lista)
        {
            //Vincular con el grid view
            grid.DataSource = lista;
            grid.DataBind();
        }
    }
}
