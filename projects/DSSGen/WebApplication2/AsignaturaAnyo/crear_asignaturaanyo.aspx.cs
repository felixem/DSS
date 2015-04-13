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
                this.ObtenerAsignaturasAnyo();
            }
        }

        //Método que llama el botón para crear una asignatura-anyo
        protected void Button_Crear_Click(Object sender, EventArgs e)
        {
            throw new Exception("Not implemented yet");
            //Recojo los datos
            string codigo = TextBox_CodGrupo.Text;
            string nombre = TextBox_NomGrupo.Text;
            string descripcion = TextBox_DescGrupo.Text;
            string password = TextBox_Pass.Text;
            string capacidad = TextBox_Capacidad.Text;
            string idAsignaturaAnyo = DropDownList_AsignaturasAnyo.SelectedValue;

            //Crear la asignatura
            /*if (fachadaGrupo.CrearGrupoTrabajo(codigo,nombre,descripcion,password,
                Int32.Parse(capacidad),Int32.Parse(idAsignaturaAnyo)))
            {
                Notification.Notify(Response, "El grupo de trabajo ha sido creado");
                this.Clean();
            }
            else
                Notification.Notify(Response,"El grupo de trabajo no ha podido ser creado");*/
        }
    
        //Método para limpiar
        private void Clean()
        {
            TextBox_CodGrupo.Text = "";
            TextBox_NomGrupo.Text = "";
            TextBox_DescGrupo.Text = "";
            TextBox_Pass.Text = "";
            TextBox_Capacidad.Text = "";
        }

        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            this.Clean();
        }
    
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_AsignaturasAnyo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_AsignaturasAnyo.Items.Clear();
            ObtenerAsignaturasAnyo();
        }

        //Obtener las asignaturas-anyo
        protected void ObtenerAsignaturasAnyo()
        {
            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            fachadaAsignaturaAnyo.VincularDameTodosPorAnyo(DropDownList_AsignaturasAnyo,idAnyo);
        }

        //Obtener los años académicos
        protected void ObtenerAnyosAcademicos()
        {
            fachadaAnyo.VincularDameTodos(DropDownList_Anyos);
        }

    }
}