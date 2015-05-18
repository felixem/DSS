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
    public partial class crear_profesor : BasicPage
    {
        //Creo la fachada
        FachadaProfesor profesor;
        FachadaFecha fachadaFecha;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            profesor = new FachadaProfesor();
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
        protected void Button_RegProf_Click(Object sender, EventArgs e)
        {
            //Recogo los datos
            string nombre = TextBox_NomProf.Text;
            string apellidos = TextBox_ApellProf.Text;
            string pass = TextBox_ContProf.Text;
            DateTime fecha = DateTime.Parse("" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text);
            string dni = TextBox_DNIProf.Text;
            string email = TextBox_EmailProf.Text;
            string cod = TextBox_CodProf.Text;

            //Llamo al metodo que registra al profesor
            if (profesor.RegistrarProfesor(nombre, apellidos, pass, fecha, dni, email, 
                Convert.ToInt32(cod)))
            {
                Notification.Current.NotifyLastNotification(Response);
                this.Clean();
            }
            else
            {
                Notification.Current.NotifyLastNotification(Response);
            }
        }

        //Método para borrar
        private void Clean()
        {
            TextBox_NomProf.Text = "";
            TextBox_ApellProf.Text = "";
            TextBox_ContProf.Text = "";
            TextBox_VContProf.Text = "";
            TextBox_DNIProf.Text = "";
            TextBox_EmailProf.Text = "";
            TextBox_CodProf.Text = "";
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

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}