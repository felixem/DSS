

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
public partial class EvaluacionCEN
{
private IEvaluacionCAD _IEvaluacionCAD;

public EvaluacionCEN()
{
        this._IEvaluacionCAD = new EvaluacionCAD ();
}

public EvaluacionCEN(IEvaluacionCAD _IEvaluacionCAD)
{
        this._IEvaluacionCAD = _IEvaluacionCAD;
}

public IEvaluacionCAD get_IEvaluacionCAD ()
{
        return this._IEvaluacionCAD;
}

public int New_ (string p_nombre, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_abierta, int p_anyo_academico)
{
        EvaluacionEN evaluacionEN = null;
        int oid;

        //Initialized EvaluacionEN
        evaluacionEN = new EvaluacionEN ();
        evaluacionEN.Nombre = p_nombre;

        evaluacionEN.Fecha_inicio = p_fecha_inicio;

        evaluacionEN.Fecha_fin = p_fecha_fin;

        evaluacionEN.Abierta = p_abierta;


        if (p_anyo_academico != -1) {
                evaluacionEN.Anyo_academico = new DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN ();
                evaluacionEN.Anyo_academico.Id = p_anyo_academico;
        }

        //Call to EvaluacionCAD

        oid = _IEvaluacionCAD.New_ (evaluacionEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_abierta)
{
        EvaluacionEN evaluacionEN = null;

        //Initialized EvaluacionEN
        evaluacionEN = new EvaluacionEN ();
        evaluacionEN.Id = p_oid;
        evaluacionEN.Nombre = p_nombre;
        evaluacionEN.Fecha_inicio = p_fecha_inicio;
        evaluacionEN.Fecha_fin = p_fecha_fin;
        evaluacionEN.Abierta = p_abierta;
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Modify (evaluacionEN);
}

public void Destroy (int id)
{
        _IEvaluacionCAD.Destroy (id);
}

public System.Collections.Generic.IList<EvaluacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EvaluacionEN> list = null;

        list = _IEvaluacionCAD.ReadAll (first, size);
        return list;
}
public EvaluacionEN ReadOID (int id)
{
        EvaluacionEN evaluacionEN = null;

        evaluacionEN = _IEvaluacionCAD.ReadOID (id);
        return evaluacionEN;
}

public long ReadCantidad ()
{
        return _IEvaluacionCAD.ReadCantidad ();
}
public void Relationer_anyo_academico (int p_evaluacion, int p_anyoacademico)
{
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Relationer_anyo_academico (p_evaluacion, p_anyoacademico);
}
public void Relationer_expedientes (int p_evaluacion, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Relationer_expedientes (p_evaluacion, p_expedienteevaluacion);
}
public void Relationer_sistemas_evaluacion (int p_evaluacion, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Relationer_sistemas_evaluacion (p_evaluacion, p_sistemaevaluacion);
}
public void Unrelationer_anyo_academico (int p_evaluacion, int p_anyoacademico)
{
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Unrelationer_anyo_academico (p_evaluacion, p_anyoacademico);
}
public void Unrelationer_expedientes (int p_evaluacion, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Unrelationer_expedientes (p_evaluacion, p_expedienteevaluacion);
}
public void Unrelationer_sistemas_evaluacion (int p_evaluacion, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        //Call to EvaluacionCAD

        _IEvaluacionCAD.Unrelationer_sistemas_evaluacion (p_evaluacion, p_sistemaevaluacion);
}
}
}
