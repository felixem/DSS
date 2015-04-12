
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IEntregaCAD
{
EntregaEN ReadOIDDefault (int id);

int New_ (EntregaEN entrega);

void Modify (EntregaEN entrega);


void Destroy (int id);


System.Collections.Generic.IList<EntregaEN> ReadAll (int first, int size);


EntregaEN ReadOID (int id);


long ReadCantidad ();


void Relationer_entregas_alumno (int p_entrega, System.Collections.Generic.IList<int> p_entregaalumno);

void Relationer_evaluacion (int p_entrega, int p_sistemaevaluacion);

void Relationer_profesor (int p_entrega, string p_profesor);

void Unrelationer_entregas_alumno (int p_entrega, System.Collections.Generic.IList<int> p_entregaalumno);


void Unrelationer_evaluacion (int p_entrega, int p_sistemaevaluacion);

void Unrelationer_profesor (int p_entrega, string p_profesor);
}
}
