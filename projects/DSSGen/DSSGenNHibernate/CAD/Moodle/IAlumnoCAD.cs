
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
public partial interface IAlumnoCAD
{
AlumnoEN ReadOIDDefault (string email);

string New_ (AlumnoEN alumno);

void Modify (AlumnoEN alumno);


void ModifyNoPassword (AlumnoEN alumno);


void Destroy (string email);


System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size);


AlumnoEN ReadOID (string email);


long ReadCantidad ();


DSSGenNHibernate.EN.Moodle.AlumnoEN ReadCod (int cod);



long ReadCantidadPorGrupo (int id);


long ReadCantidadIngresablesEnGrupo (int id);



long ReadCantidadPorAsignaturaAnyo (int id);



long ReadCantidadMatriculablesEnAsignaturaAnyo (int id);



void Relationer_expediente (string p_alumno, int p_expediente);

void Relationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo);

void Relationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje);

void Relationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria);

void Unrelationer_expediente (string p_alumno, int p_expediente);

void Unrelationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo);

void Unrelationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje);

void Unrelationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria);
}
}
