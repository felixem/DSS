

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
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public string New_ (string p_nick, String p_password, string p_nombre, string p_descripcion)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nick = p_nick;

        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        administradorEN.Nombre = p_nombre;

        administradorEN.Descripcion = p_descripcion;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Modify (string p_oid, String p_password, string p_nombre, string p_descripcion)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Nick = p_oid;
        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        administradorEN.Nombre = p_nombre;
        administradorEN.Descripcion = p_descripcion;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (string nick)
{
        _IAdministradorCAD.Destroy (nick);
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.ReadAll (first, size);
        return list;
}
public AdministradorEN ReadOID (string nick)
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.ReadOID (nick);
        return administradorEN;
}
}
}
