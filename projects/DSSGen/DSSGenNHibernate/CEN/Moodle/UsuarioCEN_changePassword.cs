
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace DSSGenNHibernate.CEN.Moodle
{
public partial class UsuarioCEN
{
public bool ChangePassword (string usuario, string pass, string newpass)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Usuario_changePassword) ENABLED START*/

        // Write here your custom code...
        bool result = false;
        UsuarioEN us = _IUsuarioCAD.ReadOID (usuario);

        //Comprobar si existe el usuario
        if (us == null)
                return false;

        //Comparar contrase�as
        if (Auxiliar.Encrypter.Verificar (pass, us.Password)) {
                us.Password = newpass;
                result = true;
        }

        return result;



        /*PROTECTED REGION END*/
}
}
}
