
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAsignaturaAnyoCAD
{
AsignaturaAnyoEN ReadOIDDefault (int id);

int New_ (AsignaturaAnyoEN asignaturaAnyo);

void Modify (AsignaturaAnyoEN asignaturaAnyo);


void Destroy (int id);


System.Collections.Generic.IList<AsignaturaAnyoEN> ReadAll (int first, int size);


AsignaturaAnyoEN ReadOID (int id);


void Relationer_anyo (int p_asignaturaanyo, int p_anyoacademico);

void Relationer_asignatura (int p_asignaturaanyo, int p_asignatura);

void Relationer_grupos_trabajo (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_grupotrabajo);

void Relationer_materiales (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_material);

void Relationer_sistemas_evaluacion (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_sistemaevaluacion);

void Relationer_tutorias (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_tutoria);

void Unrelationer_anyo (int p_asignaturaanyo, int p_anyoacademico);

void Unrelationer_asignatura (int p_asignaturaanyo, int p_asignatura);

void Unrelationer_grupos_trabajo (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_grupotrabajo);

void Unrelationer_materiales (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_material);

void Unrelationer_sistemas_evaluacion (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_sistemaevaluacion);

void Unrelationer_tutorias (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_tutoria);
}
}
