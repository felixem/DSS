
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IProfesorCAD
{
ProfesorEN ReadOIDDefault (int id);

int New_ (ProfesorEN profesor);

void Modify (ProfesorEN profesor);


void Destroy (int id);


System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size);


ProfesorEN ReadOID (int id);


void Relationer_entregas_propuestas (int p_profesor, System.Collections.Generic.IList<int> p_entrega);

void Relationer_materiales (int p_profesor, System.Collections.Generic.IList<int> p_material);

void Relationer_mensajes (int p_profesor, System.Collections.Generic.IList<int> p_mensaje);

void Relationer_tutorias (int p_profesor, System.Collections.Generic.IList<int> p_tutoria);

void Unrelationer_entregas_propuestas (int p_profesor, System.Collections.Generic.IList<int> p_entrega);

void Unrelationer_materiales (int p_profesor, System.Collections.Generic.IList<int> p_material);

void Unrelationer_mensajes (int p_profesor, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_tutorias (int p_profesor, System.Collections.Generic.IList<int> p_tutoria);
}
}
