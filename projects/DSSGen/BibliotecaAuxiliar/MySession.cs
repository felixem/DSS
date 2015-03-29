using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;

namespace BibliotecaAuxiliar
{
    public class MySession
    {
        // private constructor
        private MySession()
        {
        }

        // Obtener la sesión actual.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        //Obtener una sesión haciendo login
        public static MySession login(String user, String pass)
        {
            //Probar el login para un usuario normal
            UsuarioCEN usCEN = new UsuarioCEN();
            if (usCEN.Login(user, pass))
            {
                UsuarioEN us = usCEN.ReadEmail(user);
                MySession session = new MySession();
                session.Usuario = us;
                HttpContext.Current.Session["__MySession__"] = session;
                return session;
            }
        }

        // Propiedades de sesión
        public Object Usuario { get; set; }
        public DateTime Fecha_login { get; set; }
    }
}
