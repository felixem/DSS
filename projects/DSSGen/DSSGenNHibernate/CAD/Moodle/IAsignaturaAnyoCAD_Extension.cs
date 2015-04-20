
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IAsignaturaAnyoCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAnyo(int p_anyo, int first, int size);
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAlumnoYAnyo(string p_alumno, int p_anyo, int first, int size);
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAnyoYProfesor(int p_anyo, string p_profesor, int first, int size);
    }
}
