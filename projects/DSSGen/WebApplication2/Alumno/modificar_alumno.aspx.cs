using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Alumno
{
    public partial class modificar_alumno : System.Web.UI.Page
    {
        FachadaAlumno fachada;
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

            fachada = new FachadaAlumno();
            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Procesar parámetros y cargar datos
                this.CargarDatos();
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
                id = Int32.Parse(param);
        }

        //Comprobar parámetros y cargar datos
        private void CargarDatos()
        {
            //Recuperar los datos del alumno
            if (!fachada.VincularAlumnoPorId(id, TextBox_NomAlu,
                TextBox_ApellAlu, TextBox_NaciAlu, TextBox_DNIAlu, TextBox_EmailAlu,
                TextBox_CodAlu, CheckBox_Baneado))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Método que llama al botón modificar
        protected void Button_Modificar_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string nombre = TextBox_NomAlu.Text;
            string apellidos = TextBox_ApellAlu.Text;
            string fecha = TextBox_NaciAlu.Text;
            string dni = TextBox_DNIAlu.Text;
            string email = TextBox_EmailAlu.Text;
            string cod = TextBox_CodAlu.Text;
            bool baneado = CheckBox_Baneado.Checked;

            bool verificado;
            //Pruebo a registrar el alumno
            try
            {
                verificado = fachada.ModificarAlumnoNoPassword(email, Convert.ToInt32(cod), baneado, dni, nombre, apellidos, Convert.ToDateTime(fecha));
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Compruebo si se ha modificado
            if (verificado)
            {
                Notification.Notify(Response, "El alumno ha sido modificado");
            }
            else
            {
                Notification.Notify(Response, "El alumno no ha podido ser modificado");
            }
        }
     
        //Metodo que comprueba la fecha(Control de validacion)
        protected void ComprobarFecha(object sender,ServerValidateEventArgs e)
        {
            try
            {
                Convert.ToDateTime(e.Value);
                e.IsValid = true;
            }
            catch (Exception)
            {
                e.IsValid = false;
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