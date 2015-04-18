
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
public AsignaturaAnyoCAD() : base ()
{
}

public AsignaturaAnyoCAD(ISession sessionAux) : base (sessionAux)
{
}



public AsignaturaAnyoEN ReadOIDDefault (int id)
{
        AsignaturaAnyoEN asignaturaAnyoEN = null;

        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Get (typeof(AsignaturaAnyoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asignaturaAnyoEN;
}


public int New_ (AsignaturaAnyoEN asignaturaAnyo)
{
        try
        {
                SessionInitializeTransaction ();
                if (asignaturaAnyo.Anyo != null) {
                        asignaturaAnyo.Anyo = (DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN), asignaturaAnyo.Anyo.Id);

                        asignaturaAnyo.Anyo.Asignaturas.Add (asignaturaAnyo);
                }
                if (asignaturaAnyo.Asignatura != null) {
                        asignaturaAnyo.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), asignaturaAnyo.Asignatura.Id);

                        asignaturaAnyo.Asignatura.Asignaturas_anyo.Add (asignaturaAnyo);
                }

                session.Save (asignaturaAnyo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asignaturaAnyo.Id;
}

public void Modify (AsignaturaAnyoEN asignaturaAnyo)
{
        try
        {
                SessionInitializeTransaction ();
                AsignaturaAnyoEN asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), asignaturaAnyo.Id);
                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id)
{
        try
        {
                SessionInitializeTransaction ();
                AsignaturaAnyoEN asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), id);
                session.Delete (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<AsignaturaAnyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AsignaturaAnyoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AsignaturaAnyoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AsignaturaAnyoEN>();
                else
                        result = session.CreateCriteria (typeof(AsignaturaAnyoEN)).List<AsignaturaAnyoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public AsignaturaAnyoEN ReadOID (int id)
{
        AsignaturaAnyoEN asignaturaAnyoEN = null;

        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Get (typeof(AsignaturaAnyoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asignaturaAnyoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaAnyoEN self where select count(*) FROM AsignaturaAnyoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaAnyoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public long ReadCantidadPorAnyo (int id)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaAnyoEN self where select count(*) FROM AsignaturaAnyoEN asig where asig.Anyo.Id=:id ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaAnyoENreadCantidadPorAnyoHQL");
                query.SetParameter ("id", id);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public long ReadCantidadPorAlumnoYAnyo (string p_alumno, int p_anyo)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaAnyoEN self where select count(distinct asig) FROM AlumnoEN as alu INNER JOIN alu.Expediente as exp INNER JOIN exp.Expedientes_anyo as exp_anyo INNER JOIN exp_anyo.Expedientes_asignatura as exp_asig INNER JOIN exp_asig.Asignatura as asig where exp_anyo.Anyo.Id=:p_anyo AND alu.Email=:p_alumno";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaAnyoENreadCantidadPorAlumnoYAnyoHQL");
                query.SetParameter ("p_alumno", p_alumno);
                query.SetParameter ("p_anyo", p_anyo);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public long ReadCantidadPorAnyoYProfesor (int p_anyo, string p_profesor)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaAnyoEN self where select count(distinct asig) FROM AsignaturaAnyoEN as asig INNER JOIN asig.Profesores as profesor INNER JOIN asig.Anyo as anyo where anyo.Id=:p_anyo AND profesor.Email=:p_profesor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaAnyoENreadCantidadPorAnyoYProfesorHQL");
                query.SetParameter ("p_anyo", p_anyo);
                query.SetParameter ("p_profesor", p_profesor);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ReadRelation (int p_asignatura, int p_anyo)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaAnyoEN self where FROM AsignaturaAnyoEN as_anyo where as_anyo.Asignatura.Id=:p_asignatura AND as_anyo.Anyo.Id=:p_anyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaAnyoENreadRelationHQL");
                query.SetParameter ("p_asignatura", p_asignatura);
                query.SetParameter ("p_anyo", p_anyo);


                result = query.UniqueResult<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_grupos_trabajo (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);
                DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupos_trabajoENAux = null;
                if (asignaturaAnyoEN.Grupos_trabajo == null) {
                        asignaturaAnyoEN.Grupos_trabajo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();
                }

                foreach (int item in p_grupotrabajo) {
                        grupos_trabajoENAux = new DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN ();
                        grupos_trabajoENAux = (DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN), item);
                        grupos_trabajoENAux.Asignatura = asignaturaAnyoEN;

                        asignaturaAnyoEN.Grupos_trabajo.Add (grupos_trabajoENAux);
                }


                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_materiales (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_material)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);
                DSSGenNHibernate.EN.Moodle.MaterialEN materialesENAux = null;
                if (asignaturaAnyoEN.Materiales == null) {
                        asignaturaAnyoEN.Materiales = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MaterialEN>();
                }

                foreach (int item in p_material) {
                        materialesENAux = new DSSGenNHibernate.EN.Moodle.MaterialEN ();
                        materialesENAux = (DSSGenNHibernate.EN.Moodle.MaterialEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MaterialEN), item);
                        materialesENAux.Asignatura = asignaturaAnyoEN;

                        asignaturaAnyoEN.Materiales.Add (materialesENAux);
                }


                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_sistemas_evaluacion (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemas_evaluacionENAux = null;
                if (asignaturaAnyoEN.Sistemas_evaluacion == null) {
                        asignaturaAnyoEN.Sistemas_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN>();
                }

                foreach (int item in p_sistemaevaluacion) {
                        sistemas_evaluacionENAux = new DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ();
                        sistemas_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), item);
                        sistemas_evaluacionENAux.Asignatura = asignaturaAnyoEN;

                        asignaturaAnyoEN.Sistemas_evaluacion.Add (sistemas_evaluacionENAux);
                }


                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_tutorias (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_tutoria)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriasENAux = null;
                if (asignaturaAnyoEN.Tutorias == null) {
                        asignaturaAnyoEN.Tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
                }

                foreach (int item in p_tutoria) {
                        tutoriasENAux = new DSSGenNHibernate.EN.Moodle.TutoriaEN ();
                        tutoriasENAux = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), item);
                        tutoriasENAux.Asignatura = asignaturaAnyoEN;

                        asignaturaAnyoEN.Tutorias.Add (tutoriasENAux);
                }


                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expedientes_asignatura (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedientes_asignaturaENAux = null;
                if (asignaturaAnyoEN.Expedientes_asignatura == null) {
                        asignaturaAnyoEN.Expedientes_asignatura = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN>();
                }

                foreach (int item in p_expedienteasignatura) {
                        expedientes_asignaturaENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN ();
                        expedientes_asignaturaENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), item);
                        expedientes_asignaturaENAux.Asignatura = asignaturaAnyoEN;

                        asignaturaAnyoEN.Expedientes_asignatura.Add (expedientes_asignaturaENAux);
                }


                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_profesores (int p_asignaturaanyo, System.Collections.Generic.IList<string> p_profesor)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);
                DSSGenNHibernate.EN.Moodle.ProfesorEN profesoresENAux = null;
                if (asignaturaAnyoEN.Profesores == null) {
                        asignaturaAnyoEN.Profesores = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ProfesorEN>();
                }

                foreach (string item in p_profesor) {
                        profesoresENAux = new DSSGenNHibernate.EN.Moodle.ProfesorEN ();
                        profesoresENAux = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), item);
                        profesoresENAux.Asignaturas.Add (asignaturaAnyoEN);

                        asignaturaAnyoEN.Profesores.Add (profesoresENAux);
                }


                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_grupos_trabajo (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);

                DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupos_trabajoENAux = null;
                if (asignaturaAnyoEN.Grupos_trabajo != null) {
                        foreach (int item in p_grupotrabajo) {
                                grupos_trabajoENAux = (DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN), item);
                                if (asignaturaAnyoEN.Grupos_trabajo.Contains (grupos_trabajoENAux) == true) {
                                        asignaturaAnyoEN.Grupos_trabajo.Remove (grupos_trabajoENAux);
                                        grupos_trabajoENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_grupotrabajo you are trying to unrelationer, doesn't exist in AsignaturaAnyoEN");
                        }
                }

                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_materiales (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_material)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);

                DSSGenNHibernate.EN.Moodle.MaterialEN materialesENAux = null;
                if (asignaturaAnyoEN.Materiales != null) {
                        foreach (int item in p_material) {
                                materialesENAux = (DSSGenNHibernate.EN.Moodle.MaterialEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MaterialEN), item);
                                if (asignaturaAnyoEN.Materiales.Contains (materialesENAux) == true) {
                                        asignaturaAnyoEN.Materiales.Remove (materialesENAux);
                                        materialesENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_material you are trying to unrelationer, doesn't exist in AsignaturaAnyoEN");
                        }
                }

                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_sistemas_evaluacion (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);

                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemas_evaluacionENAux = null;
                if (asignaturaAnyoEN.Sistemas_evaluacion != null) {
                        foreach (int item in p_sistemaevaluacion) {
                                sistemas_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), item);
                                if (asignaturaAnyoEN.Sistemas_evaluacion.Contains (sistemas_evaluacionENAux) == true) {
                                        asignaturaAnyoEN.Sistemas_evaluacion.Remove (sistemas_evaluacionENAux);
                                        sistemas_evaluacionENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_sistemaevaluacion you are trying to unrelationer, doesn't exist in AsignaturaAnyoEN");
                        }
                }

                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_tutorias (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_tutoria)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);

                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriasENAux = null;
                if (asignaturaAnyoEN.Tutorias != null) {
                        foreach (int item in p_tutoria) {
                                tutoriasENAux = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), item);
                                if (asignaturaAnyoEN.Tutorias.Contains (tutoriasENAux) == true) {
                                        asignaturaAnyoEN.Tutorias.Remove (tutoriasENAux);
                                        tutoriasENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_tutoria you are trying to unrelationer, doesn't exist in AsignaturaAnyoEN");
                        }
                }

                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expedientes_asignatura (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);

                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedientes_asignaturaENAux = null;
                if (asignaturaAnyoEN.Expedientes_asignatura != null) {
                        foreach (int item in p_expedienteasignatura) {
                                expedientes_asignaturaENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), item);
                                if (asignaturaAnyoEN.Expedientes_asignatura.Contains (expedientes_asignaturaENAux) == true) {
                                        asignaturaAnyoEN.Expedientes_asignatura.Remove (expedientes_asignaturaENAux);
                                        expedientes_asignaturaENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteasignatura you are trying to unrelationer, doesn't exist in AsignaturaAnyoEN");
                        }
                }

                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_profesores (int p_asignaturaanyo, System.Collections.Generic.IList<string> p_profesor)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturaAnyoEN = null;
                asignaturaAnyoEN = (AsignaturaAnyoEN)session.Load (typeof(AsignaturaAnyoEN), p_asignaturaanyo);

                DSSGenNHibernate.EN.Moodle.ProfesorEN profesoresENAux = null;
                if (asignaturaAnyoEN.Profesores != null) {
                        foreach (string item in p_profesor) {
                                profesoresENAux = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), item);
                                if (asignaturaAnyoEN.Profesores.Contains (profesoresENAux) == true) {
                                        asignaturaAnyoEN.Profesores.Remove (profesoresENAux);
                                        profesoresENAux.Asignaturas.Remove (asignaturaAnyoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_profesor you are trying to unrelationer, doesn't exist in AsignaturaAnyoEN");
                        }
                }

                session.Update (asignaturaAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
