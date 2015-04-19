
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IEntregaAlumnoCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> ReadAllPorEntrega(int id, int first, int size);
    }
}
