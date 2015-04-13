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
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAnyoAcademico fachadaAnyo;
        FachadaSistemaEvaluacion fachadastmeval;

        //Manejador para la carga de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaControl();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadaAnyo = new FachadaAnyoAcademico();
            fachadastmeval = new FachadaSistemaEvaluacion();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                //Obtener los sistemas evaluacion
                this.ObtenerAnyosAcademicos();
                this.ObtenerAsignaturasAnyo();
                this.ObtenerSistemasEvaluacion();
            }
        }

        //Método que llama el botón crear
        protected void Button_RegControl_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomControl.Text;
            string descripcion = TextBox_DescControl.Text;
            DateTime apertura = DateTime.Parse(TextBox_ApertuControl.Text);
            DateTime cierre = DateTime.Parse(TextBox_CierreControl.Text);
            int duracionMin = Int32.Parse(TextBox_DuraciControl.Text);
            float puntMax = float.Parse(TextBox_PuntControl.Text);
            float penalizacion = float.Parse(TextBox_PenaControl.Text);
            int sistemaEvaluacion = Int32.Parse(DropDownList_SistemaEvaluacion.SelectedValue);
             
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

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_AsignaturasAnyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia DropDownList de evaluacion
            DropDownList_SistemaEvaluacion.Items.Clear();
            ObtenerSistemasEvaluacion();
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia DropDownList de evaluacion y asignatura
            DropDownList_AsignaturasAnyo.Items.Clear();
            DropDownList_SistemaEvaluacion.Items.Clear();
            ObtenerAsignaturasAnyo();
            ObtenerSistemasEvaluacion();
        }

        //Obtener las asignaturas-anyo
        protected void ObtenerAsignaturasAnyo()
        {
            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            fachadaAsignaturaAnyo.VincularDameTodosPorAnyo(DropDownList_AsignaturasAnyo, idAnyo);
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
            fachadastmeval.VincularDameTodosPorAsignaturaAnyo(DropDownList_SistemaEvaluacion,idAsigAnyo);
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
            TextBox_ApertuControl.Text = "";
            TextBox_CierreControl.Text = "";
            TextBox_DuraciControl.Text = "";
            TextBox_PuntControl.Text = "";
            TextBox_PenaControl.Text = "";
        }
    }
}