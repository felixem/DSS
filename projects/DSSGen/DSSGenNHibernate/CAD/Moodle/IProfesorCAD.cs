
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IProfesorCAD
{
ProfesorEN ReadOIDDefault (string email);

string New_ (ProfesorEN profesor);

void Modify (ProfesorEN profesor);


void Destroy (string email);


System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size);


ProfesorEN ReadOID (string email);


void ModifyNoPassword (ProfesorEN profesor);


long ReadCantidad ();


DSSGenNHibernate.EN.Moodle.ProfesorEN ReadCod (int cod);


long ReadCantidadPorAsignaturaAnyo (int id);



void Relationer_entregas_propuestas (string p_profesor, System.Collections.Generic.IList<int> p_entrega);

void Relationer_materiales (string p_profesor, System.Collections.Generic.IList<int> p_material);

void Relationer_mensajes (string p_profesor, System.Collections.Generic.IList<int> p_mensaje);

void Relationer_tutorias (string p_profesor, System.Collections.Generic.IList<int> p_tutoria);

void Relationer_asignaturas (string p_profesor, System.Collections.Generic.IList<int> p_asignaturaanyo);

void Unrelationer_entregas_propuestas (string p_profesor, System.Collections.Generic.IList<int> p_entrega);

void Unrelationer_materiales (string p_profesor, System.Collections.Generic.IList<int> p_material);

void Unrelationer_mensajes (string p_profesor, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_tutorias (string p_profesor, System.Collections.Generic.IList<int> p_tutoria);

void Unrelationer_asignaturas (string p_profesor, System.Collections.Generic.IList<int> p_asignaturaanyo);
}
}
