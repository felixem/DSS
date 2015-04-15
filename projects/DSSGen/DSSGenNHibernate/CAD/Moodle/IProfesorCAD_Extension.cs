
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IProfesorCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ProfesorEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
    }
}
