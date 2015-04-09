using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.GrupoTrabajo
{
    public partial class grupos_trabajo : System.Web.UI.Page
    {
        //Fachada utilizada en la página
        FachadaGrupoTrabajo fachada;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaGrupoTrabajo();
            if (!IsPostBack)
            {
                this.ObtenerGruposTrabajoPaginados(1);
            }
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerGruposTrabajoPaginados(1);
        }

        //Manejador para obtener los grupos de trabajo paginados
        private void ObtenerGruposTrabajoPaginados(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de grupos de trabajo paginados
            fachada.VincularDameTodos(GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

            int recordCount = (int)numObjetos;
            this.ListarPaginas(recordCount, pageIndex);
        }

        //Manejador para el cambio de página
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.ObtenerGruposTrabajoPaginados(pageIndex);
        }

        //Listar las páginas para navegar sobre ellas
        private void ListarPaginas(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                pages.Add(new ListItem("First", "1", currentPage > 1));
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        //Manejador para la creación de un nuevo grupo de trabajo
        protected void Button_Crear_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(true);
            link.Redirect(Response, link.CrearGrupoTrabajo());
        }

        //Manejador del evento para modificar un grupo de trabajo
        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            throw new Exception("Not implemented yet");
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int grupoId = Int32.Parse(grdrow.Cells[0].Text);

            Linker link = new Linker(true);
            link.Redirect(Response, link.ModificarGrupoTrabajo(grupoId));
        }

        //Manejador del evento para eliminar un grupo de trabajo
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int grupoId = Int32.Parse(grdrow.Cells[0].Text);

            //Eliminar grupo de trabajo
            if (!fachada.BorrarGrupoTrabajo(grupoId))
                Response.Write("<script>window.alert('El grupo de trabajo no ha podido ser borrado');</script>");

            //Obtener de nuevo la lista de bolsas
            this.ObtenerGruposTrabajoPaginados(1);
        }
    }
}