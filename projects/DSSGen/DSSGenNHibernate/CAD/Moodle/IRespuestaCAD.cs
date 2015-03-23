
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IRespuestaCAD
{
RespuestaEN ReadOIDDefault (int id);

int New_ (RespuestaEN respuesta);

void Modify (RespuestaEN respuesta);


void Destroy (int id);


System.Collections.Generic.IList<RespuestaEN> ReadAll (int first, int size);


RespuestaEN ReadOID (int id);


void Relationer_pregunta (int p_respuesta, int p_pregunta);

void Relationer_pregunta_relacionada (int p_respuesta, int p_pregunta);

void Relationer_preguntas_control (int p_respuesta, System.Collections.Generic.IList<int> p_preguntacontrol);

void Unrelationer_pregunta (int p_respuesta, int p_pregunta);

void Unrelationer_pregunta_relacionada (int p_respuesta, int p_pregunta);

void Unrelationer_preguntas_control (int p_respuesta, System.Collections.Generic.IList<int> p_preguntacontrol);
}
}
