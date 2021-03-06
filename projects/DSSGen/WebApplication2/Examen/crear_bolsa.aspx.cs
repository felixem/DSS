﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Examen
{
    public partial class crear_bolsa : BasicPage
    {
        //Objetos utilizables
        BolsaSession bolsa;
        FachadaAsignatura fachadaAsignatura;
        FachadaBolsaPreguntas fachadaBolsa;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recuperar el estado de la bolsa
            bolsa = BolsaSession.Current;
            //Inicializar fachadas
            fachadaAsignatura = new FachadaAsignatura();
            fachadaBolsa = new FachadaBolsaPreguntas();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                this.Inicializacion();
            }
        }

        //Inicialización
        private void Inicializacion()
        {
            //Inicializar los datos de los textbox
            TextBox_Nombre.Text = bolsa.Nombre;
            TextBox_Descripcion.Text = bolsa.Descripcion;
            this.ObtenerPreguntasPaginadas(1);
            this.ObtenerAsignaturas();
            this.SeleccionarAsignatura();
        }

        //Obtener las asignaturas
        protected void ObtenerAsignaturas()
        {
            fachadaAsignatura.VincularDameTodos(DropDownList_Asignaturas);
        }

        //Establecer asignatura elegida
        protected void SeleccionarAsignatura()
        {
            //Seleccionar la asignatura de la bolsa
            ListItem selectedListItem = DropDownList_Asignaturas.Items.FindByValue(bolsa.Asignatura.ToString());
            if (selectedListItem != null)
            {
                selectedListItem.Selected = true;
            };
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerPreguntasPaginadas(1);
        }

        //Manejador para obtener la lista provisional de preguntas de la bolsa con el índice requerido
        private void ObtenerPreguntasPaginadas(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de preguntas provisional
            bolsa.VincularDamePreguntas(GridViewPreguntas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

            int recordCount = (int)numObjetos;
            this.ListarPaginas(recordCount, pageIndex);
        }

        //Manejador para el cambio de página
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.ObtenerPreguntasPaginadas(pageIndex);
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

        //Salvar el estado actual del menú de propiedades de la bolsa
        private void SalvarMenu()
        {
            bolsa.Nombre = TextBox_Nombre.Text;
            bolsa.Descripcion = TextBox_Descripcion.Text;
            bolsa.Asignatura = Int32.Parse(DropDownList_Asignaturas.SelectedItem.Value);
        }

        //Manejador del evento para modificar una pregunta
        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int id = Int32.Parse(grdrow.Cells[0].Text);
            SalvarMenu();
            Linker link = new Linker(true);
            link.Redirect(Response,link.ModificarPregunta(id));
        }

        //Manejador del evento para eliminar una pregunta
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int id = Int32.Parse(grdrow.Cells[0].Text);
            SalvarMenu();

            //Eliminar la pregunta
            bolsa.RemovePregunta(id);
            Notification.Current.NotifyLastNotification(Response);

            //Actualizar la lista de preguntas
            this.ObtenerPreguntasPaginadas(1);
        }

        //Manejador para añadir pregunta a la lista
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            SalvarMenu();
            Linker link = new Linker(true);
            link.Redirect(Response,link.CrearPregunta());
        }

        //Manejador para limpiar una bolsa de preguntas
        protected void Button_Limpiar_Click(object sender, EventArgs e)
        {
            bolsa.Clear();
            this.Inicializacion();
        }

        //Manejador para cancelar la creación de una bolsa de preguntas
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            bolsa.Clear();
            Linker link = new Linker(false);
            link.Redirect(Response,link.PreviousPage());
        }

        //Manejador para hacer persistente la creación de una bolsa de preguntas
        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            SalvarMenu();

            //Crear la asignatura
            if (fachadaBolsa.CrearBolsa(bolsa))
            {
                bolsa.Clear();
                Notification.Current.NotifyLastNotification(Response);
                this.Inicializacion();
            }
            else
                Notification.Current.NotifyLastNotification(Response);
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Asignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}