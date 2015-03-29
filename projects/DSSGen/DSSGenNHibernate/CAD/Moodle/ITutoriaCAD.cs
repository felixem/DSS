
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface ITutoriaCAD
{
TutoriaEN ReadOIDDefault (int id);

int New_ (TutoriaEN tutoria);

void Modify (TutoriaEN tutoria);


void Destroy (int id);


System.Collections.Generic.IList<TutoriaEN> ReadAll (int first, int size);


TutoriaEN ReadOID (int id);


void Relationer_alumno (int p_tutoria, string p_alumno);

void Relationer_asignatura (int p_tutoria, int p_asignaturaanyo);

void Relationer_mensajes (int p_tutoria, System.Collections.Generic.IList<int> p_mensaje);

void Relationer_profesor (int p_tutoria, string p_profesor);

void Unrelationer_alumno (int p_tutoria, string p_alumno);

void Unrelationer_asignatura (int p_tutoria, int p_asignaturaanyo);

void Unrelationer_mensajes (int p_tutoria, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_profesor (int p_tutoria, string p_profesor);
}
}
