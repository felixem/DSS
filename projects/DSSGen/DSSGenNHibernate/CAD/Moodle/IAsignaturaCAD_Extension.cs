
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IAsignaturaCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> ReadAllVinculablesAAnyo(int id, int first, int size);
    }
}
