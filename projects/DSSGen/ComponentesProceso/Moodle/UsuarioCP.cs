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
            UsuarioCAD usCAD = new UsuarioCAD(session);
            UsuarioCEN usCEN = new UsuarioCEN(usCAD);
            try
            {
                SessionInitializeTransaction();
                result=usCEN.ChangePassword(user, pass, newpass);

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
