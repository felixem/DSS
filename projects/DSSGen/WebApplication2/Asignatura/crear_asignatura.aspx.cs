using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Asignatura
{
    public partial class crear_asignatura : System.Web.UI.Page
    {
        FachadaAsignatura fachada;
        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaAsignatura();
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Método que llama el botón para crear una asignatura
        protected void Button_CrearAsig_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string codigo = TextBox_CodAsig.Text;
            string nombre = TextBox_NomAsig.Text;
            string descripcion = TextBox_DescAsig.Text;
            bool optativo = CheckBox_OptativaAsig.Checked;
            bool vigente = CheckBox_VigenteAsig.Checked;

            //Crear la asignatura
            if (fachada.CrearAsignatura(codigo,nombre,descripcion,optativo,vigente))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Response.Write("<script>window.alert('La asignatura no ha podido ser creada');</script>");
            }
        }
    
        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            TextBox_CodAsig.Text = "";
            TextBox_NomAsig.Text = "";
            TextBox_DescAsig.Text = "";
            CheckBox_OptativaAsig.Checked = false;
            CheckBox_VigenteAsig.Checked = true;
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