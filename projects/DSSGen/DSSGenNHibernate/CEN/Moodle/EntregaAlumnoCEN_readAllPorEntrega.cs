
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
public partial class EntregaAlumnoCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> ReadAllPorEntrega (int p_entrega, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_EntregaAlumno_readAllPorEntrega) ENABLED START*/

        // Write here your custom code...

        return this._IEntregaAlumnoCAD.ReadAllPorEntrega (p_entrega, first, size);

        /*PROTECTED REGION END*/
}
}
}
