
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
    public partial class EvaluacionCAD : BasicCAD, IEvaluacionCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> ReadAllPorAnyo(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct eval FROM EvaluacionEN eval where eval.Anyo_academico.Id=:id";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("id", id);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.EvaluacionEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.EvaluacionEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException("Error in EvaluacionCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
