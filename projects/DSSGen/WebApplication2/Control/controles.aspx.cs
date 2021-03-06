﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;


namespace DSSGenNHibernate.Control
{
    public partial class controles : BasicPage
    {
        //Fachada utilizada en la página
        FachadaControl fachada;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaControl();
            if (!IsPostBack)
            {
                this.ObtenerControlesPaginados(1);
            }
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerControlesPaginados(1);
        }

        //Manejador para obtener los profesores paginados
        private void ObtenerControlesPaginados(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de profesores paginada
            fachada.VincularDameTodos(GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

            int recordCount = (int)numObjetos;
            this.ListarPaginas(recordCount, pageIndex);
        }

        //Manejador para el cambio de página
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.ObtenerControlesPaginados(pageIndex);
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

        //Manejador para la creación de un nuevo control
        protected void Button_Crear_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(true);
            link.Redirect(Response, link.CrearControl());
        }

        //Manejador del evento para modificar un control
        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int Id = Int32.Parse(grdrow.Cells[0].Text);

            Linker link = new Linker(true);
            link.Redirect(Response, link.ModificarControl(Id));
        }

        //Manejador del evento para eliminar un control
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int Id = Int32.Parse(grdrow.Cells[0].Text);

            //Eliminar control
            fachada.BorrarControl(Id);
            Notification.Current.NotifyLastNotification(Response);

            //Obtener de nuevo la lista de bolsas
            this.ObtenerControlesPaginados(1);
        }
    }
}