
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
    public partial class AsignaturaCAD : BasicCAD, IAsignaturaCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> ReadAllVinculablesAAnyo(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct(asig) FROM AsignaturaEN asig where asig.Id NOT IN (select asignatura.Id FROM AsignaturaEN asignatura INNER JOIN asignatura.Asignaturas_anyo as asig_anyo where asig_anyo.Anyo.Id=:id) ";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("id", id);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.AsignaturaEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.AsignaturaEN>();

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
