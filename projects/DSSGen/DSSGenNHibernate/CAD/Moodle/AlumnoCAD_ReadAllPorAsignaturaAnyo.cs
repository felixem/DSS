
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
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllPorAsignaturaAnyo(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct alu FROM AsignaturaAnyoEN as asig INNER JOIN asig.Expedientes_asignatura as exp_asig INNER JOIN exp_asig.Expediente_anyo as exp_anyo INNER JOIN exp_anyo.Expediente as exp INNER JOIN exp.Alumno as alu where asig.Id=:id";
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
