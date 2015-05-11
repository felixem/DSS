

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
public partial class SistemaEvaluacionCEN
{
private ISistemaEvaluacionCAD _ISistemaEvaluacionCAD;

public SistemaEvaluacionCEN()
{
        this._ISistemaEvaluacionCAD = new SistemaEvaluacionCAD ();
}

public SistemaEvaluacionCEN(ISistemaEvaluacionCAD _ISistemaEvaluacionCAD)
{
        this._ISistemaEvaluacionCAD = _ISistemaEvaluacionCAD;
}

public ISistemaEvaluacionCAD get_ISistemaEvaluacionCAD ()
{
        return this._ISistemaEvaluacionCAD;
}

public int New_ (float p_puntuacion_maxima, int p_asignatura, int p_evaluacion)
{
        SistemaEvaluacionEN sistemaEvaluacionEN = null;
        int oid;

        //Initialized SistemaEvaluacionEN
        sistemaEvaluacionEN = new SistemaEvaluacionEN ();
        sistemaEvaluacionEN.Puntuacion_maxima = p_puntuacion_maxima;


        if (p_asignatura != -1) {
                sistemaEvaluacionEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ();
                sistemaEvaluacionEN.Asignatura.Id = p_asignatura;
        }


        if (p_evaluacion != -1) {
                sistemaEvaluacionEN.Evaluacion = new DSSGenNHibernate.EN.Moodle.EvaluacionEN ();
                sistemaEvaluacionEN.Evaluacion.Id = p_evaluacion;
        }

        //Call to SistemaEvaluacionCAD

        oid = _ISistemaEvaluacionCAD.New_ (sistemaEvaluacionEN);
        return oid;
}

public void Modify (int p_oid, float p_puntuacion_maxima)
{
        SistemaEvaluacionEN sistemaEvaluacionEN = null;

        //Initialized SistemaEvaluacionEN
        sistemaEvaluacionEN = new SistemaEvaluacionEN ();
        sistemaEvaluacionEN.Id = p_oid;
        sistemaEvaluacionEN.Puntuacion_maxima = p_puntuacion_maxima;
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Modify (sistemaEvaluacionEN);
}

public void Destroy (int id)
{
        _ISistemaEvaluacionCAD.Destroy (id);
}

public System.Collections.Generic.IList<SistemaEvaluacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SistemaEvaluacionEN> list = null;

        list = _ISistemaEvaluacionCAD.ReadAll (first, size);
        return list;
}
public SistemaEvaluacionEN ReadOID (int id)
{
        SistemaEvaluacionEN sistemaEvaluacionEN = null;

        sistemaEvaluacionEN = _ISistemaEvaluacionCAD.ReadOID (id);
        return sistemaEvaluacionEN;
}

public long ReadCantidad ()
{
        return _ISistemaEvaluacionCAD.ReadCantidad ();
}
public long ReadCantidadPorAsignaturaAnyo (int id)
{
        return _ISistemaEvaluacionCAD.ReadCantidadPorAsignaturaAnyo (id);
}
public DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ReadRelation (int p_asig, int p_eval)
{
        return _ISistemaEvaluacionCAD.ReadRelation (p_asig, p_eval);
}
public void Relationer_asignatura (int p_sistemaevaluacion, int p_asignaturaanyo)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Relationer_asignatura (p_sistemaevaluacion, p_asignaturaanyo);
}
public void Relationer_controles (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_control)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Relationer_controles (p_sistemaevaluacion, p_control);
}
public void Relationer_entregas (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_entrega)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Relationer_entregas (p_sistemaevaluacion, p_entrega);
}
public void Relationer_evaluacion (int p_sistemaevaluacion, int p_evaluacion)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Relationer_evaluacion (p_sistemaevaluacion, p_evaluacion);
}
public void Relationer_evaluaciones_alumno (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Relationer_evaluaciones_alumno (p_sistemaevaluacion, p_evaluacionalumno);
}
public void Unrelationer_asignatura (int p_sistemaevaluacion, int p_asignaturaanyo)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Unrelationer_asignatura (p_sistemaevaluacion, p_asignaturaanyo);
}
public void Unrelationer_controles (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_control)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Unrelationer_controles (p_sistemaevaluacion, p_control);
}
public void Unrelationer_entregas (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_entrega)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Unrelationer_entregas (p_sistemaevaluacion, p_entrega);
}
public void Unrelationer_evaluacion (int p_sistemaevaluacion, int p_evaluacion)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Unrelationer_evaluacion (p_sistemaevaluacion, p_evaluacion);
}
public void Unrelationer_evaluaciones_alumno (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        //Call to SistemaEvaluacionCAD

        _ISistemaEvaluacionCAD.Unrelationer_evaluaciones_alumno (p_sistemaevaluacion, p_evaluacionalumno);
}
}
}
