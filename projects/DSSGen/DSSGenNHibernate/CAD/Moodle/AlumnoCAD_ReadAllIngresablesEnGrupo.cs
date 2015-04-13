
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
    public partial class AlumnoCAD : BasicCAD, IAlumnoCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllIngresablesEnGrupo(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct alu FROM AlumnoEN as alu INNER JOIN alu.Sistemas_evaluacion as eval INNER JOIN eval.Sistema_evaluacion as sist INNER JOIN sist.Asignatura as asig INNER JOIN asig.Grupos_trabajo	as grupo where grupo.Id=:id AND alu NOT MEMBER OF grupo.Alumnos";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("id", id);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.AlumnoEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.AlumnoEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException("Error in AlumnoCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
