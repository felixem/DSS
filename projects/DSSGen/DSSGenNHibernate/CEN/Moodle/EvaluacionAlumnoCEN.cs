

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
public partial class EvaluacionAlumnoCEN
{
private IEvaluacionAlumnoCAD _IEvaluacionAlumnoCAD;

public EvaluacionAlumnoCEN()
{
        this._IEvaluacionAlumnoCAD = new EvaluacionAlumnoCAD ();
}

public EvaluacionAlumnoCEN(IEvaluacionAlumnoCAD _IEvaluacionAlumnoCAD)
{
        this._IEvaluacionAlumnoCAD = _IEvaluacionAlumnoCAD;
}

public IEvaluacionAlumnoCAD get_IEvaluacionAlumnoCAD ()
{
        return this._IEvaluacionAlumnoCAD;
}

public int New_ (int p_sistema_evaluacion, int p_expediente_evaluacion)
{
        EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        int oid;

        //Initialized EvaluacionAlumnoEN
        evaluacionAlumnoEN = new EvaluacionAlumnoEN ();

        if (p_sistema_evaluacion != -1) {
                evaluacionAlumnoEN.Sistema_evaluacion = new DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ();
                evaluacionAlumnoEN.Sistema_evaluacion.Id = p_sistema_evaluacion;
        }


        if (p_expediente_evaluacion != -1) {
                evaluacionAlumnoEN.Expediente_evaluacion = new DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN ();
                evaluacionAlumnoEN.Expediente_evaluacion.Id = p_expediente_evaluacion;
        }

        //Call to EvaluacionAlumnoCAD

        oid = _IEvaluacionAlumnoCAD.New_ (evaluacionAlumnoEN);
        return oid;
}

public void Modify (int p_oid)
{
        EvaluacionAlumnoEN evaluacionAlumnoEN = null;

        //Initialized EvaluacionAlumnoEN
        evaluacionAlumnoEN = new EvaluacionAlumnoEN ();
        evaluacionAlumnoEN.Id = p_oid;
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Modify (evaluacionAlumnoEN);
}

public void Destroy (int id)
{
        _IEvaluacionAlumnoCAD.Destroy (id);
}

public System.Collections.Generic.IList<EvaluacionAlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EvaluacionAlumnoEN> list = null;

        list = _IEvaluacionAlumnoCAD.ReadAll (first, size);
        return list;
}
public EvaluacionAlumnoEN ReadOID (int id)
{
        EvaluacionAlumnoEN evaluacionAlumnoEN = null;

        evaluacionAlumnoEN = _IEvaluacionAlumnoCAD.ReadOID (id);
        return evaluacionAlumnoEN;
}

public long ReadCantidad ()
{
        return _IEvaluacionAlumnoCAD.ReadCantidad ();
}
public void Relationer_expediente_evaluacion (int p_evaluacionalumno, int p_expedienteevaluacion)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Relationer_expediente_evaluacion (p_evaluacionalumno, p_expedienteevaluacion);
}
public void Relationer_controles (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Relationer_controles (p_evaluacionalumno, p_controlalumno);
}
public void Relationer_entregas (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Relationer_entregas (p_evaluacionalumno, p_entregaalumno);
}
public void Relationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Relationer_sistema_evaluacion (p_evaluacionalumno, p_sistemaevaluacion);
}
public void Unrelationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Unrelationer_sistema_evaluacion (p_evaluacionalumno, p_sistemaevaluacion);
}
public void Unrelationer_controles (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Unrelationer_controles (p_evaluacionalumno, p_controlalumno);
}
public void Unrelationer_entregas (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Unrelationer_entregas (p_evaluacionalumno, p_entregaalumno);
}
}
}
