﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Evaluacion
{
    public partial class crear_evaluacion : BasicPage
    {
        //Creo la fachada de la evaluación.
        FachadaEvaluacion fachada;
        FachadaAnyoAcademico fachadaAnyo;
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada= new FachadaEvaluacion();
            fachadaAnyo=new FachadaAnyoAcademico();
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
                //Obtener los sistemas evaluacion
                this.ObtenerAnyosAcademicos();
            }
        }
        protected void Button_RegControl_Click(Object sender, EventArgs e)
        {
            //Llamo al metodo que registra al alumno
            bool verificado;

            try
            {
                //Recogo los datos
                string nombre = TextBox_Nombre.Text;
                DateTime inicio = DateTime.Parse(TextBox_FechaI.Text);
                DateTime fin = DateTime.Parse(TextBox_FechaF.Text);
                bool abierto= CheckBox_Abierta.Checked;
                int anyo= Int32.Parse(DropDownList_Anyos.SelectedValue);
                verificado = fachada.RegistrarEvaluacion(nombre,inicio,fin,abierto,anyo);
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
        }        //Botón utilizado para cancelar la creación y volver atrás
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
        //Método para limpiar campos
          private void Clean()
        {
            TextBox_Nombre.Text="";
            TextBox_FechaI.Text="";
            TextBox_FechaF.Text="";
        }
       
        //Obtener los años académicos
        protected void ObtenerAnyosAcademicos()
        {
            fachadaAnyo.VincularDameTodos(DropDownList_Anyos);
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