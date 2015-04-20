using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Sistema_Evaluacion
{
    public partial class modificar_sistema : BasicPage
    {
        FachadaSistemaEvaluacion fachada;
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

            fachada = new FachadaSistemaEvaluacion();
            Obtener_Parametros();

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
            if (!fachada.VincularSistemaPorId(id, TextBox_Puntuacion))
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
            float puntuacion = float.Parse(TextBox_Puntuacion.Text);


            bool verificado;
            //Pruebo a registrar el sistema
            try
            {
                verificado = fachada.ModificarSistemaEvaluacion(id, puntuacion);
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Compruebo si se han almacenado los cambios
            if (verificado)
            {
                Notification.Notify(Response, "El sistema de evaluación ha sido modificado");
            }
            else
            {
                Notification.Notify(Response, "El sistema de evaluación no ha podido ser modificado");
            }
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

      
    }
}