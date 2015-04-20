
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IControlAlumnoCAD
{
ControlAlumnoEN ReadOIDDefault (int id);

int New_ (ControlAlumnoEN controlAlumno);

void Modify (ControlAlumnoEN controlAlumno);


void Destroy (int id);


System.Collections.Generic.IList<ControlAlumnoEN> ReadAll (int first, int size);


ControlAlumnoEN ReadOID (int id);


long ReadCantidad ();


DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ReadRelation (int p_evalalumno, int p_control);


void Relationer_evaluacion_alumno (int p_controlalumno, int p_evaluacionalumno);

void Relationer_control (int p_controlalumno, int p_control);

void Relationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol);

void Unrelationer_evaluacion_alumno (int p_controlalumno, int p_evaluacionalumno);

void Unrelationer_control (int p_controlalumno, int p_control);

void Unrelationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol);
}
}
