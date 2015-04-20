
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IGrupoTrabajoCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> ReadAllPorAlumnoYAsignaturaAnyo(string p_alumno, int p_asig, int first, int size);
    }
}
