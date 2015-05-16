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
    public partial class modificar_profesor : BasicPage
    {
        FachadaProfesor fachada;
        FachadaFecha fachadaFecha;
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
            fachadaFecha = new FachadaFecha();
            fachada = new FachadaProfesor();
            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
                ObtenerAnyos();
                ObtenerMeses();
                ObtenerDias();
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
            //Recuperar los datos del profesor
            if (!fachada.VincularProfesorPorId(id, TextBox_NomProf,
                    TextBox_ApellProf, ddlAno, ddlMes, ddlDia, TextBox_DNIProf,
                    TextBox_EmailProf, TextBox_CodProf))
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
            string nombre = TextBox_NomProf.Text;
            string apellidos = TextBox_ApellProf.Text;
            string fecha ="" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text;
            string dni = TextBox_DNIProf.Text;
            string email = TextBox_EmailProf.Text;
            string cod = TextBox_CodProf.Text;

            //Modificar profesor
            fachada.ModificarProfesorNoPassword(email, Convert.ToInt32(cod), dni, nombre, apellidos, DateTime.Parse(fecha));
            Notification.Current.NotifyLastNotification(Response);
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

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
        protected void ObtenerAnyos()
        {
            fachadaFecha.VincularDameAnyos(ddlAno, 100, 0);

        }
        protected void ObtenerMeses()
        {

            fachadaFecha.VincularDameMesesNac(Int32.Parse(ddlAno.SelectedValue), ddlMes);


        }
        protected void ObtenerDias()
        {

            fachadaFecha.VincularDameDiasNac(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);


        }

        //Evento ocurrido al seleccionar un año
        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMes.Items.Clear();
            ddlDia.Items.Clear();

            fachadaFecha.VincularDameMesesNac(Int32.Parse(ddlAno.SelectedValue), ddlMes);
            fachadaFecha.VincularDameDiasNac(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);
        }

        //Evento ocurrido al seleccionar un mes
        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDia.Items.Clear();
            fachadaFecha.VincularDameDiasNac(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);

        }
    }
}