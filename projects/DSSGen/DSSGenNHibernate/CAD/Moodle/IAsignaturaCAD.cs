
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAsignaturaCAD
{
AsignaturaEN ReadOIDDefault (int id);

int New_ (AsignaturaEN asignatura);

void Modify (AsignaturaEN asignatura);


void Destroy (int id);


System.Collections.Generic.IList<AsignaturaEN> ReadAll (int first, int size);


AsignaturaEN ReadOID (int id);


long ReadCantidad ();


void Relationer_asignaturas_anyo (int p_asignatura, System.Collections.Generic.IList<int> p_asignaturaanyo);

void Relationer_bolsas_preguntas (int p_asignatura, System.Collections.Generic.IList<int> p_bolsapreguntas);

void Relationer_curso (int p_asignatura, int p_curso);

void Relationer_expedientes_asignatura (int p_asignatura, System.Collections.Generic.IList<int> p_expedienteasignatura);

void Unrelationer_asignaturas_anyo (int p_asignatura, System.Collections.Generic.IList<int> p_asignaturaanyo);

void Unrelationer_bolsas_preguntas (int p_asignatura, System.Collections.Generic.IList<int> p_bolsapreguntas);

void Unrelationer_curso (int p_asignatura, int p_curso);

void Unrelationer_expedientes_asignatura (int p_asignatura, System.Collections.Generic.IList<int> p_expedienteasignatura);
}
}
