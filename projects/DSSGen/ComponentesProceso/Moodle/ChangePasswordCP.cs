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
    public class ChangePasswordCP : BasicCP
    {
        public ChangePasswordCP() : base(){  }

        public ChangePasswordCP(ISession sesion) : base(sesion){  }

        public bool change(string user, string pass, string newpass){
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
