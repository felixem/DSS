
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IExpedienteAnyoCAD
{
ExpedienteAnyoEN ReadOIDDefault (int id);

int New_ (ExpedienteAnyoEN expedienteAnyo);

void Modify (ExpedienteAnyoEN expedienteAnyo);


void Destroy (int id);


System.Collections.Generic.IList<ExpedienteAnyoEN> ReadAll (int first, int size);


ExpedienteAnyoEN ReadOID (int id);


long ReadCantidad ();


DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN ReadRelation (int p_exp, int p_anyo);


void Relationer_anyo (int p_expedienteanyo, int p_anyoacademico);

void Relationer_expediente (int p_expedienteanyo, int p_expediente);

void Relationer_expedientes_asignatura (int p_expedienteanyo, System.Collections.Generic.IList<int> p_expedienteasignatura);

void Unrelationer_anyo (int p_expedienteanyo, int p_anyoacademico);

void Unrelationer_expediente (int p_expedienteanyo, int p_expediente);

void Unrelationer_expedientes_asignatura (int p_expedienteanyo, System.Collections.Generic.IList<int> p_expedienteasignatura);
}
}
