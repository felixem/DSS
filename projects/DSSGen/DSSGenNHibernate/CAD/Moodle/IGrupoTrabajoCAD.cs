
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IGrupoTrabajoCAD
{
GrupoTrabajoEN ReadOIDDefault (int id);

int New_ (GrupoTrabajoEN grupoTrabajo);

void Modify (GrupoTrabajoEN grupoTrabajo);


void Destroy (int id);


System.Collections.Generic.IList<GrupoTrabajoEN> ReadAll (int first, int size);


GrupoTrabajoEN ReadOID (int id);


void Relationer_alumnos (int p_grupotrabajo, System.Collections.Generic.IList<string> p_alumno);

void Relationer_asignatura (int p_grupotrabajo, int p_asignaturaanyo);

void Unrelationer_alumnos (int p_grupotrabajo, System.Collections.Generic.IList<string> p_alumno);

void Unrelationer_asignatura (int p_grupotrabajo, int p_asignaturaanyo);
}
}
