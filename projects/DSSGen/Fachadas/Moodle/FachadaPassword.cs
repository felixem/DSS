﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;
using WebUtilities;

namespace Fachadas.Moodle
{
    public class FachadaPassword
    {
        public bool ChangePass(String user, String pass, String npass) {
            bool result = false;
            try
            {
                UsuarioCP passCP = new UsuarioCP();
                result=passCP.CambiarPassword(user, pass, npass);
            }
            catch (Exception ex) {
                throw ex;
            }
            return result;
        }
    }
}
