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
    public partial class acceso_grupotrabajo : BasicPage
    {
        FachadaGrupoTrabajo fachadaGrupo;
        //FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        //FachadaAnyoAcademico fachadaAnyo;
        private int id;
        private string alumno;
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
            //fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            //fachadaAnyo = new FachadaAnyoAcademico();
            alumno = MySession.Current.Usuario.Email;

            Obtener_Parametros();

            if (!IsPostBack)
            {
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
        private void CargarDatos()
        {
            //Recuperar los datos del grupo de trabajo
            if (!fachadaGrupo.VincularGrupoTrabajoPorIdCompleto(id, TextBox_CodGrupo,
                    TextBox_NomGrupo, TextBox_DescGrupo, TextBox_Capacidad,
                    TextBox_Anyo, TextBox_Asignatura))
            {
                //Redirigir a la página que le llamó en caso de error
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Método que llama el botón para modificar un grupo de trabajo
        protected void Button_AccederGrupo_Click(Object sender, EventArgs e)
        {
            string password = TextBox_Pass.Text;

            //Crear la asignatura
            //Si tras comprobar el pass ingresa al grupo
            if (fachadaGrupo.ComprobarPassword(id, password))
            {
                if (fachadaGrupo.VincularAlumno(id, alumno))
                    Notification.Notify(Response, "Se ha unido al grupo con éxito");
                else
                    Notification.Notify(Response, "No se ha podido unir al grupo");
            }
            else
            {
                Notification.Notify(Response,"Contraseña Incorrecta");
            }
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