
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
public partial class AsignaturaCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> ReadAllVinculablesAAnyo (int id, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Asignatura_readAllVinculablesAAnyo) ENABLED START*/

        // Write here your custom code...

        return this._IAsignaturaCAD.ReadAllVinculablesAAnyo (id, first, size);

        /*PROTECTED REGION END*/
}
}
}
