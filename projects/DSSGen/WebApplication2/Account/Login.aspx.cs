using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUtilities;
using Fachadas.Moodle;

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
                if (MySession.Current.IsLoged())
                {
                    Linker link = new Linker(false);
                    link.Redirect(Response,link.Default());
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
                FachadaLogin fachada = new FachadaLogin();
                Authenticated = fachada.Login(LoginUser.UserName, LoginUser.Password);
            }
            catch (Exception excep)
            {
                Notification.Notify(Response,excep.Message);
                return;
            }

            //Actualizar el valor de autentificación
            e.Authenticated = Authenticated;

            //Se crea la sesión si se ha autentificado el usuario
            if (Authenticated)
                LoginUser_LoggedIn(sender, e);

            else
                Notification.Notify(Response,"El usuario o la contraseña son incorrectos");
        }

        //Una vez logueado, entrar en la página principal
        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response,link.Default());
        }
    }
}
