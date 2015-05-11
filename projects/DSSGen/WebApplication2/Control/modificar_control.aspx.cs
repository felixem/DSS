using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Control
{
    public partial class modificar_control : BasicPage
    {
        FachadaControl fachada;
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

            fachada = new FachadaControl();
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
            //Recuperar los datos del control
            if (!fachada.VincularControlPorId(id, TextBox_Nom,
            TextBox_Desc, TextBox_Apertura, TextBox_Cierre,
            TextBox_Duracion, TextBox_PuntMax, TextBox_Penalizacion, 
            TextBox_Anyo, TextBox_Asignatura, TextBox_Evaluacion, TextBox_CodControl))
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
            string nombre = TextBox_Nom.Text;
            string descripcion = TextBox_Desc.Text;
            string apertura = TextBox_Apertura.Text;
            string cierre = TextBox_Cierre.Text;
            string duracion = TextBox_Duracion.Text;
            string puntmaxima = TextBox_PuntMax.Text;
            string penalizacion = TextBox_Penalizacion.Text;

            //Modificar el control
            fachada.ModificarControl(id,nombre,descripcion,DateTime.Parse(apertura),DateTime.Parse(cierre),
                Int32.Parse(duracion),float.Parse(puntmaxima), float.Parse(penalizacion));
            //Mostrar notificación
            Notification.Current.NotifyLastNotification(Response);
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Metodo que comprueba la fecha(Control de validacion)
        protected void ComprobarFecha(object sender, ServerValidateEventArgs e)
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
    }
}