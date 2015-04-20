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
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAnyoYProfesor(int p_anyo, string p_profesor, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> result;
            try
            {

                SessionInitializeTransaction();

                String sql = @"select distinct asig FROM AsignaturaAnyoEN as asig INNER JOIN asig.Profesores as profesor INNER JOIN asig.Anyo as anyo where anyo.Id=:p_anyo AND profesor.Email=:p_profesor";
                IQuery query = session.CreateQuery(sql);
                query.SetParameter("p_anyo", p_anyo);
                query.SetParameter("p_profesor", p_profesor);

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
