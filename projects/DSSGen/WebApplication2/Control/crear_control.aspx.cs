using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Control
{
    public partial class crear_control : System.Web.UI.Page
    {
        //Creo la fachada del control
        FachadaControl fachada;

        //Manejador para la carga de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaControl();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Método que llama el botón crear
        protected void Button_RegControl_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomControl.Text;
            string descripcion = TextBox_DescControl.Text;
            DateTime apertura = Convert.ToDateTime(TextBox_ApertuControl.Text);
            DateTime cierre = Convert.ToDateTime(TextBox_CierreControl.Text);
            int duracionMin = Convert.ToInt32(TextBox_DuraciControl.Text);
            float puntMax = Convert.ToSingle(TextBox_PuntControl.Text);
            float penalizacion = Convert.ToSingle(TextBox_PenaControl.Text);
            int sistemaEvaluacion = Convert.ToInt32(TextBox_SistemEvaControl.Text);

            //Llamo al metodo que registra al alumno
            bool verificado;

            try
            {
                verificado = fachada.RegistrarControl(nombre, descripcion, apertura, cierre, duracionMin, puntMax, penalizacion, sistemaEvaluacion);
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Verifico si se creo el alumno
            if (verificado)
            {
                Notification.Notify(Response, "El control ha sido creado");
            }
            else
            {
                Notification.Notify(Response, "El control no ha podido ser creado");
            }
        }
    }
}