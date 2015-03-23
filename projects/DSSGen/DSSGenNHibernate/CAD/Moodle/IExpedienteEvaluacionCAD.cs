
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IExpedienteEvaluacionCAD
{
ExpedienteEvaluacionEN ReadOIDDefault (int id);

int New_ (ExpedienteEvaluacionEN expedienteEvaluacion);

void Modify (ExpedienteEvaluacionEN expedienteEvaluacion);


void Destroy (int id);


System.Collections.Generic.IList<ExpedienteEvaluacionEN> ReadAll (int first, int size);


ExpedienteEvaluacionEN ReadOID (int id);


void Relationer_evaluacion (int p_expedienteevaluacion, int p_evaluacion);

void Relationer_expediente_asignatura (int p_expedienteevaluacion, int p_expedienteasignatura);

void Unrelationer_evaluacion (int p_expedienteevaluacion, int p_evaluacion);

void Unrelationer_expediente_asignatura (int p_expedienteevaluacion, int p_expedienteasignatura);
}
}
