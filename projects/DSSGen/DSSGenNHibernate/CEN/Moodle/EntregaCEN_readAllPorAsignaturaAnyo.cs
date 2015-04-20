
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
public partial class EntregaCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> ReadAllPorAsignaturaAnyo (int p_anyo, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Entrega_readAllPorAsignaturaAnyo) ENABLED START*/

        // Write here your custom code...

        return this._IEntregaCAD.ReadAllPorAsignaturaAnyo (p_anyo, first, size);

        /*PROTECTED REGION END*/
}
}
}
