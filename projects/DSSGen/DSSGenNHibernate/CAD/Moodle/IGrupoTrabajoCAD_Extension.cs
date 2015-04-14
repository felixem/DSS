
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IGrupoTrabajoCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
    }
}
