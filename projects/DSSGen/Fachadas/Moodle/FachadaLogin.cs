using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    //Clase utilizada para abstraer el proceso de login sobre distintos roles
    public class FachadaLogin
    {
        //Método login que devuelve una referencia a un objeto que contendrá un profesor, alumno o admin
        public static Object login(String user, String pass)
        {
            //Intentar loguear como usuario normal
            Object rol = loginUsuario(user, pass);
            if (rol != null)
                return rol;

            //Probar el login para un administrador
            rol = loginAdministrador(user, pass);
            if (rol != null)
                return rol;

            //No se pudo realizar login correctamente
            return null;
        }

        //Método para realizar login para un usuario normal
        private static Object loginUsuario(string user, string pass)
        {
            //Probar el login para un usuario normal
            UsuarioCEN usCEN = new UsuarioCEN();
            if (usCEN.Login(user, pass))
            {
                //Comprobar si es un alumno
                AlumnoCEN aluCEN = new AlumnoCEN();
                AlumnoEN alu = aluCEN.ReadOID(user);
                if (alu != null)
                    return alu;

                //Comprobar si es un profesor
                ProfesorCEN profCEN = new ProfesorCEN();
                ProfesorEN prof = profCEN.ReadOID(user);
                if (prof != null)
                    return prof;

                //Error al recibir los datos
                throw new Excepciones.ExcepcionAccesoDatos();
            }

            //Devolver null si no es un usuario normal
            return null;
        }

        //Método para realizar el login como administrador
        private static Object loginAdministrador(string user, string pass)
        {
            AdministradorCEN adminCEN = new AdministradorCEN();

            //Probar el login para un administrador
            if (adminCEN.Login(user, pass))
            {
                AdministradorEN admin = adminCEN.ReadOID(user);
                if (admin != null)
                    return admin;

                //Error al recibir los datos
                throw new Excepciones.ExcepcionAccesoDatos();
            }

            //Devolver null si no es un admin
            return null;
        }
    }
}
