
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
public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> ReadAllPorAlumnoYAsignaturaAnyo (string p_alumno, int p_asig, int first, int size)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_GrupoTrabajo_readAllPorAlumnoYAsignaturaAnyo) ENABLED START*/

        // Write here your custom code...

    return this._IGrupoTrabajoCAD.ReadAllPorAlumnoYAsignaturaAnyo(p_alumno, p_asig, first, size);

        /*PROTECTED REGION END*/
}
}
}
