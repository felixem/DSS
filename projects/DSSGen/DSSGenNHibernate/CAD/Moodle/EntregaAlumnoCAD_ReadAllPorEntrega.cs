
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
    public partial class EntregaAlumnoCAD : BasicCAD, IEntregaAlumnoCAD
    {
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> ReadAllPorEntrega(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct entrega FROM EntregaAlumnoEN as entrega where entrega.Entrega.Id=:id";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("id", id);

                //Paginación
                if (size > 0)
                    result = query.SetFirstResult(first).SetMaxResults(size).
                        List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
                else
                    result = query.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException("Error in EntregaCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
