
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IEvaluacionAlumnoCAD
{
EvaluacionAlumnoEN ReadOIDDefault (int id);

int New_ (EvaluacionAlumnoEN evaluacionAlumno);

void Modify (EvaluacionAlumnoEN evaluacionAlumno);


void Destroy (int id);


System.Collections.Generic.IList<EvaluacionAlumnoEN> ReadAll (int first, int size);


EvaluacionAlumnoEN ReadOID (int id);


long ReadCantidad ();


DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN ReadPorAlumnoYEntrega (string p_alumno, int p_entrega);


void Relationer_expediente_evaluacion (int p_evaluacionalumno, int p_expedienteevaluacion);

void Relationer_controles (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_controlalumno);

void Relationer_entregas (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_entregaalumno);

void Relationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion);

void Unrelationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion);

void Unrelationer_controles (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_controlalumno);

void Unrelationer_entregas (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_entregaalumno);
}
}
