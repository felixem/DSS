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
    public partial class ChangePassword : BasicPage
    {
        //Creamos la fachada
        FachadaUsuario fachadapass;

        protected void Page_Load(object sender, EventArgs e)
        {
            fachadapass = new FachadaUsuario();
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }
        //Metodo que llama el botón ChangePasswordPushButton
        protected void Button_Change_Click(object sender, EventArgs e) {

            string user= MySession.Current.Usuario.Email;
            string pass = T_Anterior.Text;
            string npass= T_nueva.Text;

            //Cambiar la contraseña
            fachadapass.ChangePass(user, pass, npass);
            Notification.Current.NotifyLastNotification(Response);
        }

        protected void Cancelar(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}
