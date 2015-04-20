using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Excepciones;


namespace ComponentesProceso.Moodle
{
    //Componente de proceso para permitir el login
    public class LoginCP : BasicCP
    {
        //Constructor
        public LoginCP() : base() { }

        //Constructor con sesión
        public LoginCP(ISession sesion) : base(sesion) { }

        //Devolver un objeto que contenga el usuario logueado
        public UsuarioEN login(string user, string pass)
        {
            UsuarioEN rol = null;

            try
            {
                SessionInitializeTransaction();

                //Intentar loguear como usuario normal
                rol = loginUsuario(user, pass);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

            //No se pudo realizar login correctamente
            return rol;
        }

        //Método para realizar login para un usuario normal
        private UsuarioEN loginUsuario(string user, string pass)
        {
            //Probar el login para un usuario normal
            UsuarioCAD usCAD = new UsuarioCAD(session);
            UsuarioCEN usCEN = new UsuarioCEN(usCAD);

            if (usCEN.Login(user, pass))
            {
                //Comprobar si es un alumno
                AlumnoCAD aluCAD = new AlumnoCAD(session);
                AlumnoCEN aluCEN = new AlumnoCEN(aluCAD);
                AlumnoEN alu = aluCEN.ReadOID(user);
                if (alu != null)
                    return alu;

                //Comprobar si es un profesor
                ProfesorCAD profCAD = new ProfesorCAD(session);
                ProfesorCEN profCEN = new ProfesorCEN(profCAD);
                ProfesorEN prof = profCEN.ReadOID(user);
                if (prof != null)
                    return prof;

                //Comprobar si es un administrador
                AdministradorCAD adminCAD = new AdministradorCAD(session);
                AdministradorCEN adminCEN = new AdministradorCEN(adminCAD);
                AdministradorEN admin = adminCEN.ReadOID(user);
                if (admin != null)
                    return admin;

                //Error al recibir los datos
                throw new ExcepcionAccesoDatos();
            }

            //Devolver null si no es un usuario normal
            return null;
        }
    }
}
