
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IEntregaAlumnoCAD
{
EntregaAlumnoEN ReadOIDDefault (int id);

int New_ (EntregaAlumnoEN entregaAlumno);

void Modify (EntregaAlumnoEN entregaAlumno);


void Destroy (int id);


System.Collections.Generic.IList<EntregaAlumnoEN> ReadAll (int first, int size);


EntregaAlumnoEN ReadOID (int id);


long ReadCantidad ();


void Relationer_alumno (int p_entregaalumno, string p_alumno);

void Relationer_entrega (int p_entregaalumno, int p_entrega);

void Unrelationer_alumno (int p_entregaalumno, string p_alumno);

void Unrelationer_entrega (int p_entregaalumno, int p_entrega);
}
}
