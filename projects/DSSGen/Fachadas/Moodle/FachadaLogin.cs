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
    //Clase utilizada para abstraer el proceso de login sobre distintos roles
    public class FachadaLogin
    {
        //Actualizar una sesión haciendo login
        public bool Login(String user, String pass)
        {
            MySession sesion = MySession.Current;

            //Llamar a al cp de login 
            UsuarioEN usuario = null;
            try
            {
                LoginCP loginCP = new LoginCP();
                usuario = loginCP.login(user, pass);
            }

            //Relanzar excepciones producidas
            catch (Exception ex)
            {
                throw ex;
            }

            //Comprobar si se ha realizado correctamente el login
            if (usuario == null)
                return false;

            //Login realizado correctamente
            sesion.Usuario = usuario;
            sesion.Fecha_login = DateTime.Now;
            return true;
        }

        //Limpiar la sesión
        public void Exit()
        {
            MySession sesion = MySession.Current;
            sesion.Clear();
        }

    }
}
