

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
public partial class UsuarioComunCEN
{
private IUsuarioComunCAD _IUsuarioComunCAD;

public UsuarioComunCEN()
{
        this._IUsuarioComunCAD = new UsuarioComunCAD ();
}

public UsuarioComunCEN(IUsuarioComunCAD _IUsuarioComunCAD)
{
        this._IUsuarioComunCAD = _IUsuarioComunCAD;
}

public IUsuarioComunCAD get_IUsuarioComunCAD ()
{
        return this._IUsuarioComunCAD;
}

public string New_ (string p_email, string p_dni, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        UsuarioComunEN usuarioComunEN = null;
        string oid;

        //Initialized UsuarioComunEN
        usuarioComunEN = new UsuarioComunEN ();
        usuarioComunEN.Email = p_email;

        usuarioComunEN.Dni = p_dni;

        usuarioComunEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioComunEN.Nombre = p_nombre;

        usuarioComunEN.Apellidos = p_apellidos;

        usuarioComunEN.Fecha_nacimiento = p_fecha_nacimiento;

        //Call to UsuarioComunCAD

        oid = _IUsuarioComunCAD.New_ (usuarioComunEN);
        return oid;
}

public void Modify (string p_oid, string p_dni, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        UsuarioComunEN usuarioComunEN = null;

        //Initialized UsuarioComunEN
        usuarioComunEN = new UsuarioComunEN ();
        usuarioComunEN.Email = p_oid;
        usuarioComunEN.Dni = p_dni;
        usuarioComunEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioComunEN.Nombre = p_nombre;
        usuarioComunEN.Apellidos = p_apellidos;
        usuarioComunEN.Fecha_nacimiento = p_fecha_nacimiento;
        //Call to UsuarioComunCAD

        _IUsuarioComunCAD.Modify (usuarioComunEN);
}

public System.Collections.Generic.IList<UsuarioComunEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioComunEN> list = null;

        list = _IUsuarioComunCAD.ReadAll (first, size);
        return list;
}
public UsuarioComunEN ReadOID (string email)
{
        UsuarioComunEN usuarioComunEN = null;

        usuarioComunEN = _IUsuarioComunCAD.ReadOID (email);
        return usuarioComunEN;
}

public void Relationer_mensajes (string p_usuariocomun, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to UsuarioComunCAD

        _IUsuarioComunCAD.Relationer_mensajes (p_usuariocomun, p_mensaje);
}
public void Unrelationer_mensajes (string p_usuariocomun, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to UsuarioComunCAD

        _IUsuarioComunCAD.Unrelationer_mensajes (p_usuariocomun, p_mensaje);
}
}
}
