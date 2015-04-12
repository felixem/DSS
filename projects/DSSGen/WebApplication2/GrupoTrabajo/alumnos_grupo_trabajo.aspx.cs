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
    public partial class alumnos_grupo_trabajo : System.Web.UI.Page
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
            if (!fachadaGrupo.VincularGrupoTrabajoPorIdLigero(id, TextBox_CodGrupo,
                TextBox_NomGrupo, TextBox_Asignatura))
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
            throw new Exception ("Not implemented yet");
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            /*//Vincular el grid con la lista de alumnos paginada
            fachada.VincularDameTodos(GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);*/

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

        //Manejador para añadir un alumno al grupo de trabajo
        protected void Button_Crear_Click(object sender, EventArgs e)
        {
            throw new Exception("Not implemented yet");
            Linker link = new Linker(true);
            link.Redirect(Response, link.CrearGrupoTrabajo());
        }

        //Manejador del evento para expulsar a un alumno de un grupo de trabajo
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            throw new Exception("Not implemented yet");
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int grupoId = Int32.Parse(grdrow.Cells[0].Text);

            /*//Eliminar grupo de trabajo
            if (fachada.BorrarGrupoTrabajo(grupoId))
                Notification.Notify(Response,"El grupo de trabajo ha sido borrado");
            else
                Notification.Notify(Response, "El grupo de trabajo no ha podido ser borrado");*/

            //Obtener de nuevo la lista de bolsas
            this.ObtenerAlumnosPaginados(1);
        }
    }
}