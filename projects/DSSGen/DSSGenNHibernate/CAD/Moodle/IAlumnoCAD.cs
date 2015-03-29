
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAlumnoCAD
{
AlumnoEN ReadOIDDefault (string email);

string New_ (AlumnoEN alumno);

void Modify (AlumnoEN alumno);


void Destroy (string email);


System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size);


AlumnoEN ReadOID (string email);


void Relationer_controles (string p_alumno, System.Collections.Generic.IList<int> p_controlalumno);

void Relationer_entregas (string p_alumno, System.Collections.Generic.IList<int> p_entregaalumno);

void Relationer_expediente (string p_alumno, int p_expediente);

void Relationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo);

void Relationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje);

void Relationer_sistemas_evaluacion (string p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno);

void Relationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria);

void Unrelationer_controles (string p_alumno, System.Collections.Generic.IList<int> p_controlalumno);

void Unrelationer_entregas (string p_alumno, System.Collections.Generic.IList<int> p_entregaalumno);

void Unrelationer_expediente (string p_alumno, int p_expediente);

void Unrelationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo);

void Unrelationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_sistemas_evaluacion (string p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno);

void Unrelationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria);
}
}
