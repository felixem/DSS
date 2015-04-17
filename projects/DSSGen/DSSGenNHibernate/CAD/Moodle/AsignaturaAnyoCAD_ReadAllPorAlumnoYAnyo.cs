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
        public System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> ReadAllPorAlumnoYAnyo(string p_alumno, int p_anyo, int first, int size)
        {
            System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> result;
            try
            {
                SessionInitializeTransaction();
                String sql = @"select distinct asig FROM AlumnoEN as alu INNER JOIN alu.Expediente as exp INNER JOIN exp.Expedientes_anyo as exp_anyo INNER JOIN exp_anyo.Expedientes_asignatura as exp_asig INNER JOIN exp_asig.Asignatura as asig where exp_anyo.Anyo.Id=:p_anyo AND alu.Email=:p_alumno";
                IQuery query = session.CreateQuery(sql);

                query.SetParameter("p_alumno", p_alumno);
                query.SetParameter("p_anyo", p_anyo);

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
