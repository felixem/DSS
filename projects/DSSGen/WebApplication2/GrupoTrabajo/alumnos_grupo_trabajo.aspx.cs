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
    public partial class alumnos_grupo_trabajo : BasicPage
    {
        FachadaGrupoTrabajo fachadaGrupo;
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

            fachadaGrupo = new FachadaGrupoTrabajo();
            fachadaAlumno = new FachadaAlumno();

            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
                //Cargar los alumnos inscritos
                this.ObtenerAlumnosPaginados(1);
            }
        }

        //Comprobar si se plantea operación de modificación
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
            //Recuperar los datos del grupo de trabajo
            if (!fachadaGrupo.VincularGrupoTrabajoPorIdLigero(id, TextBox_NomGrupo,
                    TextBox_Capacidad))
            {
                //Redirigir a la página que le llamó en caso de error
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerAlumnosPaginados(1);
        }

        //Manejador para obtener los alumnos paginados
        private void ObtenerAlumnosPaginados(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de alumnos paginada
            fachadaAlumno.VincularDameTodosPorGrupo(id, GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

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

        //Manejador para añadir alumnos a un grupo de trabajo
        protected void Button_Crear_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(true);
            link.Redirect(Response, link.AnyadirAlumnosGrupoTrabajo(id));
        }

        //Manejador del evento para expulsar a un alumno de un grupo de trabajo
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string emailAlumno = grdrow.Cells[0].Text;

            //Desvincular un alumno de un grupo de trabajo
            if (fachadaGrupo.DesvincularAlumno(id, emailAlumno))
                Notification.Notify(Response, "El alumno ha sido desvinculado del grupo");
            else
                Notification.Notify(Response, "El alumno no ha podido ser desvinculado del grupo");

            //Obtener los datos
            this.CargarDatos();
            this.ObtenerAlumnosPaginados(1);
        }

        //Volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}