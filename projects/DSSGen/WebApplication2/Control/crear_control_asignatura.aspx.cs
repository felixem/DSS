﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Control
{
    public partial class crear_control_asignatura : BasicPage
    {
        //Creo la fachada del control
        FachadaControl fachada;
        FachadaAsignaturaAnyo fachadaAsignaturaAnyo;
        FachadaSistemaEvaluacion fachadastmeval;

        private int id;
        String param;

        //Manejador para la carga de la pagina
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaControl();
            fachadaAsignaturaAnyo = new FachadaAsignaturaAnyo();
            fachadastmeval = new FachadaSistemaEvaluacion();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                //Obtener los sistemas evaluacion
                this.ObtenerSistemasEvaluacion();
            }

            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Cargar datos
                this.CargarDatos();
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
        protected void Button_RegControl_Click(Object sender, EventArgs e)
        {
            //Llamo al metodo que registra al alumno
            bool verificado;

            try
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
                Linker link = new Linker(true);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Notification.Notify(Response, "El control no ha podido ser creado");
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
            TextBox_ApertuControl.Text = "";
            TextBox_CierreControl.Text = "";
            TextBox_DuraciControl.Text = "";
            TextBox_PuntControl.Text = "";
            TextBox_PenaControl.Text = "";
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