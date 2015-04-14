﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.AsignaturaAnyo
{
    public partial class asignaturas_impartidas : System.Web.UI.Page
    {
        //Fachada utilizada en la página
        FachadaAsignaturaAnyo fachada;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaAsignaturaAnyo();
            if (!IsPostBack)
            {
                this.ObtenerAsignaturasPaginadas(1);
            }
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerAsignaturasPaginadas(1);
        }

        //Manejador para obtener las asignaturas paginadas
        private void ObtenerAsignaturasPaginadas(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de asignaturas impartidas paginada
            fachada.VincularDameTodos(GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

            int recordCount = (int)numObjetos;
            this.ListarPaginas(recordCount, pageIndex);
        }

        //Manejador para el cambio de página
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.ObtenerAsignaturasPaginadas(pageIndex);
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

        //Manejador para la creación de una nueva asignatura-anyo
        protected void Button_Crear_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(true);
            link.Redirect(Response, link.CrearAsignaturaAnyo());
        }

        //Manejador del evento para listar los alumnos de una asignatura-anyo
        protected void lnkAlumnos_Click(object sender, EventArgs e)
        {
            throw new Exception("not implemented yet");
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int asignaturaId = Int32.Parse(grdrow.Cells[0].Text);

            Linker link = new Linker(true);
            link.Redirect(Response, link.ModificarAsignatura(asignaturaId));
        }

        //Manejador del evento para listar los grupos de trabajo de una asignatura-anyo
        protected void lnkGrupos_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int asignaturaId = Int32.Parse(grdrow.Cells[0].Text);

            Linker link = new Linker(true);
            link.Redirect(Response, link.ListarGruposTrabajoAsignaturaAnyo(asignaturaId));
        }

        //Manejador del evento para eliminar una asignatura-anyo
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int asignaturaAnyoId = Int32.Parse(grdrow.Cells[0].Text);

            //Eliminar asignatura
            if (fachada.BorrarAsignaturaAnyo(asignaturaAnyoId))
                Notification.Notify(Response, "La asignatura ha sido desvinculada del curso académico");
            else
                Notification.Notify(Response, "La asignatura no ha podido ser desvinculada del curso académico");

            //Obtener de nuevo la lista de bolsas
            this.ObtenerAsignaturasPaginadas(1);
        }
    }
}