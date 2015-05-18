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
    public partial class modificar_alumno : BasicPage
    {
        FachadaAlumno fachada;
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

            fachada = new FachadaAlumno();
            fachadaFecha = new FachadaFecha();
            Obtener_Parametros();

            if (!IsPostBack)
            {
                ObtenerAnyos();
                ObtenerMeses();
                ObtenerDias();
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
                TextBox_ApellAlu, ddlAno, ddlMes, ddlDia, TextBox_DNIAlu, TextBox_EmailAlu,
                TextBox_CodAlu, CheckBox_Baneado, TextBox_CodExpediente))
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
            string dni = TextBox_DNIAlu.Text;
            string email = TextBox_EmailAlu.Text;
            string cod = TextBox_CodAlu.Text;
            string fecha = "" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text;
            bool baneado = CheckBox_Baneado.Checked;
            //Intentar modificar el alumno
            fachada.ModificarAlumnoNoPassword(email, Convert.ToInt32(cod), baneado, dni, nombre, apellidos, DateTime.Parse(fecha));
            //Mostrar notificación
            Notification.Current.NotifyLastNotification(Response);
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