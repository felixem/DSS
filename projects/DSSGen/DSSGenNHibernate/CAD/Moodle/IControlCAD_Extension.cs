
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IControlCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
    }
}
