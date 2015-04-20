
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IControlCAD
{
ControlEN ReadOIDDefault (int id);

int New_ (ControlEN control);

void Modify (ControlEN control);


void Destroy (int id);


System.Collections.Generic.IList<ControlEN> ReadAll (int first, int size);


ControlEN ReadOID (int id);


long ReadCantidad ();


long ReadCantidadPorAsignaturaAnyo (int id);



void Relationer_bolsas_preguntas (int p_control, System.Collections.Generic.IList<int> p_bolsapreguntas);

void Relationer_controles_alumno (int p_control, System.Collections.Generic.IList<int> p_controlalumno);

void Relationer_sistema_evaluacion (int p_control, int p_sistemaevaluacion);

void Unrelationer_bolsas_preguntas (int p_control, System.Collections.Generic.IList<int> p_bolsapreguntas);

void Unrelationer_controles_alumno (int p_control, System.Collections.Generic.IList<int> p_controlalumno);

void Unrelationer_sistema_evaluacion (int p_control, int p_sistemaevaluacion);
}
}
