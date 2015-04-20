
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IPreguntaControlCAD
{
PreguntaControlEN ReadOIDDefault (int id);

int New_ (PreguntaControlEN preguntaControl);

void Modify (PreguntaControlEN preguntaControl);


void Destroy (int id);


System.Collections.Generic.IList<PreguntaControlEN> ReadAll (int first, int size);


PreguntaControlEN ReadOID (int id);


long ReadCantidad ();


void Relationer_control (int p_preguntacontrol, int p_controlalumno);

void Relationer_pregunta (int p_preguntacontrol, int p_pregunta);

void Relationer_respuesta_elegida (int p_preguntacontrol, int p_respuesta);

void Unrelationer_control (int p_preguntacontrol, int p_controlalumno);

void Unrelationer_pregunta (int p_preguntacontrol, int p_pregunta);

void Unrelationer_respuesta_elegida (int p_preguntacontrol, int p_respuesta);
}
}
