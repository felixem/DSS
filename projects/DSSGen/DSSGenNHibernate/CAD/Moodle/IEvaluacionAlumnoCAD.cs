
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


void Relationer_alumno (int p_evaluacionalumno, string p_alumno);

void Relationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion);

void Unrelationer_alumno (int p_evaluacionalumno, string p_alumno);

void Unrelationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion);
}
}
