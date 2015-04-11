
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface ISistemaEvaluacionCAD
{
SistemaEvaluacionEN ReadOIDDefault (int id);

int New_ (SistemaEvaluacionEN sistemaEvaluacion);

void Modify (SistemaEvaluacionEN sistemaEvaluacion);


void Destroy (int id);


System.Collections.Generic.IList<SistemaEvaluacionEN> ReadAll (int first, int size);


SistemaEvaluacionEN ReadOID (int id);


long ReadCantidad ();


void Relationer_asignatura (int p_sistemaevaluacion, int p_asignaturaanyo);

void Relationer_controles (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_control);

void Relationer_entregas (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_entrega);

void Relationer_evaluacion (int p_sistemaevaluacion, int p_evaluacion);

void Relationer_evaluaciones_alumno (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_evaluacionalumno);

void Unrelationer_asignatura (int p_sistemaevaluacion, int p_asignaturaanyo);

void Unrelationer_controles (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_control);

void Unrelationer_entregas (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_entrega);

void Unrelationer_evaluacion (int p_sistemaevaluacion, int p_evaluacion);

void Unrelationer_evaluaciones_alumno (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_evaluacionalumno);
}
}
