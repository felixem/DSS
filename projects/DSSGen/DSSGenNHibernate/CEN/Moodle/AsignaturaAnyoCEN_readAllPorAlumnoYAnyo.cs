
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
public partial class AsignaturaAnyoCEN
{
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAlumnoYAnyo (string p_alumno, int p_anyo, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_AsignaturaAnyo_readAllPorAlumnoYAnyo) ENABLED START*/

        // Write here your custom code...

    return this._IAsignaturaAnyoCAD.ReadAllPorAlumnoYAnyo(p_alumno, p_anyo, first, size);

        /*PROTECTED REGION END*/
}
}
}
