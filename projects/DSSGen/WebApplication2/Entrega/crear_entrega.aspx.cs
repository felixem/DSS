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
    public partial class crear_entrega : BasicPage
    {
        //Creo las fachadas
        FachadaEntrega fachada;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAnyoAcademico fachadaAnyo;
        FachadaSistemaEvaluacion fachadastmeval;
        FachadaProfesor fachadaprofesor; 
        FachadaFecha fachadaFecha;

        //Manejador para la carga de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaEntrega();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadaAnyo = new FachadaAnyoAcademico();
            fachadastmeval = new FachadaSistemaEvaluacion();
            fachadaprofesor = new FachadaProfesor();
            fachadaFecha = new FachadaFecha();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                //Obtener los sistemas evaluacion
                this.ObtenerAnyosAcademicos();
                this.ObtenerAsignaturasAnyo();
                this.ObtenerSistemasEvaluacion();
                this.ObtenerProfesores();
                this.ObtenerAnyos();
                this.ObtenerMeses();
                this.ObtenerDias();
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
                string profesor = DropDownList_Profesores.SelectedValue;

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

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_AsignaturasAnyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia DropDownList de evaluacion y profesores
            DropDownList_SistemaEvaluacion.Items.Clear();
            DropDownList_Profesores.Items.Clear();
            ObtenerSistemasEvaluacion();
            ObtenerProfesores();
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia DropDownList de evaluacion, asignatura y profesores
            DropDownList_AsignaturasAnyo.Items.Clear();
            DropDownList_SistemaEvaluacion.Items.Clear();
            DropDownList_Profesores.Items.Clear();
            ObtenerAsignaturasAnyo();
            ObtenerSistemasEvaluacion();
            ObtenerProfesores();
        }

        //Obtener las asignaturas-anyo
        protected void ObtenerAsignaturasAnyo()
        {
            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            fachadaAsignaturaAnyo.VincularDameTodosPorAnyo(idAnyo, DropDownList_AsignaturasAnyo);
        }

        //Obtener los años académicos
        protected void ObtenerAnyosAcademicos()
        {
            fachadaAnyo.VincularDameTodos(DropDownList_Anyos);
        }

        //Obtener los sistemas evaluacion por AsignaturaAnyo
        protected void ObtenerSistemasEvaluacion()
        {
            int idAsigAnyo = Int32.Parse(DropDownList_AsignaturasAnyo.SelectedValue);
            fachadastmeval.VincularDameTodosPorAsignaturaAnyo(DropDownList_SistemaEvaluacion, idAsigAnyo);
        }

        //Obtener los profesores por AsignaturaAnyo
        protected void ObtenerProfesores()
        {
            int idAsigAnyo = Int32.Parse(DropDownList_AsignaturasAnyo.SelectedValue);
            fachadaprofesor.VincularDameTodosPorAsignaturaAnyo(DropDownList_Profesores, idAsigAnyo);
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