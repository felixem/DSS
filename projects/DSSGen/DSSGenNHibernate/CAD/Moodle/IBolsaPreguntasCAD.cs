
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IBolsaPreguntasCAD
{
BolsaPreguntasEN ReadOIDDefault (int id);

int New_ (BolsaPreguntasEN bolsaPreguntas);

void Modify (BolsaPreguntasEN bolsaPreguntas);


void Destroy (int id);


System.Collections.Generic.IList<BolsaPreguntasEN> ReadAll (int first, int size);


BolsaPreguntasEN ReadOID (int id);


void Relationer_asignatura (int p_bolsapreguntas, int p_asignatura);

void Relationer_controles (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_control);

void Relationer_preguntas (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_pregunta);

void Unrelationer_asignatura (int p_bolsapreguntas, int p_asignatura);

void Unrelationer_controles (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_control);

void Unrelationer_preguntas (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_pregunta);
}
}
