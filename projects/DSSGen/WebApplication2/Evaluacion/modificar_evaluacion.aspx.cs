using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Evaluacion
{
    public partial class modificar_evaluacion : BasicPage
    {
        FachadaEvaluacion fachada;
        private int id;
        String param;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }

            fachada = new FachadaEvaluacion();
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
            //Recuperar los datos de la evaluacion
            if (!fachada.VincularEvaluacionPorId(id,TextBox_Nombre,TextBox_FechaI,TextBox_FechaF,CheckBox_Abierta))
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
            string nombre = TextBox_Nombre.Text;
            string inicio = TextBox_FechaI.Text;
            string fin = TextBox_FechaF.Text;
            bool abierta = CheckBox_Abierta.Checked;
            
            fachada.ModificarEvaluacion(id, nombre, DateTime.Parse(inicio), DateTime.Parse(fin),abierta);

            //Modificar evaluación
            fachada.ModificarEvaluacion(id, nombre, DateTime.Parse(inicio), DateTime.Parse(fin),abierta);
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