using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Alumno
{
    public partial class crear_alumno : BasicPage
    {
        //Fachadas usadas
        FachadaAlumno alumno;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            alumno = new FachadaAlumno();

            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Método que llama el botón registrar
        protected void Button_RegAlu_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomAlu.Text;
            string apellidos = TextBox_ApellAlu.Text;
            string pass = TextBox_ContAlu.Text;
            DateTime fecha = Convert.ToDateTime(TextBox_NaciAlu.Text);
            string dni = TextBox_DNIAlu.Text;
            string email = TextBox_EmailAlu.Text;
            int cod = Convert.ToInt32(TextBox_CodAlu.Text);
            string codExpediente = TextBox_CodExpediente.Text;
            bool expedienteAbierto = CheckBox_ExpedienteAbierto.Checked;

            //Llamo al metodo que registra al alumno
            bool verificado;

            try
            {
                verificado = alumno.RegistrarAlumno(nombre, apellidos, pass, fecha, dni, email, cod, codExpediente, expedienteAbierto);
            }
            catch (Exception)
            {
                verificado = false;
            }

            //Verifico si se creo el alumno
            if (verificado)
            {
                Notification.Notify(Response, "El alumno ha sido creado");
                this.Clean();
            }
            else
            {
                Notification.Notify(Response,"El alumno no ha podido ser creado");
            }
        }

        //Método para limpiar los campos
        private void Clean()
        {
            TextBox_NomAlu.Text = "";
            TextBox_ApellAlu.Text = "";
            TextBox_ContAlu.Text = "";
            TextBox_VContAlu.Text = "";
            TextBox_NaciAlu.Text = "";
            TextBox_DNIAlu.Text = "";
            TextBox_EmailAlu.Text = "";
            TextBox_CodAlu.Text = "";
            TextBox_CodExpediente.Text = "";
            CheckBox_ExpedienteAbierto.Checked = false;
        }

        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            this.Clean();
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