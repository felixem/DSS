
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IEntregaCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
    }
}
