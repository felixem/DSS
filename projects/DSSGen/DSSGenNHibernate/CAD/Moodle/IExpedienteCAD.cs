
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IExpedienteCAD
{
ExpedienteEN ReadOIDDefault (int id);

int New_ (ExpedienteEN expediente);

void Modify (ExpedienteEN expediente);


void Destroy (int id);


System.Collections.Generic.IList<ExpedienteEN> ReadAll (int first, int size);


ExpedienteEN ReadOID (int id);


void Relationer_alumno (int p_expediente, int p_alumno);

void Relationer_expedientes_anyo (int p_expediente, System.Collections.Generic.IList<int> p_expedienteanyo);

void Unrelationer_alumno (int p_expediente, int p_alumno);

void Unrelationer_expedientes_anyo (int p_expediente, System.Collections.Generic.IList<int> p_expedienteanyo);
}
}
