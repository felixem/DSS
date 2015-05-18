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
    //Componente de proceso para la clase Usuario
    public class UsuarioCP : BasicCP
    {
        public UsuarioCP() : base(){  }

        public UsuarioCP(ISession sesion) : base(sesion){  }

        public bool CambiarPassword(string user, string pass, string newpass){
            bool result = false;

            try
            {
                SessionInitializeTransaction();

                UsuarioCAD usCAD = new UsuarioCAD(session);
                UsuarioCEN usCEN = new UsuarioCEN(usCAD);

                //Comprobar la existencia del usuario
                if (usCEN.ReadOID(user) == null)
                    throw new Exception("El usuario no existe");

                //Comprobar si se ha realizado correctamente el cambio del password
                result=usCEN.ChangePassword(user, pass, newpass);
                if (result == false)
                    throw new Exception("La contraseña anterior no coincide");

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
            return result;
        }
    }
}
