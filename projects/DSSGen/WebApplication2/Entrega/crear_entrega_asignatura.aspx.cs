using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Entrega
{
    public partial class crear_entrega_asignatura : BasicPage
    {
        //Creo las fachadas
        FachadaEntrega fachada;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaSistemaEvaluacion fachadastmeval;
        FachadaFecha fachadaFecha;

        private int id;
        String param;

        //Manejador para la carga de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaEntrega();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadastmeval = new FachadaSistemaEvaluacion();
            fachadaFecha = new FachadaFecha();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }

            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
                this.ObtenerAnyos();
                this.ObtenerMeses();
                this.ObtenerDias();
                //Obtener los sistemas evaluacion
                this.ObtenerSistemasEvaluacion();
            }
        }

        //Comprobar los parámetros
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
            //Recuperar los datos de la asignatura-anyo
            if (!fachadaAsignaturaAnyo.VincularAsignaturaAnyoPorIdLigero(id, TextBox_Asignatura))
            {
                //Redirigir a la página que le llamó en caso de error
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Método que llama el botón crear
        protected void Button_RegEntrega_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomControl.Text;
            string descripcion = TextBox_DescControl.Text;
            DateTime apertura = DateTime.Parse("" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text);
            DateTime cierre = DateTime.Parse("" + ddlDiaC.Text + "/" + ddlMesC.Text + "/" + ddlAnoC.Text); 
            float puntMax = float.Parse(TextBox_PuntControl.Text);
            int sistemaEvaluacion = Int32.Parse(DropDownList_SistemaEvaluacion.SelectedValue);
            //El profesor de la sesion actual
            string profesor = MySession.Current.Usuario.Email;

            //Crear entrega
            if (fachada.RegistrarEntrega(nombre, descripcion, apertura, cierre, puntMax, profesor, sistemaEvaluacion))
            {
                Notification.Current.NotifyLastNotification(Response);
                this.Clean();
            }
            else
            {
                Notification.Current.NotifyLastNotification(Response);
            }
        }

        //Obtener los sistemas evaluacion por AsignaturaAnyo
        protected void ObtenerSistemasEvaluacion()
        {
            fachadastmeval.VincularDameTodosPorAsignaturaAnyo(DropDownList_SistemaEvaluacion, id);
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            this.Clean();
        }

        //Método para limpiar
        private void Clean()
        {
            TextBox_NomControl.Text = "";
            TextBox_DescControl.Text = "";
            TextBox_PuntControl.Text = "";
        }

        protected void ObtenerAnyos()
        {
            fachadaFecha.VincularDameAnyos(ddlAno, 10, 10);
            fachadaFecha.VincularDameAnyos(ddlAnoC, 10, 10);
        }
        protected void ObtenerMeses()
        {

            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAno.SelectedValue), ddlMes);
            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAnoC.SelectedValue), ddlMesC);

        }
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