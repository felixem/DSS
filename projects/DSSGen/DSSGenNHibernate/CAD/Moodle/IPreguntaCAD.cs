
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IPreguntaCAD
{
PreguntaEN ReadOIDDefault (int id);

int New_ (PreguntaEN pregunta);

void Modify (PreguntaEN pregunta);


void Destroy (int id);


System.Collections.Generic.IList<PreguntaEN> ReadAll (int first, int size);


PreguntaEN ReadOID (int id);


void Relationer_bolsa (int p_pregunta, int p_bolsapreguntas);

void Relationer_respuesta_correcta (int p_pregunta, int p_respuesta);

void Relationer_respuestas (int p_pregunta, System.Collections.Generic.IList<int> p_respuesta);

void Unrelationer_bolsa (int p_pregunta, int p_bolsapreguntas);

void Unrelationer_respuesta_correcta (int p_pregunta, int p_respuesta);

void Unrelationer_respuestas (int p_pregunta, System.Collections.Generic.IList<int> p_respuesta);
}
}
