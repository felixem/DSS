using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DSSGenNHibernate.EN.Moodle;

using Fachadas.WebUtilities;

namespace WebApplication2
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        MySession sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion = MySession.Current;
            if (!IsPostBack)
            {
                VisibilidadControles();
            }
        }

        //Visibilidad de los controles
        private void VisibilidadControles()
        {
            if (sesion.IsLoged())
            {
                UsuarioEN usuario = sesion.Usuario;

                user_image.Visible = true;
                user_image.ImageUrl = ResourceFinder.FotoSession(sesion);
                user_label.Visible = true;
                user_label.Text = usuario.Nombre + " " + usuario.Apellidos;
                Button_Desloguear.Visible = true;
            }
            else
            {
                user_image.Visible = false;
                user_label.Visible = false;
                Button_Desloguear.Visible = false;
            }
        }

        //Manejador para efectuar el deslogueo
        protected void Button_Desloguear_Click(object sender, EventArgs args)
        {
            sesion.Exit();
            Response.Write("<script>window.alert('Has cerrado sesión correctamente');</script>");
            VisibilidadControles();
        }
    }
}
