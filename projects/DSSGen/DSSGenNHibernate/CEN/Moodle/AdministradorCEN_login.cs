
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
public partial class AdministradorCEN
{
public bool Login (string usuario, string pass)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Administrador_login) ENABLED START*/

        // Write here your custom code...
        bool result = false;
        AdministradorEN admin = _IAdministradorCAD.ReadOID (usuario);

        //Administrador no encontrado
        if (admin == null)
                return false;

        //Comparar contrase�a
        if (Encrypter.Verificar (pass, admin.Password))
                result = true;
        return result;
        /*PROTECTED REGION END*/
}
}
}
