using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fachadas.Moodle;
using WebUtilities;

namespace WebApplication2.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        //Creamos la fachada
        FachadaPassword fachadapass;

        protected void Page_Load(object sender, EventArgs e)
        {
            fachadapass = new FachadaPassword();
            if (!MySession.Current.IsLoged())
            {
                Linker link = new Linker(false);
                link.Redirect(Response, link.Default());
                return;
            }
            if (!IsPostBack)
            {

                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
                fachadapass = new FachadaPassword();
            }
        }
        //Metodo que llama el botón ChangePasswordPushButton
        protected void Button_Change_Click(object sender, EventArgs e) {

            string user= MySession.Current.Usuario.Email;
            string pass = T_Anterior.Text;
            string npass= T_nueva.Text;
            bool verificado = false;
            try
            {
                verificado = fachadapass.ChangePass(user, pass, npass);

            }
            catch (Exception) {
                verificado = false;
            }
            //Compruebo si se han almacenado los cambios
            if (verificado)
            {
                
                //Redirigir a la página password cambiado
                Linker link = new Linker(false);
                link.Redirect(Response, link.PassChanged());
            }
            else
            {
                Notification.Notify(Response,"La contraseña no ha podido ser modificada");
            }
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }


    }
}
