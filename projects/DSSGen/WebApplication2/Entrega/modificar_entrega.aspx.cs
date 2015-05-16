using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Entrega
{
    public partial class modificar_entrega : BasicPage
    {
        FachadaEntrega fachada;
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

            fachada = new FachadaEntrega();
            fachadaFecha = new FachadaFecha();
            Obtener_Parametros();

            if (!IsPostBack)
            {
                ObtenerAnyos();
                ObtenerMeses();
                ObtenerDias();
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
            //Recuperar los datos de la entrega
            if (!fachada.VincularEntregaPorId(id, TextBox_Nom,
            TextBox_Desc, ddlAno, ddlMes, ddlDia, ddlAnoC, ddlMesC, ddlDiaC, TextBox_Punt, 
            TextBox_Anyo, TextBox_Asignatura, TextBox_Evaluacion, TextBox_Profesor, TextBox_CodEntrega))
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
            string apertura = "" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text;
            string cierre = "" + ddlDiaC.Text + "/" + ddlMesC.Text + "/" + ddlAnoC.Text;
            string puntmaxima = TextBox_Punt.Text;

            //Pruebo a registrar la entrega
            fachada.ModificarEntrega(id, nombre, descripcion, DateTime.Parse(apertura), 
                DateTime.Parse(cierre), float.Parse(puntmaxima));
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

        //Cargar el ddl Anyos
        protected void ObtenerAnyos()
        {
            fachadaFecha.VincularDameAnyos(ddlAno, 10, 10);
            fachadaFecha.VincularDameAnyos(ddlAnoC, 10, 10);
        }
        //Cargar el dll  meses
        protected void ObtenerMeses()
        {

            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAno.SelectedValue), ddlMes);
            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAnoC.SelectedValue), ddlMesC);

        }
        //Cargar el ddl dias
        protected void ObtenerDias()
        {

            fachadaFecha.VincularDameDias(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMesC.SelectedValue), Int32.Parse(ddlAnoC.SelectedValue), ddlDiaC);

        }

        //Evento ocurrido al seleccionar un año
        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMes.Items.Clear();
            ddlDia.Items.Clear();

            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAno.SelectedValue), ddlMes);
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);
        }

        //Evento ocurrido al seleccionar un mes
        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDia.Items.Clear();
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);

        }
        //Evento ocurrido al seleccionar un año
        protected void ddlAnoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMesC.Items.Clear();
            ddlDiaC.Items.Clear();
            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAnoC.SelectedValue), ddlMesC);
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMesC.SelectedValue), Int32.Parse(ddlAnoC.SelectedValue), ddlDiaC);
        }

        //Evento ocurrido al seleccionar un mes
        protected void ddlMesC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDiaC.Items.Clear();
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMesC.SelectedValue), Int32.Parse(ddlAnoC.SelectedValue), ddlDiaC);

        }
    }
}