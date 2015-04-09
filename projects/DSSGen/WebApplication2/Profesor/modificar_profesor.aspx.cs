using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Profesor
{
    public partial class modificar_profesor : System.Web.UI.Page
    {
        FachadaProfesor fachada;
        private int id;
        String param;
        ProfesorEN profesor;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }

            fachada = new FachadaProfesor();
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

        //Comprobar parámetros
        private void Procesar_Parametros()
        {
            //Recuperar los datos del profesor
            try
            {
                profesor = fachada.DameProfesorPorId(id);
            }
            catch (Exception)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }


        //Cargar los datos del profesor original
        private void CargarDatos()
        {
            //Cargar todos los datos del profesor
            UsuarioEN usuario = profesor as UsuarioEN;
            TextBox_NomProf.Text = usuario.Nombre;
            TextBox_ApellProf.Text = usuario.Apellidos;
            TextBox_NaciProf.Text = usuario.Fecha_nacimiento.ToString();
            TextBox_DNIProf.Text = usuario.Dni;
            TextBox_EmailProf.Text = usuario.Email;
            TextBox_CodProf.Text = profesor.Cod_profesor.ToString();
        }

        //Método que llama al botón modificar
        protected void Button_Modificar_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string nombre = TextBox_NomProf.Text;
            string apellidos = TextBox_ApellProf.Text;
            string fecha = TextBox_NaciProf.Text;
            string dni = TextBox_DNIProf.Text;
            string email = TextBox_EmailProf.Text;
            string cod = TextBox_CodProf.Text;

            bool verificado;
            //Pruebo a registrar el profesor
            try
            {
                verificado = fachada.ModificarProfesorNoPassword(email, Convert.ToInt32(cod), dni, nombre, apellidos, Convert.ToDateTime(fecha));
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Compruebo si se han almacenado los cambios
            if (verificado)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Response.Write("<script>window.alert('El usuario no ha podido ser modificado');</script>");
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