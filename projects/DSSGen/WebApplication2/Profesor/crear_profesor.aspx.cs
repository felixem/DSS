using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Profesor
{
    public partial class crear_profesor : System.Web.UI.Page
    {
        //Creo la fachada
        FachadaProfesor profesor;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            profesor = new FachadaProfesor();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Método que llama el botón registrar
        protected void Button_RegProf_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomProf.Text;
            string apellidos = TextBox_ApellProf.Text;
            string pass = TextBox_ContProf.Text;
            string fecha = TextBox_NaciProf.Text;
            string dni = TextBox_DNIProf.Text;
            string email = TextBox_EmailProf.Text;
            string cod = TextBox_CodProf.Text;

            //Llamo al metodo que registra al alumno
            bool verificado = profesor.RegistrarProfesor(nombre, apellidos, pass, Convert.ToDateTime(fecha), dni, email, Convert.ToInt32(cod));

            if (verificado)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Response.Write("<script>window.alert('El profesor no ha podido ser creado');</script>");
            }
        }

        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            TextBox_NomProf.Text = "";
            TextBox_ApellProf.Text = "";
            TextBox_ContProf.Text = "";
            TextBox_VContProf.Text = "";
            TextBox_NaciProf.Text = "";
            TextBox_DNIProf.Text = "";
            TextBox_EmailProf.Text = "";
            TextBox_CodProf.Text = "";
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

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}