using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Asignatura
{
    public partial class modificar_asignatura : System.Web.UI.Page
    {
        FachadaAsignatura fachada;
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

            fachada = new FachadaAsignatura();
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

        //Comprobar parámetros y cargar datos
        private void CargarDatos()
        {
            //Recuperar los datos de la asignatura
            if(!fachada.VincularAsignaturaPorId(id,TextBox_Curso, TextBox_IdAsig,
                    TextBox_CodAsig, TextBox_NomAsig, TextBox_DescAsig,
                    CheckBox_OptativaAsig, CheckBox_VigenteAsig))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Método que llama el botón para crear una asignatura
        protected void Button_ModificarAsig_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string codigo = TextBox_CodAsig.Text;
            string nombre = TextBox_NomAsig.Text;
            string descripcion = TextBox_DescAsig.Text;
            bool optativo = CheckBox_OptativaAsig.Checked;
            bool vigente = CheckBox_VigenteAsig.Checked;

            //Modificar la asignatura
            if (fachada.ModificarAsignatura(id,codigo,nombre,descripcion,optativo,vigente))
            {
                Notification.Notify(Response, "La asignatura ha sido modificada");
            }
            else
            {
                Notification.Notify(Response,"La asignatura no ha podido ser modificada");
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