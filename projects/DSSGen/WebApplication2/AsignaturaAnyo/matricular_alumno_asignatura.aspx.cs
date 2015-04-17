using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.GrupoTrabajo
{
    public partial class matricular_alumno_asignatura : BasicPage
    {
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAlumno fachadaAlumno;
        private int id;
        String param;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }

            fachadaAlumno = new FachadaAlumno();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();

            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
                this.ObtenerAlumnosPaginados(1);
            }
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerAlumnosPaginados(1);
        }

        //Manejador para obtener alumnos paginados
        private void ObtenerAlumnosPaginados(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de alumnos paginada
            fachadaAlumno.VincularDameTodosMatriculablesEnAsignaturaAnyo(id, GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

            int recordCount = (int)numObjetos;
            this.ListarPaginas(recordCount, pageIndex);
        }

        //Manejador para el cambio de página
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.ObtenerAlumnosPaginados(pageIndex);
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

        //Comprobar los parámetros
        private void Obtener_Parametros()
        {
            param = Request.QueryString[PageParameters.MainParameter];
            //Comprobar si no se ha recibido un parámetro
            if (param == null)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
                id = Int32.Parse(param);
        }

        //Comprobar parámetros
        private void CargarDatos()
        {
            //Recuperar los datos de la asignatura-anyo
            if (!fachadaAsignaturaAnyo.VincularAsignaturaAnyoPorIdLigero(id,TextBox_Asignatura))
            {
                //Redirigir a la página que le llamó en caso de error
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }
       
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Manejador del evento para matricular a un alumno
        protected void lnkMatricular_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int alumnoId = Int32.Parse(grdrow.Cells[0].Text);

            //Matricular alumno
            if (fachadaAsignaturaAnyo.MatricularAlumno(alumnoId, id))
                Notification.Notify(Response, "El alumno ha sido matriculado");
            else
                Notification.Notify(Response, "El alumno no ha podido ser matriculado");

            //Obtener de nuevo la lista de alumnos
            this.ObtenerAlumnosPaginados(1);
        }
    }
}