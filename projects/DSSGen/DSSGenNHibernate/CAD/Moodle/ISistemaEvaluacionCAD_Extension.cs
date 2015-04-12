
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface ISistemaEvaluacionCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
    }
}
