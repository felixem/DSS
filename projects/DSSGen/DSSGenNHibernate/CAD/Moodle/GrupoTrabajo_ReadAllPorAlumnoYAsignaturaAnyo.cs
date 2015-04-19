
using System;
using System.Text;
using DSSGenNHibernate.CEN.Moodle;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.Exceptions;

namespace DSSGenNHibernate.CAD.Moodle
{
    public partial class GrupoTrabajoCAD : BasicCAD, IGrupoTrabajoCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> ReadAllPorAlumnoYAsignaturaAnyo(string p_alumno, int p_asig, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct grupo FROM GrupoTrabajoEN as grupo INNER JOIN grupo.Alumnos as alu where grupo.Asignatura.Id=:p_asig AND alu.Email=:p_alumno";
                IQuery query = session.CreateQuery(sql);

                query.SetParameter("p_alumno", p_alumno);
                query.SetParameter("p_asig", p_asig);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException("Error in GrupoTrabajoCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
