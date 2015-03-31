using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DSSGenNHibernate.EN.Moodle;
using Fachadas.Moodle;

namespace Classes
{
    public class MySession
    {
        // private constructor
        private MySession()
        {
            Usuario = null;
            Fecha_login = null;
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
        public bool login(String user, String pass)
        {
            //Llamar a la fachada de login para intentar actualizar la sesión con el login
            Object usuario = null;
            try
            {
                FachadaLogin fachada = new FachadaLogin();
                usuario = fachada.Login(user, pass);
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
            Usuario = usuario;
            Fecha_login = DateTime.Now;
            return true;
        }

        //Comprobar si está logueado
        public bool isLoged()
        {
            return Usuario != null;
        }

        //Comprobar si es un alumno
        public bool isAlumno()
        {
            return Usuario.GetType() == typeof(AlumnoEN);
        }

        //Comprobar si es un profesor
        public bool isProfesor()
        {
            return Usuario.GetType() == typeof(ProfesorEN);
        }

        //Comprobar si es un admin
        public bool isAdministrador()
        {
            return Usuario.GetType() == typeof(AdministradorEN);
        }

        // Propiedades de sesión
        public Object Usuario { get; set; }
        public DateTime? Fecha_login { get; set; }
    }
}
