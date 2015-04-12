
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface ICursoCAD
{
CursoEN ReadOIDDefault (int id);

int New_ (CursoEN curso);

void Modify (CursoEN curso);


void Destroy (int id);


System.Collections.Generic.IList<CursoEN> ReadAll (int first, int size);


CursoEN ReadOID (int id);


long ReadCantidad ();


void Relationer_asignaturas (int p_curso, System.Collections.Generic.IList<int> p_asignatura);

void Unrelationer_asignaturas (int p_curso, System.Collections.Generic.IList<int> p_asignatura);
}
}
