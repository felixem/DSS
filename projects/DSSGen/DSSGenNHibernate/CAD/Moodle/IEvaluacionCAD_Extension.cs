
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IEvaluacionCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> ReadAllPorAnyo(int id, int first, int size);
    }
}
