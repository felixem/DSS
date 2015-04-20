
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
public partial class AlumnoCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllPorAsignaturaAnyo (int id, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Alumno_readAllPorAsignaturaAnyo) ENABLED START*/

        // Write here your custom code...

        return this._IAlumnoCAD.ReadAllPorAsignaturaAnyo (id, first, size);

        /*PROTECTED REGION END*/
}
}
}
