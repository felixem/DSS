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
        public static MySession login(String user, String pass)
        {
            //Probar el login para un usuario normal
            UsuarioCEN usCEN = new UsuarioCEN();
            if (usCEN.Login(user, pass))
            {
                //Comprobar si es un alumno
                AlumnoCEN aluCEN = new AlumnoCEN();
                AlumnoEN alu = aluCEN.ReadOID(user);
                if (alu != null)
                {
                    MySession session = new MySession();
                    session.Usuario = alu;
                    HttpContext.Current.Session["__MySession__"] = session;
                    return session;
                }

                //Comprobar si es un profesor
                ProfesorCEN profCEN = new ProfesorCEN();
                ProfesorEN prof = profCEN.ReadOID(user);
                if (prof != null)
                {
                    MySession session = new MySession();
                    session.Usuario = prof;
                    HttpContext.Current.Session["__MySession__"] = session;
                    return session;
                }

                //Error al realizar login
                throw new excepciones.ExcepcionLoginIncorrecto();
            }

            //Probar el login para un administrador
            AdministradorCEN adminCEN = new AdministradorCEN();
            AdministradorEN admin = adminCEN.ReadOID(user);
            if (admin != null)
            {
                MySession session = new MySession();
                session.Usuario = admin;
                HttpContext.Current.Session["__MySession__"] = session;
                return session;
            }

            //Error al realizar login
            throw new excepciones.ExcepcionLoginIncorrecto();
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
