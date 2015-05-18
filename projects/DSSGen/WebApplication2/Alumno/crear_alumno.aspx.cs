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
        FachadaFecha fachadaFecha;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            alumno = new FachadaAlumno();
            fachadaFecha = new FachadaFecha();
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
                this.ObtenerAnyos();
                this.ObtenerMeses();
                this.ObtenerDias();
            }
        }

        //Método que llama el botón registrar
        protected void Button_RegAlu_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomAlu.Text;
            string apellidos = TextBox_ApellAlu.Text;
            string pass = TextBox_ContAlu.Text;
            DateTime fecha = DateTime.Parse("" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text);
            string dni = TextBox_DNIAlu.Text;
            string email = TextBox_EmailAlu.Text;
            int cod = Int32.Parse(TextBox_CodAlu.Text);
            string codExpediente = TextBox_CodExpediente.Text;
            bool expedienteAbierto = CheckBox_ExpedienteAbierto.Checked;

            //Llamo al metodo que registra al alumno
            bool verificado = alumno.RegistrarAlumno(nombre, apellidos, pass, fecha, dni, email, cod, codExpediente, expedienteAbierto);

            //Verifico si se creo el alumno
            if (verificado)
            {
                Notification.Current.NotifyLastNotification(Response);
                this.Clean();
            }
            else
            {
                Notification.Current.NotifyLastNotification(Response);
            }
        }

        //Método para limpiar los campos
        private void Clean()
        {
            TextBox_NomAlu.Text = "";
            TextBox_ApellAlu.Text = "";
            TextBox_ContAlu.Text = "";
            TextBox_VContAlu.Text = "";
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
        protected void ObtenerAnyos()
        {
            fachadaFecha.VincularDameAnyos(ddlAno, 100, 0);

        }
        protected void ObtenerMeses()
        {

            fachadaFecha.VincularDameMesesNac(Int32.Parse(ddlAno.SelectedValue), ddlMes);


        }
        protected void ObtenerDias()
        {

            fachadaFecha.VincularDameDiasNac(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);


        }

        //Evento ocurrido al seleccionar un año
        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMes.Items.Clear();
            ddlDia.Items.Clear();

            fachadaFecha.VincularDameMesesNac(Int32.Parse(ddlAno.SelectedValue), ddlMes);
            fachadaFecha.VincularDameDiasNac(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);
        }

        //Evento ocurrido al seleccionar un mes
        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDia.Items.Clear();
            fachadaFecha.VincularDameDiasNac(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);

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