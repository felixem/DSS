using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.EntregaAlumno
{
    public partial class calificar : BasicPage
    {
        FachadaEntregaAlumno fachada;
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

            fachada = new FachadaEntregaAlumno();
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
            //Recuperar los datos de la entrega
            if (!fachada.VincularEntregaAlumnoPorIdLigero(id, TextBox_Cod, TextBox_NomAlu, TextBox_ApeAlu,
                TextBox_Dni, TextBox_ComentAlu, CheckBox_Corregido))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Método que llama al botón calificar
        protected void Button_Calificar_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            float nota = float.Parse(TextBox_Nota.Text);
            string comentarioprofesor = TextBox_ComentProf.Text;
            bool calificado = CheckBox_Corregido.Checked;

            bool verificado;
            //Pruebo a registrar el control
            try
            {
                verificado = fachada.CalificarEntrega(id, nota, comentarioprofesor, calificado);
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Compruebo si se han almacenado los cambios
            if (verificado)
            {
                Notification.Notify(Response, "La entrega ha sido calificada");
            }
            else
            {
                Notification.Notify(Response, "La entrega no ha podido ser calificada");
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