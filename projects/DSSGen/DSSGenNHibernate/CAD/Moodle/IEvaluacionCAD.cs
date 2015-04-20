
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IEvaluacionCAD
{
EvaluacionEN ReadOIDDefault (int id);

int New_ (EvaluacionEN evaluacion);

void Modify (EvaluacionEN evaluacion);


void Destroy (int id);


System.Collections.Generic.IList<EvaluacionEN> ReadAll (int first, int size);


EvaluacionEN ReadOID (int id);


long ReadCantidad ();


long ReadCantidadPorAnyo (int id);



void Relationer_anyo_academico (int p_evaluacion, int p_anyoacademico);

void Relationer_expedientes (int p_evaluacion, System.Collections.Generic.IList<int> p_expedienteevaluacion);

void Relationer_sistemas_evaluacion (int p_evaluacion, System.Collections.Generic.IList<int> p_sistemaevaluacion);

void Unrelationer_anyo_academico (int p_evaluacion, int p_anyoacademico);

void Unrelationer_expedientes (int p_evaluacion, System.Collections.Generic.IList<int> p_expedienteevaluacion);

void Unrelationer_sistemas_evaluacion (int p_evaluacion, System.Collections.Generic.IList<int> p_sistemaevaluacion);
}
}
