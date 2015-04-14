
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
    public partial class GrupoTrabajoCEN
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> ReadAllPorAsignaturaAnyo(int p_as_anyo, int first, int size)
        {
            /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_GrupoTrabajo_readAllPorAsignaturaAnyo) ENABLED START*/

            // Write here your custom code...

            return this._IGrupoTrabajoCAD.ReadAllPorAsignaturaAnyo(p_as_anyo, first, size);

            /*PROTECTED REGION END*/
        }
    }
}
