
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
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> ReadAllMatriculablesEnAsignaturaAnyo(int id, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct alu FROM AlumnoEN as alu INNER JOIN alu.Expediente as exp INNER JOIN exp.Expedientes_anyo as exp_anyo INNER JOIN exp_anyo.Anyo as anyo where anyo.Id IN (select year.Id FROM AsignaturaAnyoEN as asig INNER JOIN asig.Anyo as year where asig.Id=:id) AND exp_anyo.Id NOT IN (select ex_anyo.Id FROM AsignaturaAnyoEN as asignatura INNER JOIN asignatura.Expedientes_asignatura as expedi INNER JOIN expedi.Expediente_anyo as ex_anyo where asignatura.Id=:id)";
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
