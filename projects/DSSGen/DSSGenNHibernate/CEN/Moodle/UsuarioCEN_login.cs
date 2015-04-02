
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using Auxiliar;

namespace DSSGenNHibernate.CEN.Moodle
{
public partial class UsuarioCEN
{
public bool Login (string usuario, string pass)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Usuario_login) ENABLED START*/

        // Write here your custom code...
        bool result = false;
        UsuarioEN us = _IUsuarioCAD.ReadOID (usuario);

        //Comprobar si existe el usuario
        if (us == null)
                return false;

        //Comparar contrase�as
        if (Encrypter.Verificar (pass, us.Password))
                result = true;
        return result;

        /*PROTECTED REGION END*/
}
}
}
