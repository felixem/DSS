
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


void Relationer_alumno (int p_controlalumno, int p_alumno);

void Relationer_control (int p_controlalumno, int p_control);

void Relationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol);

void Unrelationer_alumno (int p_controlalumno, int p_alumno);

void Unrelationer_control (int p_controlalumno, int p_control);

void Unrelationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol);
}
}
