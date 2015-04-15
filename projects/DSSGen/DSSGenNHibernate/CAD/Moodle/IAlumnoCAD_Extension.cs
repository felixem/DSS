
using System;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial interface IAlumnoCAD
    {
        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllPorGrupo(int p_grupo, int first, int size);

        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllIngresablesEnGrupo(int id, int first, int size);

        System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllPorAsignaturaAnyo(int id, int first, int size);
    }
}
