using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;
using WebUtilities;

namespace Fachadas.Moodle
{
    public class FachadaUsuario
    {
        public bool ChangePass(String user, String pass, String npass) {
            bool result = false;
            try
            {
                UsuarioCP passCP = new UsuarioCP();
                result=passCP.CambiarPassword(user, pass, npass);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: La contraseña no ha podido ser cambiada. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("La contraseña ha sido cambiada");
            return true;
        }
    }
}
