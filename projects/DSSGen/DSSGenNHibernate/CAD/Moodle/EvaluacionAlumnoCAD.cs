
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
                if (evaluacionAlumno.Alumno != null) {
                        evaluacionAlumno.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), evaluacionAlumno.Alumno.Email);

                        evaluacionAlumno.Alumno.Sistemas_evaluacion.Add (evaluacionAlumno);
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

public void Relationer_alumno (int p_evaluacionalumno, string p_alumno)
{
        DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);
                evaluacionAlumnoEN.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), p_alumno);

                evaluacionAlumnoEN.Alumno.Sistemas_evaluacion.Add (evaluacionAlumnoEN);



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

public void Unrelationer_alumno (int p_evaluacionalumno, string p_alumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacionAlumnoEN = null;
                evaluacionAlumnoEN = (EvaluacionAlumnoEN)session.Load (typeof(EvaluacionAlumnoEN), p_evaluacionalumno);

                if (evaluacionAlumnoEN.Alumno.Email == p_alumno) {
                        evaluacionAlumnoEN.Alumno = null;
                }
                else
                        throw new ModelException ("The identifier " + p_alumno + " in p_alumno you are trying to unrelationer, doesn't exist in EvaluacionAlumnoEN");

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
}
}
