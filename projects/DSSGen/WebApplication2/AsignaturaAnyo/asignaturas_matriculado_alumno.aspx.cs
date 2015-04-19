using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.AsignaturaAnyo
{
    public partial class asignaturas_matriculado_alumno : BasicPage //System.Web.UI.Page
    {
        //Sesion de usuario
        MySession session;
        //Fachada utilizada en la página
        FachadaAsignaturaAnyo fachadaAsignatura;
        //Fachada para los años
        FachadaAnyoAcademico fachadaAnyo;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            session = MySession.Current;
            fachadaAsignatura = new FachadaAsignaturaAnyo();
            fachadaAnyo = new FachadaAnyoAcademico();

            if (!IsPostBack)
            {
                this.ObtenerAnyosAcademicos();
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

            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            string alumno = session.Usuario.Email;

            //Vincular el grid con la lista de asignaturas impartidas en el año paginada
            fachadaAsignatura.VincularDameTodosAsignaturaAnyoPorAlumno(alumno ,idAnyo, GridViewBolsas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

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

        //Manejador del evento para listar los grupos de trabajo de una asignatura-anyo
        protected void lnkInscripcionGrupo_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            int asignaturaId = Int32.Parse(grdrow.Cells[0].Text);

            Linker link = new Linker(true);
            link.Redirect(Response, link.ListarGruposTrabajoAsignaturaAnyoAlumno(asignaturaId));
        }

        //Obtener los años académicos
        protected void ObtenerAnyosAcademicos()
        {
            fachadaAnyo.VincularDameTodos(DropDownList_Anyos);
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ObtenerAsignaturasPaginadas(1);
        }
    }
}