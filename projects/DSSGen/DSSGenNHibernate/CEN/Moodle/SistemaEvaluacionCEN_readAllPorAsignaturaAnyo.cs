
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace DSSGenNHibernate.CEN.Moodle
{
public partial class SistemaEvaluacionCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> ReadAllPorAsignaturaAnyo (int id, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_SistemaEvaluacion_readAllPorAsignaturaAnyo) ENABLED START*/

        // Write here your custom code...

        return this._ISistemaEvaluacionCAD.ReadAllPorAsignaturaAnyo (id, first, size);

        /*PROTECTED REGION END*/
}
}
}
