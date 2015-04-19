
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
public partial class EvaluacionAlumnoCAD : BasicCAD, IEvaluacionAlumnoCAD
{
public EvaluacionAlumnoCAD() : base ()
{
}

public EvaluacionAlumnoCAD(ISession sessionAux) : base (sessionAux)
{
}



public EvaluacionAlumnoEN ReadOIDDefault (int id)
{
        EvaluacionAlumnoEN evaluacionAlumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Get (typeof(EvaluacionAlumnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evaluacionAlumnoEN;
}


public int New_ (EvaluacionAlumnoEN evaluacionAlumno)
{
        try
        {
                SessionInitializeTransaction ();
                if (evaluacionAlumno.Sistema_evaluacion != null) {
                        evaluacionAlumno.Sistema_evaluacion = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), evaluacionAlumno.Sistema_evaluacion.Id);

                        evaluacionAlumno.Sistema_evaluacion.Evaluaciones_alumno.Add (evaluacionAlumno);
                }
                if (evaluacionAlumno.Expediente_evaluacion != null) {
                        evaluacionAlumno.Expediente_evaluacion = (DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN), evaluacionAlumno.Expediente_evaluacion.Id);

                        evaluacionAlumno.Expediente_evaluacion.Evaluacion_alumno = evaluacionAlumno;
                }

                session.Save (evaluacionAlumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evaluacionAlumno.Id;
}

public void Modify (EvaluacionAlumnoEN evaluacionAlumno)
{
        try
        {
                SessionInitializeTransaction ();
                EvaluacionAlumnoEN evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), evaluacionAlumno.Id);
                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
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
                EvaluacionAlumnoEN evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), id);
                session.Delete (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EvaluacionAlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EvaluacionAlumnoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EvaluacionAlumnoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EvaluacionAlumnoEN>();
                else
                        result = session.CreateCriteria (typeof(EvaluacionAlumnoEN)).List<EvaluacionAlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public EvaluacionAlumnoEN ReadOID (int id)
{
        EvaluacionAlumnoEN evaluacionAlumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Get (typeof(EvaluacionAlumnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return evaluacionAlumnoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EvaluacionAlumnoEN self where select count(*) FROM EvaluacionAlumnoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EvaluacionAlumnoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN ReadPorAlumnoYEntrega (string p_alumno, int p_entrega)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EvaluacionAlumnoEN self where select eval FROM EntregaEN entrega INNER JOIN entrega.Evaluacion.Evaluaciones_alumno eval where eval.Expediente_evaluacion.Expediente_asignatura.Expediente_anyo.Expediente.Alumno.Email=:p_alumno AND entrega.Id=:p_entrega";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EvaluacionAlumnoENreadPorAlumnoYEntregaHQL");
                query.SetParameter ("p_alumno", p_alumno);
                query.SetParameter ("p_entrega", p_entrega);


                result = query.UniqueResult<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_expediente_evaluacion (int p_evaluacionalumno, int p_expedienteevaluacion)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);
                evaluacionAlumnoEN.Expediente_evaluacion = (DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN), p_expedienteevaluacion);

                evaluacionAlumnoEN.Expediente_evaluacion.Evaluacion_alumno = evaluacionAlumnoEN;




                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_controles (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);
                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlesENAux = null;
                if (evaluacionAlumnoEN.Controles == null) {
                        evaluacionAlumnoEN.Controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
                }

                foreach (int item in p_controlalumno) {
                        controlesENAux = new DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ();
                        controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), item);
                        controlesENAux.Evaluacion_alumno = evaluacionAlumnoEN;

                        evaluacionAlumnoEN.Controles.Add (controlesENAux);
                }


                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_entregas (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);
                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregasENAux = null;
                if (evaluacionAlumnoEN.Entregas == null) {
                        evaluacionAlumnoEN.Entregas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
                }

                foreach (int item in p_entregaalumno) {
                        entregasENAux = new DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN ();
                        entregasENAux = (DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN), item);
                        entregasENAux.Evaluacion_alumno = evaluacionAlumnoEN;

                        evaluacionAlumnoEN.Entregas.Add (entregasENAux);
                }


                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);
                evaluacionAlumnoEN.Sistema_evaluacion = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), p_sistemaevaluacion);

                evaluacionAlumnoEN.Sistema_evaluacion.Evaluaciones_alumno.Add (evaluacionAlumnoEN);



                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_sistema_evaluacion (int p_evaluacionalumno, int p_sistemaevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);

                if (evaluacionAlumnoEN.Sistema_evaluacion.Id == p_sistemaevaluacion) {
                        evaluacionAlumnoEN.Sistema_evaluacion = null;
                }
                else
                        throw new ModelException ("The identifier " + p_sistemaevaluacion + " in p_sistemaevaluacion you are trying to unrelationer, doesn't exist in EvaluacionAlumnoEN");

                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_controles (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);

                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlesENAux = null;
                if (evaluacionAlumnoEN.Controles != null) {
                        foreach (int item in p_controlalumno) {
                                controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), item);
                                if (evaluacionAlumnoEN.Controles.Contains (controlesENAux) == true) {
                                        evaluacionAlumnoEN.Controles.Remove (controlesENAux);
                                        controlesENAux.Evaluacion_alumno = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_controlalumno you are trying to unrelationer, doesn't exist in EvaluacionAlumnoEN");
                        }
                }

                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_entregas (int p_evaluacionalumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);

                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregasENAux = null;
                if (evaluacionAlumnoEN.Entregas != null) {
                        foreach (int item in p_entregaalumno) {
                                entregasENAux = (DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN), item);
                                if (evaluacionAlumnoEN.Entregas.Contains (entregasENAux) == true) {
                                        evaluacionAlumnoEN.Entregas.Remove (entregasENAux);
                                        entregasENAux.Evaluacion_alumno = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entregaalumno you are trying to unrelationer, doesn't exist in EvaluacionAlumnoEN");
                        }
                }

                session.Update (evaluacionAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EvaluacionAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
