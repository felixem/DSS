
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


DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN ReadRelation (int p_evalalumno, int p_entrega);


void Relationer_evaluacion_alumno (int p_entregaalumno, int p_evaluacionalumno);

void Relationer_entrega (int p_entregaalumno, int p_entrega);

void Unrelationer_evaluacion_alumno (int p_entregaalumno, int p_evaluacionalumno);

void Unrelationer_entrega (int p_entregaalumno, int p_entrega);
}
}
