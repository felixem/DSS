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
    public partial class crear_asignaturaanyo : System.Web.UI.Page
    {
        FachadaAsignatura fachadaAsignatura;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAnyoAcademico fachadaAnyo;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachadaAsignatura = new FachadaAsignatura();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadaAnyo = new FachadaAnyoAcademico();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                this.ObtenerAnyosAcademicos();
                this.ObtenerAsignaturas();
            }
        }

        //Método que llama el botón para crear una asignatura-anyo
        protected void Button_Crear_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            int idAsignatura = Int32.Parse(DropDownList_Asignaturas.SelectedValue);

            //Crear la asignatura
            if (fachadaAsignaturaAnyo.CrearAsignaturaAnyo(idAnyo,idAsignatura))
            {
                Notification.Notify(Response, "La asignatura ha sido vinculada con el año académico");
            }
            else
                Notification.Notify(Response,"La asignatura no ha podido ser vinculada con el año académico");

            this.ObtenerAsignaturas();
        }
    
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Obtener las asignaturas
        protected void ObtenerAsignaturas()
        {
            DropDownList_Asignaturas.Items.Clear();
            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            fachadaAsignatura.VincularDameTodosVinculablesAAnyo(idAnyo,DropDownList_Asignaturas);
        }

        //Obtener los años académicos
        protected void ObtenerAnyosAcademicos()
        {
            fachadaAnyo.VincularDameTodos(DropDownList_Anyos);
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ObtenerAsignaturas();
        }

    }
}