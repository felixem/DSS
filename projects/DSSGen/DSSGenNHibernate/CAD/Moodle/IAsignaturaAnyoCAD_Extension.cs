
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IAsignaturaAnyoCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAnyo(int p_anyo, int first, int size);
    }
}
