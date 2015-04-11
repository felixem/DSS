

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
public partial class NotaCEN
{
private INotaCAD _INotaCAD;

public NotaCEN()
{
        this._INotaCAD = new NotaCAD ();
}

public NotaCEN(INotaCAD _INotaCAD)
{
        this._INotaCAD = _INotaCAD;
}

public INotaCAD get_INotaCAD ()
{
        return this._INotaCAD;
}

public int New_ (string p_nombre, string p_abreviatura, int p_ponderacion)
{
        NotaEN notaEN = null;
        int oid;

        //Initialized NotaEN
        notaEN = new NotaEN ();
        notaEN.Nombre = p_nombre;

        notaEN.Abreviatura = p_abreviatura;

        notaEN.Ponderacion = p_ponderacion;

        //Call to NotaCAD

        oid = _INotaCAD.New_ (notaEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre, string p_abreviatura, int p_ponderacion)
{
        NotaEN notaEN = null;

        //Initialized NotaEN
        notaEN = new NotaEN ();
        notaEN.Id = p_oid;
        notaEN.Nombre = p_nombre;
        notaEN.Abreviatura = p_abreviatura;
        notaEN.Ponderacion = p_ponderacion;
        //Call to NotaCAD

        _INotaCAD.Modify (notaEN);
}

public void Destroy (int id)
{
        _INotaCAD.Destroy (id);
}

public long ReadCantidad ()
{
        return _INotaCAD.ReadCantidad ();
}
public System.Collections.Generic.IList<NotaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotaEN> list = null;

        list = _INotaCAD.ReadAll (first, size);
        return list;
}
public NotaEN ReadOID (int id)
{
        NotaEN notaEN = null;

        notaEN = _INotaCAD.ReadOID (id);
        return notaEN;
}
}
}
