using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Create
{
    public partial class CreateStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Método que llama el botón registrar
        protected void Button_RegAlu_Click(Object sender, EventArgs e)
        {
            //Creo la fachada
            FachadaAlumno alumno = new FachadaAlumno();

            //Recogo los datos
            string nombre = TextBox_NomAlu.Text;
            string apellidos = TextBox_ApellAlu.Text;
            string pass = TextBox_ContAlu.Text;
            string fecha = TextBox_NaciAlu.Text;
            string dni = TextBox_DNIAlu.Text;
            string email = TextBox_EmailAlu.Text;
            string cod = TextBox_CodAlu.Text;

            //Llamo al metodo que registra al alumno
            string verificado = alumno.RegistrarAlumno(nombre, apellidos, pass, fecha, dni, email, cod);

            if (verificado != "Invalido")
            {
                Response.Write("<script>window.alert('El usuario: " + verificado + " se ha creado correctamente');</script>");
            }
            else 
            {
                Response.Write("<script>window.alert('El usuario no se ha creado');</script>");
            }
        }
    
        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            TextBox_NomAlu.Text = "";
            TextBox_ApellAlu.Text = "";
            TextBox_ContAlu.Text = "";
            TextBox_VContAlu.Text = "";
            TextBox_NaciAlu.Text = "";
            TextBox_DNIAlu.Text = "";
            TextBox_EmailAlu.Text = "";
            TextBox_CodAlu.Text = "";
        }
    
        //Metodo que comprueba la fecha(Control de validacion)
        protected void ComprobarFecha(object sender,ServerValidateEventArgs e)
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