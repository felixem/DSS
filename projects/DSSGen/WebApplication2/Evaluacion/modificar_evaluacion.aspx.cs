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
        FachadaFecha fachadaFecha;
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
            fachadaFecha = new FachadaFecha();
            Obtener_Parametros();
            ObtenerAnyos();
            ObtenerMeses();
            ObtenerDias();
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
            if (!fachada.VincularEvaluacionPorId(id,TextBox_Nombre,CheckBox_Abierta))
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
            string inicio = "" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text;
            string fin = "" + ddlDiaC.Text + "/" + ddlMesC.Text + "/" + ddlAnoC.Text;
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

        //Cargar el ddl Anyos
        protected void ObtenerAnyos()
        {
            fachadaFecha.VincularDameAnyos(ddlAno);
            fachadaFecha.VincularDameAnyos(ddlAnoC);
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