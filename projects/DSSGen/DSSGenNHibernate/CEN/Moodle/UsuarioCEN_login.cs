
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
public bool Login (string usuario, string pass)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Usuario_login) ENABLED START*/

        // Write here your custom code...
    bool result = false;
    UsuarioEN admin = _IUsuarioCAD.ReadOID(usuario);
    if (admin.Password.Equals(pass))
        result = true;
    return result;
        /*PROTECTED REGION END*/
}
}
}
