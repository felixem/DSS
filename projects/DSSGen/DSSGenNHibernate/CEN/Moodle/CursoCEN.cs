

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
public partial class CursoCEN
{
private ICursoCAD _ICursoCAD;

public CursoCEN()
{
        this._ICursoCAD = new CursoCAD ();
}

public CursoCEN(ICursoCAD _ICursoCAD)
{
        this._ICursoCAD = _ICursoCAD;
}

public ICursoCAD get_ICursoCAD ()
{
        return this._ICursoCAD;
}

public int New_ (string p_cod_curso, string p_nombre)
{
        CursoEN cursoEN = null;
        int oid;

        //Initialized CursoEN
        cursoEN = new CursoEN ();
        cursoEN.Cod_curso = p_cod_curso;

        cursoEN.Nombre = p_nombre;

        //Call to CursoCAD

        oid = _ICursoCAD.New_ (cursoEN);
        return oid;
}

public void Modify (int p_oid, string p_cod_curso, string p_nombre)
{
        CursoEN cursoEN = null;

        //Initialized CursoEN
        cursoEN = new CursoEN ();
        cursoEN.Id = p_oid;
        cursoEN.Cod_curso = p_cod_curso;
        cursoEN.Nombre = p_nombre;
        //Call to CursoCAD

        _ICursoCAD.Modify (cursoEN);
}

public void Destroy (int id)
{
        _ICursoCAD.Destroy (id);
}

public System.Collections.Generic.IList<CursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CursoEN> list = null;

        list = _ICursoCAD.ReadAll (first, size);
        return list;
}
public CursoEN ReadOID (int id)
{
        CursoEN cursoEN = null;

        cursoEN = _ICursoCAD.ReadOID (id);
        return cursoEN;
}

public long ReadCantidad ()
{
        return _ICursoCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.CursoEN ReadCod (string cod)
{
        return _ICursoCAD.ReadCod (cod);
}
public void Relationer_asignaturas (int p_curso, System.Collections.Generic.IList<int> p_asignatura)
{
        //Call to CursoCAD

        _ICursoCAD.Relationer_asignaturas (p_curso, p_asignatura);
}
public void Unrelationer_asignaturas (int p_curso, System.Collections.Generic.IList<int> p_asignatura)
{
        //Call to CursoCAD

        _ICursoCAD.Unrelationer_asignaturas (p_curso, p_asignatura);
}
}
}
