

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
public partial class MensajeCEN
{
private IMensajeCAD _IMensajeCAD;

public MensajeCEN()
{
        this._IMensajeCAD = new MensajeCAD ();
}

public MensajeCEN(IMensajeCAD _IMensajeCAD)
{
        this._IMensajeCAD = _IMensajeCAD;
}

public IMensajeCAD get_IMensajeCAD ()
{
        return this._IMensajeCAD;
}

public int New_ (string p_contenido, Nullable<DateTime> p_fecha, bool p_respondido, int p_tutoria, string p_usuario)
{
        MensajeEN mensajeEN = null;
        int oid;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Contenido = p_contenido;

        mensajeEN.Fecha = p_fecha;

        mensajeEN.Respondido = p_respondido;


        if (p_tutoria != -1) {
                mensajeEN.Tutoria = new DSSGenNHibernate.EN.Moodle.TutoriaEN ();
                mensajeEN.Tutoria.Id = p_tutoria;
        }


        if (p_usuario != null) {
                mensajeEN.Usuario = new DSSGenNHibernate.EN.Moodle.UsuarioComunEN ();
                mensajeEN.Usuario.Email = p_usuario;
        }

        //Call to MensajeCAD

        oid = _IMensajeCAD.New_ (mensajeEN);
        return oid;
}

public void Modify (int p_oid, string p_contenido, Nullable<DateTime> p_fecha, bool p_respondido)
{
        MensajeEN mensajeEN = null;

        //Initialized MensajeEN
        mensajeEN = new MensajeEN ();
        mensajeEN.Id = p_oid;
        mensajeEN.Contenido = p_contenido;
        mensajeEN.Fecha = p_fecha;
        mensajeEN.Respondido = p_respondido;
        //Call to MensajeCAD

        _IMensajeCAD.Modify (mensajeEN);
}

public void Destroy (int id)
{
        _IMensajeCAD.Destroy (id);
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> list = null;

        list = _IMensajeCAD.ReadAll (first, size);
        return list;
}
public MensajeEN ReadOID (int id)
{
        MensajeEN mensajeEN = null;

        mensajeEN = _IMensajeCAD.ReadOID (id);
        return mensajeEN;
}

public long ReadCantidad ()
{
        return _IMensajeCAD.ReadCantidad ();
}
public void Relationer_tutoria (int p_mensaje, int p_tutoria)
{
        //Call to MensajeCAD

        _IMensajeCAD.Relationer_tutoria (p_mensaje, p_tutoria);
}
public void Relationer_usuario (int p_mensaje, string p_usuariocomun)
{
        //Call to MensajeCAD

        _IMensajeCAD.Relationer_usuario (p_mensaje, p_usuariocomun);
}
public void Unrelationer_tutoria (int p_mensaje, int p_tutoria)
{
        //Call to MensajeCAD

        _IMensajeCAD.Unrelationer_tutoria (p_mensaje, p_tutoria);
}
public void Unrelationer_usuario (int p_mensaje, string p_usuariocomun)
{
        //Call to MensajeCAD

        _IMensajeCAD.Unrelationer_usuario (p_mensaje, p_usuariocomun);
}
}
}
