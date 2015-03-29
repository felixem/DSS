

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

public int New_ (int p_sistema_evaluacion, string p_alumno)
{
        EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        int oid;

        //Initialized EvaluacionAlumnoEN
        evaluacionAlumnoEN = new EvaluacionAlumnoEN ();

        if (p_sistema_evaluacion != -1) {
                evaluacionAlumnoEN.Sistema_evaluacion = new DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ();
                evaluacionAlumnoEN.Sistema_evaluacion.Id = p_sistema_evaluacion;
        }


        if (p_alumno != null) {
                evaluacionAlumnoEN.Alumno = new DSSGenNHibernate.EN.Moodle.AlumnoEN ();
                evaluacionAlumnoEN.Alumno.Email = p_alumno;
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

public void Relationer_alumno (int p_evaluacionalumno, string p_alumno)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Relationer_alumno (p_evaluacionalumno, p_alumno);
}
public void Relationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Relationer_sistema_evaluacion (p_evaluacionalumno, p_sistemaevaluacion);
}
public void Unrelationer_alumno (int p_evaluacionalumno, string p_alumno)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Unrelationer_alumno (p_evaluacionalumno, p_alumno);
}
public void Unrelationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion)
{
        //Call to EvaluacionAlumnoCAD

        _IEvaluacionAlumnoCAD.Unrelationer_sistema_evaluacion (p_evaluacionalumno, p_sistemaevaluacion);
}
}
}
