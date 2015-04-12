

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
public partial class AnyoAcademicoCEN
{
private IAnyoAcademicoCAD _IAnyoAcademicoCAD;

public AnyoAcademicoCEN()
{
        this._IAnyoAcademicoCAD = new AnyoAcademicoCAD ();
}

public AnyoAcademicoCEN(IAnyoAcademicoCAD _IAnyoAcademicoCAD)
{
        this._IAnyoAcademicoCAD = _IAnyoAcademicoCAD;
}

public IAnyoAcademicoCAD get_IAnyoAcademicoCAD ()
{
        return this._IAnyoAcademicoCAD;
}

public int New_ (string p_anyo, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_finalizado)
{
        AnyoAcademicoEN anyoAcademicoEN = null;
        int oid;

        //Initialized AnyoAcademicoEN
        anyoAcademicoEN = new AnyoAcademicoEN ();
        anyoAcademicoEN.Anyo = p_anyo;

        anyoAcademicoEN.Fecha_inicio = p_fecha_inicio;

        anyoAcademicoEN.Fecha_fin = p_fecha_fin;

        anyoAcademicoEN.Finalizado = p_finalizado;

        //Call to AnyoAcademicoCAD

        oid = _IAnyoAcademicoCAD.New_ (anyoAcademicoEN);
        return oid;
}

public void Modify (int p_oid, string p_anyo, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_finalizado)
{
        AnyoAcademicoEN anyoAcademicoEN = null;

        //Initialized AnyoAcademicoEN
        anyoAcademicoEN = new AnyoAcademicoEN ();
        anyoAcademicoEN.Id = p_oid;
        anyoAcademicoEN.Anyo = p_anyo;
        anyoAcademicoEN.Fecha_inicio = p_fecha_inicio;
        anyoAcademicoEN.Fecha_fin = p_fecha_fin;
        anyoAcademicoEN.Finalizado = p_finalizado;
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Modify (anyoAcademicoEN);
}

public void Destroy (int id)
{
        _IAnyoAcademicoCAD.Destroy (id);
}

public System.Collections.Generic.IList<AnyoAcademicoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AnyoAcademicoEN> list = null;

        list = _IAnyoAcademicoCAD.ReadAll (first, size);
        return list;
}
public AnyoAcademicoEN ReadOID (int id)
{
        AnyoAcademicoEN anyoAcademicoEN = null;

        anyoAcademicoEN = _IAnyoAcademicoCAD.ReadOID (id);
        return anyoAcademicoEN;
}

public long ReadCantidad ()
{
        return _IAnyoAcademicoCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN ReadCod (string anyo)
{
        return _IAnyoAcademicoCAD.ReadCod (anyo);
}
public void Relationer_asignaturas (int p_anyoacademico, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Relationer_asignaturas (p_anyoacademico, p_asignaturaanyo);
}
public void Relationer_evaluaciones (int p_anyoacademico, System.Collections.Generic.IList<int> p_evaluacion)
{
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Relationer_evaluaciones (p_anyoacademico, p_evaluacion);
}
public void Relationer_expedientes_anyo (int p_anyoacademico, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Relationer_expedientes_anyo (p_anyoacademico, p_expedienteanyo);
}
public void Unrelationer_asignaturas (int p_anyoacademico, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Unrelationer_asignaturas (p_anyoacademico, p_asignaturaanyo);
}
public void Unrelationer_evaluaciones (int p_anyoacademico, System.Collections.Generic.IList<int> p_evaluacion)
{
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Unrelationer_evaluaciones (p_anyoacademico, p_evaluacion);
}
public void Unrelationer_expedientes_anyo (int p_anyoacademico, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        //Call to AnyoAcademicoCAD

        _IAnyoAcademicoCAD.Unrelationer_expedientes_anyo (p_anyoacademico, p_expedienteanyo);
}
}
}
