
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAlumnoCAD
{
AlumnoEN ReadOIDDefault (int id);

int New_ (AlumnoEN alumno);

void Modify (AlumnoEN alumno);


void Destroy (int id);


System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size);


AlumnoEN ReadOID (int id);


void Relationer_controles (int p_alumno, System.Collections.Generic.IList<int> p_controlalumno);

void Relationer_entregas (int p_alumno, System.Collections.Generic.IList<int> p_entregaalumno);

void Relationer_expediente (int p_alumno, int p_expediente);

void Relationer_grupos_trabajo (int p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo);

void Relationer_mensajes (int p_alumno, System.Collections.Generic.IList<int> p_mensaje);

void Relationer_sistemas_evaluacion (int p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno);

void Relationer_tutorias (int p_alumno, System.Collections.Generic.IList<int> p_tutoria);

void Unrelationer_controles (int p_alumno, System.Collections.Generic.IList<int> p_controlalumno);

void Unrelationer_entregas (int p_alumno, System.Collections.Generic.IList<int> p_entregaalumno);

void Unrelationer_expediente (int p_alumno, int p_expediente);

void Unrelationer_grupos_trabajo (int p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo);

void Unrelationer_mensajes (int p_alumno, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_sistemas_evaluacion (int p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno);

void Unrelationer_tutorias (int p_alumno, System.Collections.Generic.IList<int> p_tutoria);
}
}
