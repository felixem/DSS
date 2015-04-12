
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
public partial class EvaluacionCAD : BasicCAD, IEvaluacionCAD
{
public EvaluacionCAD() : base ()
{
}

public EvaluacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public EvaluacionEN ReadOIDDefault (int id)
{
        EvaluacionEN evaluacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                evaluacionEN = (EvaluacionEN)session.Get (typeof(EvaluacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evaluacionEN;
}


public int New_ (EvaluacionEN evaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (evaluacion.Anyo_academico != null) {
                        evaluacion.Anyo_academico = (DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN), evaluacion.Anyo_academico.Id);

                        evaluacion.Anyo_academico.Evaluaciones.Add (evaluacion);
                }

                session.Save (evaluacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evaluacion.Id;
}

public void Modify (EvaluacionEN evaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                EvaluacionEN evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), evaluacion.Id);

                evaluacionEN.Nombre = evaluacion.Nombre;


                evaluacionEN.Fecha_inicio = evaluacion.Fecha_inicio;


                evaluacionEN.Fecha_fin = evaluacion.Fecha_fin;


                evaluacionEN.Abierta = evaluacion.Abierta;

                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
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
                EvaluacionEN evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), id);
                session.Delete (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EvaluacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EvaluacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EvaluacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EvaluacionEN>();
                else
                        result = session.CreateCriteria (typeof(EvaluacionEN)).List<EvaluacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public EvaluacionEN ReadOID (int id)
{
        EvaluacionEN evaluacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                evaluacionEN = (EvaluacionEN)session.Get (typeof(EvaluacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evaluacionEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EvaluacionEN self where select count(*) FROM EvaluacionEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EvaluacionENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_anyo_academico (int p_evaluacion, int p_anyoacademico)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), p_evaluacion);
                evaluacionEN.Anyo_academico = (DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN), p_anyoacademico);

                evaluacionEN.Anyo_academico.Evaluaciones.Add (evaluacionEN);



                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expedientes (int p_evaluacion, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), p_evaluacion);
                DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedientesENAux = null;
                if (evaluacionEN.Expedientes == null) {
                        evaluacionEN.Expedientes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN>();
                }

                foreach (int item in p_expedienteevaluacion) {
                        expedientesENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN ();
                        expedientesENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN), item);
                        expedientesENAux.Evaluacion = evaluacionEN;

                        evaluacionEN.Expedientes.Add (expedientesENAux);
                }


                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_sistemas_evaluacion (int p_evaluacion, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), p_evaluacion);
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemas_evaluacionENAux = null;
                if (evaluacionEN.Sistemas_evaluacion == null) {
                        evaluacionEN.Sistemas_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN>();
                }

                foreach (int item in p_sistemaevaluacion) {
                        sistemas_evaluacionENAux = new DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ();
                        sistemas_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), item);
                        sistemas_evaluacionENAux.Evaluacion = evaluacionEN;

                        evaluacionEN.Sistemas_evaluacion.Add (sistemas_evaluacionENAux);
                }


                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_anyo_academico (int p_evaluacion, int p_anyoacademico)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionEN = null;
                evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), p_evaluacion);

                if (evaluacionEN.Anyo_academico.Id == p_anyoacademico) {
                        evaluacionEN.Anyo_academico = null;
                }
                else
                        throw new ModelException ("The identifier " + p_anyoacademico + " in p_anyoacademico you are trying to unrelationer, doesn't exist in EvaluacionEN");

                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expedientes (int p_evaluacion, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionEN = null;
                evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), p_evaluacion);

                DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expedientesENAux = null;
                if (evaluacionEN.Expedientes != null) {
                        foreach (int item in p_expedienteevaluacion) {
                                expedientesENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN), item);
                                if (evaluacionEN.Expedientes.Contains (expedientesENAux) == true) {
                                        evaluacionEN.Expedientes.Remove (expedientesENAux);
                                        expedientesENAux.Evaluacion = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteevaluacion you are trying to unrelationer, doesn't exist in EvaluacionEN");
                        }
                }

                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_sistemas_evaluacion (int p_evaluacion, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionEN = null;
                evaluacionEN = (EvaluacionEN)session.Load (typeof(EvaluacionEN), p_evaluacion);

                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemas_evaluacionENAux = null;
                if (evaluacionEN.Sistemas_evaluacion != null) {
                        foreach (int item in p_sistemaevaluacion) {
                                sistemas_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), item);
                                if (evaluacionEN.Sistemas_evaluacion.Contains (sistemas_evaluacionENAux) == true) {
                                        evaluacionEN.Sistemas_evaluacion.Remove (sistemas_evaluacionENAux);
                                        sistemas_evaluacionENAux.Evaluacion = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_sistemaevaluacion you are trying to unrelationer, doesn't exist in EvaluacionEN");
                        }
                }

                session.Update (evaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
