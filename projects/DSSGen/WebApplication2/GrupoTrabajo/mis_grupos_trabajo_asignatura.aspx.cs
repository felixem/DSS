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
    public partial class mis_grupos_trabajo_asignatura : BasicPage
    {
        //Fachada utilizada en la página
        FachadaGrupoTrabajo fachadaGrupo;
        FachadaAsignaturaAnyo fachadaAsignatura;
        private int asignaturaanyoId;
        private string alumno;
        String param;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }

            fachadaGrupo = new FachadaGrupoTrabajo();
            fachadaAsignatura = new FachadaAsignaturaAnyo();
            alumno = MySession.Current.Usuario.Email;
            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
                this.ObtenerGruposTrabajoPaginados(1);
            }
        }

        //Comprobar si se plantea operación de modificación
        private void Obtener_Parametros()
        {
            param = Request.QueryString[PageParameters.MainParameter];
            //Lanzar excepción no se ha recibido un parámetro
            if (param == null)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
                asignaturaanyoId = Int32.Parse(param);
        }

        //Comprobar parámetros y cargar datos
        private void CargarDatos()
        {
            //Recuperar los datos de la asignatura-anyo
            if (!fachadaAsignatura.VincularAsignaturaAnyoPorIdLigero(asignaturaanyoId, TextBox_Asignatura))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
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
            fachadaGrupo.VincularDameTodosPorAlumnoYAsignaturaAnyo(alumno, asignaturaanyoId,GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

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

        //Manejador del evento para acceder a un grupo de trabajo
        protected void lnkSalirDelGrupo_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int grupoId = Int32.Parse(grdrow.Cells[0].Text);

            //Desvincular un alumno de un grupo de trabajo
            if (fachadaGrupo.DesvincularAlumno(grupoId, alumno))
                Notification.Notify(Response, "El alumno ha sido desvinculado del grupo");
            else
                Notification.Notify(Response, "El alumno no ha podido ser desvinculado del grupo");

            this.CargarDatos();
            this.ObtenerGruposTrabajoPaginados(1);
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Botón utilizado para acceder a la página donde poder acceder a otros grupos de la signatura
        protected void Button_Otros_Grupos_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(true);
            link.Redirect(Response, link.ListarGruposTrabajoAsignaturaAnyoAlumno(asignaturaanyoId));
        }
    }
}