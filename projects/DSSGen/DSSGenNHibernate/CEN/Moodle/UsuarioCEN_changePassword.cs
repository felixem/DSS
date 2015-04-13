
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
    try
    {
        // Write here your custom code...
        bool result = false;
        UsuarioEN us = _IUsuarioCAD.ReadOID(usuario);

        //Comprobar si existe el usuario
        if (us == null)
            return false;

        //Comparar contrase�as
        if (Auxiliar.Encrypter.Verificar(pass, us.Password))
        {
            us.Password = newpass;
            UsuarioCEN Modificar = new UsuarioCEN();
            Modificar.Modify(us.Email, us.Dni, us.Password, us.Nombre, us.Apellidos, us.Fecha_nacimiento);
            result = true;
        }
        return result;
    }
    catch (Exception ex) {
        return false;
    }

        



        /*PROTECTED REGION END*/
}
}
}
