

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

public string New_ (int p_cod_administrador, string p_ocupacion, string p_email, string p_dni, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Cod_administrador = p_cod_administrador;

        administradorEN.Ocupacion = p_ocupacion;

        administradorEN.Email = p_email;

        administradorEN.Dni = p_dni;

        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Fecha_nacimiento = p_fecha_nacimiento;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Modify (string p_oid, int p_cod_administrador, string p_ocupacion, string p_dni, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_oid;
        administradorEN.Cod_administrador = p_cod_administrador;
        administradorEN.Ocupacion = p_ocupacion;
        administradorEN.Dni = p_dni;
        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        administradorEN.Nombre = p_nombre;
        administradorEN.Apellidos = p_apellidos;
        administradorEN.Fecha_nacimiento = p_fecha_nacimiento;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (string email)
{
        _IAdministradorCAD.Destroy (email);
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.ReadAll (first, size);
        return list;
}
public AdministradorEN ReadOID (string email)
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.ReadOID (email);
        return administradorEN;
}

public long ReadCantidad ()
{
        return _IAdministradorCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.AdministradorEN ReadCod (int cod)
{
        return _IAdministradorCAD.ReadCod (cod);
}
}
}
