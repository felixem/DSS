using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Account
{
    public partial class Login : System.Web.UI.Page
    {
        //Al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Devolver a la página principal si ya se está logueado
                if (Session["usuario"] != null)
                {
                    Response.Redirect("~/inicio.aspx");
                    return;
                }

                Page.SetFocus(Visor);
                RegisterHyperLink.NavigateUrl = "Register.aspx";
            }
        }

        //Autentificar al usuario
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            
            //Crear el usuario
            ENUsuario usuario = new ENUsuario();
            usuario.Nick = LoginUser.UserName;
            usuario.Password = LoginUser.Password;

            //Comprobar si la contraseña es correcta
            try
            {
                Authenticated = usuario.LogearUsuario();
            }
            catch (Exception excep)
            {
                Response.Write("<script>window.alert('"+excep.Message+"');</script>");
                return;
            }

            //Actualizar el valor de autentificación
            e.Authenticated = Authenticated;

            //Se crea la sesión si se ha autentificado el usuario
            if (Authenticated)
            {
                usuario.RecibirDatos();
                Session.Add("usuario", usuario);
                Session.Add("inicio", "ON");
                LoginUser_LoggedIn(sender, e);
            }

            else
                Response.Write("<script>window.alert('El usuario o la contraseña son incorrectos');</script>");
        }

        //Una vez logueado, entrar en la página principal
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/inicio.aspx");
        }
    }
}
