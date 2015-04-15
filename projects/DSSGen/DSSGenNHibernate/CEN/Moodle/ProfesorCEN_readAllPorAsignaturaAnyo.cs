
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
public partial class ProfesorCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ProfesorEN> ReadAllPorAsignaturaAnyo (int p_asig_anyo, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Profesor_readAllPorAsignaturaAnyo) ENABLED START*/

        // Write here your custom code...

        return this._IProfesorCAD.ReadAllPorAsignaturaAnyo (p_asig_anyo, first, size);

        /*PROTECTED REGION END*/
}
}
}
