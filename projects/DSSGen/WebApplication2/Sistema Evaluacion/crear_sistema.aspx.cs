using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Sistema_Evaluacion
{
    public partial class crear_sistema : BasicPage
    {
        //Creo la fachada del control
        FachadaSistemaEvaluacion fachada;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaAnyoAcademico fachadaAnyo;
        FachadaEvaluacion fachadaeval;
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaSistemaEvaluacion();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadaAnyo = new FachadaAnyoAcademico();
            fachadaeval = new FachadaEvaluacion();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                //Obtener los sistemas evaluacion
                this.ObtenerAnyosAcademicos();
                this.ObtenerAsignaturasAnyo();
                this.ObtenerEvaluaciones();
            }
        }
        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpia DropDownList de evaluacion y asignatura
            DropDownList_AsignaturasAnyo.Items.Clear();
            DropDownList_Evaluacion.Items.Clear();
            ObtenerAsignaturasAnyo();
            ObtenerEvaluaciones();
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

        //Obtener las evaluaciones
        protected void ObtenerEvaluaciones()
        {
            int idAnyo = Int32.Parse(DropDownList_Anyos.SelectedValue);
            fachadaeval.VincularDameTodosPorAnyo(idAnyo,DropDownList_Anyos);
        }

        //Método que llama el botón crear
        protected void Button_RegSistema_Click(Object sender, EventArgs e)
        {
            //Llamo al metodo que registra al sistema
            bool verificado;

            try
            {
                //Recogo los datos
                float puntMax = float.Parse(TextBox_Puntuacion.Text);
                int asignatura = Int32.Parse(DropDownList_AsignaturasAnyo.SelectedValue);
                int evaluacion = Int32.Parse(DropDownList_Evaluacion.SelectedValue);
                verificado = fachada.RegistrarSistema(puntMax,asignatura,evaluacion);
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Verifico si se creo el alumno
            if (verificado)
            {
                Notification.Notify(Response, "El control ha sido creado");
                Linker link = new Linker(true);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Notification.Notify(Response, "El control no ha podido ser creado");
            }
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
            TextBox_Puntuacion.Text = "";
        }
    }
}