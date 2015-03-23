
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IMaterialCAD
{
MaterialEN ReadOIDDefault (int id);

int New_ (MaterialEN material);

void Modify (MaterialEN material);


void Destroy (int id);


System.Collections.Generic.IList<MaterialEN> ReadAll (int first, int size);


MaterialEN ReadOID (int id);


void Relationer_asignatura (int p_material, int p_asignaturaanyo);

void Relationer_profesor (int p_material, int p_profesor);

void Unrelationer_asignatura (int p_material, int p_asignaturaanyo);

void Unrelationer_profesor (int p_material, int p_profesor);
}
}
