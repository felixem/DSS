using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.GrupoTrabajo
{
    public partial class crear_grupotrabajo : System.Web.UI.Page
    {
        FachadaGrupoTrabajo fachada;
        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaGrupoTrabajo();
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Método que llama el botón para crear un grupo de trabajo
        protected void Button_CrearGrupo_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string codigo = TextBox_CodGrupo.Text;
            string nombre = TextBox_NomGrupo.Text;
            string descripcion = TextBox_DescGrupo.Text;
            string password = TextBox_Pass.Text;
            string capacidad = TextBox_Capacidad.Text;

            //Crear la asignatura
            if (fachada.CrearGrupoTrabajo(codigo,nombre,descripcion,password,Int32.Parse(capacidad),0))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Response.Write("<script>window.alert('El grupo de trabajo no ha podido ser creado');</script>");
            }
        }
    
        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            TextBox_CodGrupo.Text = "";
            TextBox_NomGrupo.Text = "";
            TextBox_DescGrupo.Text = "";
            TextBox_Pass.Text = "";
            TextBox_Capacidad.Text = "";
        }
    
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Asignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Manejador cuando cambie la selección en el drop down list
        protected void DropDownList_Anyos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}