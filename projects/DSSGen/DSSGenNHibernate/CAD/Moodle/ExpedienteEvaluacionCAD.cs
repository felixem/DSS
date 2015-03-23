
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
public partial class ExpedienteEvaluacionCAD : BasicCAD, IExpedienteEvaluacionCAD
{
public ExpedienteEvaluacionCAD() : base ()
{
}

public ExpedienteEvaluacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public ExpedienteEvaluacionEN ReadOIDDefault (int id)
{
        ExpedienteEvaluacionEN expedienteEvaluacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Get (typeof(ExpedienteEvaluacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteEvaluacionEN;
}


public int New_ (ExpedienteEvaluacionEN expedienteEvaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (expedienteEvaluacion.Expediente_asignatura != null) {
                        expedienteEvaluacion.Expediente_asignatura = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), expedienteEvaluacion.Expediente_asignatura.Id);

                        expedienteEvaluacion.Expediente_asignatura.Expedientes_evaluacion.Add (expedienteEvaluacion);
                }
                if (expedienteEvaluacion.Evaluacion != null) {
                        expedienteEvaluacion.Evaluacion = (DSSGenNHibernate.EN.Moodle.EvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionEN), expedienteEvaluacion.Evaluacion.Id);

                        expedienteEvaluacion.Evaluacion.Expedientes.Add (expedienteEvaluacion);
                }

                session.Save (expedienteEvaluacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteEvaluacion.Id;
}

public void Modify (ExpedienteEvaluacionEN expedienteEvaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                ExpedienteEvaluacionEN expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Load (typeof(ExpedienteEvaluacionEN), expedienteEvaluacion.Id);

                expedienteEvaluacionEN.Nota_media = expedienteEvaluacion.Nota_media;


                expedienteEvaluacionEN.Abierto = expedienteEvaluacion.Abierto;

                session.Update (expedienteEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
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
                ExpedienteEvaluacionEN expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Load (typeof(ExpedienteEvaluacionEN), id);
                session.Delete (expedienteEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ExpedienteEvaluacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteEvaluacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ExpedienteEvaluacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ExpedienteEvaluacionEN>();
                else
                        result = session.CreateCriteria (typeof(ExpedienteEvaluacionEN)).List<ExpedienteEvaluacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ExpedienteEvaluacionEN ReadOID (int id)
{
        ExpedienteEvaluacionEN expedienteEvaluacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Get (typeof(ExpedienteEvaluacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteEvaluacionEN;
}

public void Relationer_evaluacion (int p_expedienteevaluacion, int p_evaluacion)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedienteEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Load (typeof(ExpedienteEvaluacionEN), p_expedienteevaluacion);
                expedienteEvaluacionEN.Evaluacion = (DSSGenNHibernate.EN.Moodle.EvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionEN), p_evaluacion);

                expedienteEvaluacionEN.Evaluacion.Expedientes.Add (expedienteEvaluacionEN);



                session.Update (expedienteEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expediente_asignatura (int p_expedienteevaluacion, int p_expedienteasignatura)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedienteEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Load (typeof(ExpedienteEvaluacionEN), p_expedienteevaluacion);
                expedienteEvaluacionEN.Expediente_asignatura = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), p_expedienteasignatura);

                expedienteEvaluacionEN.Expediente_asignatura.Expedientes_evaluacion.Add (expedienteEvaluacionEN);



                session.Update (expedienteEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_evaluacion (int p_expedienteevaluacion, int p_evaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedienteEvaluacionEN = null;
                expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Load (typeof(ExpedienteEvaluacionEN), p_expedienteevaluacion);

                if (expedienteEvaluacionEN.Evaluacion.Id == p_evaluacion) {
                        expedienteEvaluacionEN.Evaluacion = null;
                }
                else
                        throw new ModelException ("The identifier " + p_evaluacion + " in p_evaluacion you are trying to unrelationer, doesn't exist in ExpedienteEvaluacionEN");

                session.Update (expedienteEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expediente_asignatura (int p_expedienteevaluacion, int p_expedienteasignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedienteEvaluacionEN = null;
                expedienteEvaluacionEN = (ExpedienteEvaluacionEN)session.Load (typeof(ExpedienteEvaluacionEN), p_expedienteevaluacion);

                if (expedienteEvaluacionEN.Expediente_asignatura.Id == p_expedienteasignatura) {
                        expedienteEvaluacionEN.Expediente_asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_expedienteasignatura + " in p_expedienteasignatura you are trying to unrelationer, doesn't exist in ExpedienteEvaluacionEN");

                session.Update (expedienteEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
