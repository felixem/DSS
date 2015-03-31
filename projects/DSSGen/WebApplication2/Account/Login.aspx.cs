using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;

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
                if (MySession.Current.isLoged())
                {
                    Response.Redirect(Linker.Default());
                    return;
                }

                Page.SetFocus(Visor);
            }
        }

        //Autentificar al usuario
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            
            //Comprobar si la contraseña es correcta
            try
            {
                MySession sesion = MySession.Current;
                Authenticated = sesion.login(LoginUser.UserName, LoginUser.Password);
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
                LoginUser_LoggedIn(sender, e);

            else
                Response.Write("<script>window.alert('El usuario o la contraseña son incorrectos');</script>");
        }

        //Una vez logueado, entrar en la página principal
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect(Linker.Default());
        }
    }
}
