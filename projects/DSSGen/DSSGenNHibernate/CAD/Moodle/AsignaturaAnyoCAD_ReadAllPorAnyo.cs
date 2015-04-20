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
    public partial class AsignaturaAnyoCAD : BasicCAD, IAsignaturaAnyoCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAnyo(int p_anyo, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct asig FROM AsignaturaAnyoEN asig where asig.Anyo.Id=:id ";
                IQuery query = session.CreateQuery(sql);

                query.SetParameter("id", p_anyo);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException("Error in AsignaturaAnyoCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
