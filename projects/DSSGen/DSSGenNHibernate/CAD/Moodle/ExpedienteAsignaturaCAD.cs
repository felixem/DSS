
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
public partial class ExpedienteAsignaturaCAD : BasicCAD, IExpedienteAsignaturaCAD
{
public ExpedienteAsignaturaCAD() : base ()
{
}

public ExpedienteAsignaturaCAD(ISession sessionAux) : base (sessionAux)
{
}



public ExpedienteAsignaturaEN ReadOIDDefault (int id)
{
        ExpedienteAsignaturaEN expedienteAsignaturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Get (typeof(ExpedienteAsignaturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteAsignaturaEN;
}


public int New_ (ExpedienteAsignaturaEN expedienteAsignatura)
{
        try
        {
                SessionInitializeTransaction ();
                if (expedienteAsignatura.Expediente_anyo != null) {
                        expedienteAsignatura.Expediente_anyo = (DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN), expedienteAsignatura.Expediente_anyo.Id);

                        expedienteAsignatura.Expediente_anyo.Expedientes_asignatura.Add (expedienteAsignatura);
                }
                if (expedienteAsignatura.Asignatura != null) {
                        expedienteAsignatura.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), expedienteAsignatura.Asignatura.Id);

                        expedienteAsignatura.Asignatura.Expedientes_asignatura.Add (expedienteAsignatura);
                }

                session.Save (expedienteAsignatura);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteAsignatura.Id;
}

public void Modify (ExpedienteAsignaturaEN expedienteAsignatura)
{
        try
        {
                SessionInitializeTransaction ();
                ExpedienteAsignaturaEN expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), expedienteAsignatura.Id);

                expedienteAsignaturaEN.Nota_media = expedienteAsignatura.Nota_media;


                expedienteAsignaturaEN.Abierto = expedienteAsignatura.Abierto;

                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
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
                ExpedienteAsignaturaEN expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), id);
                session.Delete (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ExpedienteAsignaturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteAsignaturaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ExpedienteAsignaturaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ExpedienteAsignaturaEN>();
                else
                        result = session.CreateCriteria (typeof(ExpedienteAsignaturaEN)).List<ExpedienteAsignaturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ExpedienteAsignaturaEN ReadOID (int id)
{
        ExpedienteAsignaturaEN expedienteAsignaturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Get (typeof(ExpedienteAsignaturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteAsignaturaEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ExpedienteAsignaturaEN self where select count(*) FROM ExpedienteAsignaturaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ExpedienteAsignaturaENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_asignatura (int p_expedienteasignatura, int p_asignatura)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);
                expedienteAsignaturaEN.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), p_asignatura);

                expedienteAsignaturaEN.Asignatura.Expedientes_asignatura.Add (expedienteAsignaturaEN);



                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expediente_anyo (int p_expedienteasignatura, int p_expedienteanyo)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);
                expedienteAsignaturaEN.Expediente_anyo = (DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN), p_expedienteanyo);

                expedienteAsignaturaEN.Expediente_anyo.Expedientes_asignatura.Add (expedienteAsignaturaEN);



                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expedientes_evaluacion (int p_expedienteasignatura, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);
                DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedientes_evaluacionENAux = null;
                if (expedienteAsignaturaEN.Expedientes_evaluacion == null) {
                        expedienteAsignaturaEN.Expedientes_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN>();
                }

                foreach (int item in p_expedienteevaluacion) {
                        expedientes_evaluacionENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN ();
                        expedientes_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN), item);
                        expedientes_evaluacionENAux.Expediente_asignatura = expedienteAsignaturaEN;

                        expedienteAsignaturaEN.Expedientes_evaluacion.Add (expedientes_evaluacionENAux);
                }


                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_nota (int p_expedienteasignatura, int p_nota)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);
                expedienteAsignaturaEN.Nota = (DSSGenNHibernate.EN.Moodle.NotaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.NotaEN), p_nota);



                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignatura (int p_expedienteasignatura, int p_asignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);

                if (expedienteAsignaturaEN.Asignatura.Id == p_asignatura) {
                        expedienteAsignaturaEN.Asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_asignatura + " in p_asignatura you are trying to unrelationer, doesn't exist in ExpedienteAsignaturaEN");

                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expediente_anyo (int p_expedienteasignatura, int p_expedienteanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);

                if (expedienteAsignaturaEN.Expediente_anyo.Id == p_expedienteanyo) {
                        expedienteAsignaturaEN.Expediente_anyo = null;
                }
                else
                        throw new ModelException ("The identifier " + p_expedienteanyo + " in p_expedienteanyo you are trying to unrelationer, doesn't exist in ExpedienteAsignaturaEN");

                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expedientes_evaluacion (int p_expedienteasignatura, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);

                DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedientes_evaluacionENAux = null;
                if (expedienteAsignaturaEN.Expedientes_evaluacion != null) {
                        foreach (int item in p_expedienteevaluacion) {
                                expedientes_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN), item);
                                if (expedienteAsignaturaEN.Expedientes_evaluacion.Contains (expedientes_evaluacionENAux) == true) {
                                        expedienteAsignaturaEN.Expedientes_evaluacion.Remove (expedientes_evaluacionENAux);
                                        expedientes_evaluacionENAux.Expediente_asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteevaluacion you are trying to unrelationer, doesn't exist in ExpedienteAsignaturaEN");
                        }
                }

                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_nota (int p_expedienteasignatura, int p_nota)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
                expedienteAsignaturaEN = (ExpedienteAsignaturaEN)session.Load (typeof(ExpedienteAsignaturaEN), p_expedienteasignatura);

                if (expedienteAsignaturaEN.Nota.Id == p_nota) {
                        expedienteAsignaturaEN.Nota = null;
                }
                else
                        throw new ModelException ("The identifier " + p_nota + " in p_nota you are trying to unrelationer, doesn't exist in ExpedienteAsignaturaEN");

                session.Update (expedienteAsignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
