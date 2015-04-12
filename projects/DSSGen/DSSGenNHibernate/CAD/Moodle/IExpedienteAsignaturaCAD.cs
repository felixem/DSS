
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IExpedienteAsignaturaCAD
{
ExpedienteAsignaturaEN ReadOIDDefault (int id);

int New_ (ExpedienteAsignaturaEN expedienteAsignatura);

void Modify (ExpedienteAsignaturaEN expedienteAsignatura);


void Destroy (int id);


System.Collections.Generic.IList<ExpedienteAsignaturaEN> ReadAll (int first, int size);


ExpedienteAsignaturaEN ReadOID (int id);


long ReadCantidad ();


void Relationer_asignatura (int p_expedienteasignatura, int p_asignatura);

void Relationer_expediente_anyo (int p_expedienteasignatura, int p_expedienteanyo);

void Relationer_expedientes_evaluacion (int p_expedienteasignatura, System.Collections.Generic.IList<int> p_expedienteevaluacion);

void Relationer_nota (int p_expedienteasignatura, int p_nota);

void Unrelationer_asignatura (int p_expedienteasignatura, int p_asignatura);

void Unrelationer_expediente_anyo (int p_expedienteasignatura, int p_expedienteanyo);

void Unrelationer_expedientes_evaluacion (int p_expedienteasignatura, System.Collections.Generic.IList<int> p_expedienteevaluacion);

void Unrelationer_nota (int p_expedienteasignatura, int p_nota);
}
}
