
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
    public partial class SistemaEvaluacionCAD : BasicCAD, ISistemaEvaluacionCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> ReadAllPorAsignaturaAnyo(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"FROM SistemaEvaluacionEN sis where sis.Asignatura.Id=:id ";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("id", id);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException("Error in SistemaEvaluacionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
