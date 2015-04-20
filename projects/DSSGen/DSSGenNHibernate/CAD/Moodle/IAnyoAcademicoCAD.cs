
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAnyoAcademicoCAD
{
AnyoAcademicoEN ReadOIDDefault (int id);

int New_ (AnyoAcademicoEN anyoAcademico);

void Modify (AnyoAcademicoEN anyoAcademico);


void Destroy (int id);


System.Collections.Generic.IList<AnyoAcademicoEN> ReadAll (int first, int size);


AnyoAcademicoEN ReadOID (int id);


long ReadCantidad ();


DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN ReadCod (string anyo);


void Relationer_asignaturas (int p_anyoacademico, System.Collections.Generic.IList<int> p_asignaturaanyo);

void Relationer_evaluaciones (int p_anyoacademico, System.Collections.Generic.IList<int> p_evaluacion);

void Relationer_expedientes_anyo (int p_anyoacademico, System.Collections.Generic.IList<int> p_expedienteanyo);

void Unrelationer_asignaturas (int p_anyoacademico, System.Collections.Generic.IList<int> p_asignaturaanyo);

void Unrelationer_evaluaciones (int p_anyoacademico, System.Collections.Generic.IList<int> p_evaluacion);

void Unrelationer_expedientes_anyo (int p_anyoacademico, System.Collections.Generic.IList<int> p_expedienteanyo);
}
}
