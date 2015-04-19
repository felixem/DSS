
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
public partial class EvaluacionCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> ReadAllPorAnyo (int id, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Evaluacion_readAllPorAnyo) ENABLED START*/

        // Write here your custom code...

    return this._IEvaluacionCAD.ReadAllPorAnyo(id, first, size);

        /*PROTECTED REGION END*/
}
}
}
