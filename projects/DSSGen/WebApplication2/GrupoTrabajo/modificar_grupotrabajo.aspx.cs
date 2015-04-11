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
    public partial class modificar_grupotrabajo : System.Web.UI.Page
    {
        FachadaGrupoTrabajo fachadaGrupo;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAnyoAcademico fachadaAnyo;
        private int id;
        String param;
        GrupoTrabajoEN grupo;

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
                //Procesar parámetros
                this.Procesar_Parametros();
                //Cargar datos
                this.CargarDatos();
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
        private void Procesar_Parametros()
        {
            //Recuperar los datos de la asignatura
            try
            {
                grupo = fachadaGrupo.DameGrupoTrabajoPorId(id);
            }
            catch (Exception)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Método que llama el botón para modificar un grupo de trabajo
        protected void Button_ModificarGrupo_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string codigo = TextBox_CodGrupo.Text;
            string nombre = TextBox_NomGrupo.Text;
            string descripcion = TextBox_DescGrupo.Text;
            string password = TextBox_Pass.Text;
            string capacidad = TextBox_Capacidad.Text;

            //Crear la asignatura
            if (fachadaGrupo.ModificarGrupoTrabajo(id, codigo, nombre, descripcion, password,
                Int32.Parse(capacidad)))
            {
                Notification.Notify(Response, "El grupo de trabajo ha sido modificado");
            }
            else
            {
                Notification.Notify(Response,"El grupo de trabajo no ha podido ser modificado");
            }
        }

        //Cargar los datos del alumno original
        private void CargarDatos()
        {
            //Recojo los datos
            TextBox_CodGrupo.Text = grupo.Cod_grupo;
            TextBox_NomGrupo.Text = grupo.Nombre;
            TextBox_DescGrupo.Text = grupo.Descripcion;
            TextBox_Capacidad.Text = grupo.Capacidad.ToString();
            TextBox_Anyo.Text = grupo.Asignatura.Anyo.Anyo.ToString();
            TextBox_Asignatura.Text = grupo.Asignatura.Asignatura.Nombre.ToString() + "(" + TextBox_Anyo.Text + ")";
        }
       
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}