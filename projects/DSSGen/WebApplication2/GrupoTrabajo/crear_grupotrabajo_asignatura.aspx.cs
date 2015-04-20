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
    public partial class crear_grupotrabajo_asignatura : BasicPage
    {
        FachadaGrupoTrabajo fachadaGrupo;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAnyoAcademico fachadaAnyo;
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
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadaAnyo = new FachadaAnyoAcademico();

            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
            }
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

        //Método que llama el botón para crear un grupo de trabajo
        protected void Button_CrearGrupo_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string codigo = TextBox_CodGrupo.Text;
            string nombre = TextBox_NomGrupo.Text;
            string descripcion = TextBox_DescGrupo.Text;
            string password = TextBox_Pass.Text;
            int capacidad = Int32.Parse(TextBox_Capacidad.Text);
            int idAsignaturaAnyo = id;

            //Crear el grupo de trabajo
            if (fachadaGrupo.CrearGrupoTrabajo(codigo, nombre, descripcion, password,
                capacidad, idAsignaturaAnyo))
            {
                Notification.Notify(Response, "El grupo de trabajo ha sido creado");
                this.Clean();
            }
            else
                Notification.Notify(Response, "El grupo de trabajo no ha podido ser creado");
        }
       
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
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
    }
}