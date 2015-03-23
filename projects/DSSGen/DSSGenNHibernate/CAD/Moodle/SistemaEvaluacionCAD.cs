
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
public partial class SistemaEvaluacionCAD : BasicCAD, ISistemaEvaluacionCAD
{
public SistemaEvaluacionCAD() : base ()
{
}

public SistemaEvaluacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public SistemaEvaluacionEN ReadOIDDefault (int id)
{
        SistemaEvaluacionEN sistemaEvaluacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Get (typeof(SistemaEvaluacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sistemaEvaluacionEN;
}


public int New_ (SistemaEvaluacionEN sistemaEvaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (sistemaEvaluacion.Asignatura != null) {
                        sistemaEvaluacion.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), sistemaEvaluacion.Asignatura.Id);

                        sistemaEvaluacion.Asignatura.Sistemas_evaluacion.Add (sistemaEvaluacion);
                }
                if (sistemaEvaluacion.Evaluacion != null) {
                        sistemaEvaluacion.Evaluacion = (DSSGenNHibernate.EN.Moodle.EvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionEN), sistemaEvaluacion.Evaluacion.Id);

                        sistemaEvaluacion.Evaluacion.Sistemas_evaluacion.Add (sistemaEvaluacion);
                }

                session.Save (sistemaEvaluacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sistemaEvaluacion.Id;
}

public void Modify (SistemaEvaluacionEN sistemaEvaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                SistemaEvaluacionEN sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), sistemaEvaluacion.Id);

                sistemaEvaluacionEN.Puntuacion_maxima = sistemaEvaluacion.Puntuacion_maxima;

                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
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
                SistemaEvaluacionEN sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), id);
                session.Delete (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<SistemaEvaluacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<SistemaEvaluacionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(SistemaEvaluacionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<SistemaEvaluacionEN>();
                else
                        result = session.CreateCriteria (typeof(SistemaEvaluacionEN)).List<SistemaEvaluacionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public SistemaEvaluacionEN ReadOID (int id)
{
        SistemaEvaluacionEN sistemaEvaluacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Get (typeof(SistemaEvaluacionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return sistemaEvaluacionEN;
}

public void Relationer_asignatura (int p_sistemaevaluacion, int p_asignaturaanyo)
{
        DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);
                sistemaEvaluacionEN.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), p_asignaturaanyo);

                sistemaEvaluacionEN.Asignatura.Sistemas_evaluacion.Add (sistemaEvaluacionEN);



                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_controles (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_control)
{
        DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);
                DSSGenNHibernate.EN.Moodle.ControlEN controlesENAux = null;
                if (sistemaEvaluacionEN.Controles == null) {
                        sistemaEvaluacionEN.Controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlEN>();
                }

                foreach (int item in p_control) {
                        controlesENAux = new DSSGenNHibernate.EN.Moodle.ControlEN ();
                        controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlEN), item);
                        controlesENAux.Sistema_evaluacion = sistemaEvaluacionEN;

                        sistemaEvaluacionEN.Controles.Add (controlesENAux);
                }


                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_entregas (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_entrega)
{
        DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);
                DSSGenNHibernate.EN.Moodle.EntregaEN entregasENAux = null;
                if (sistemaEvaluacionEN.Entregas == null) {
                        sistemaEvaluacionEN.Entregas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaEN>();
                }

                foreach (int item in p_entrega) {
                        entregasENAux = new DSSGenNHibernate.EN.Moodle.EntregaEN ();
                        entregasENAux = (DSSGenNHibernate.EN.Moodle.EntregaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaEN), item);
                        entregasENAux.Evaluacion = sistemaEvaluacionEN;

                        sistemaEvaluacionEN.Entregas.Add (entregasENAux);
                }


                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_evaluacion (int p_sistemaevaluacion, int p_evaluacion)
{
        DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);
                sistemaEvaluacionEN.Evaluacion = (DSSGenNHibernate.EN.Moodle.EvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionEN), p_evaluacion);

                sistemaEvaluacionEN.Evaluacion.Sistemas_evaluacion.Add (sistemaEvaluacionEN);



                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_evaluaciones_alumno (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
        try
        {
                SessionInitializeTransaction ();
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);
                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluaciones_alumnoENAux = null;
                if (sistemaEvaluacionEN.Evaluaciones_alumno == null) {
                        sistemaEvaluacionEN.Evaluaciones_alumno = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN>();
                }

                foreach (int item in p_evaluacionalumno) {
                        evaluaciones_alumnoENAux = new DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN ();
                        evaluaciones_alumnoENAux = (DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN), item);
                        evaluaciones_alumnoENAux.Sistema_evaluacion = sistemaEvaluacionEN;

                        sistemaEvaluacionEN.Evaluaciones_alumno.Add (evaluaciones_alumnoENAux);
                }


                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignatura (int p_sistemaevaluacion, int p_asignaturaanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);

                if (sistemaEvaluacionEN.Asignatura.Id == p_asignaturaanyo) {
                        sistemaEvaluacionEN.Asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_asignaturaanyo + " in p_asignaturaanyo you are trying to unrelationer, doesn't exist in SistemaEvaluacionEN");

                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_controles (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_control)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);

                DSSGenNHibernate.EN.Moodle.ControlEN controlesENAux = null;
                if (sistemaEvaluacionEN.Controles != null) {
                        foreach (int item in p_control) {
                                controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlEN), item);
                                if (sistemaEvaluacionEN.Controles.Contains (controlesENAux) == true) {
                                        sistemaEvaluacionEN.Controles.Remove (controlesENAux);
                                        controlesENAux.Sistema_evaluacion = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_control you are trying to unrelationer, doesn't exist in SistemaEvaluacionEN");
                        }
                }

                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_entregas (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_entrega)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);

                DSSGenNHibernate.EN.Moodle.EntregaEN entregasENAux = null;
                if (sistemaEvaluacionEN.Entregas != null) {
                        foreach (int item in p_entrega) {
                                entregasENAux = (DSSGenNHibernate.EN.Moodle.EntregaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaEN), item);
                                if (sistemaEvaluacionEN.Entregas.Contains (entregasENAux) == true) {
                                        sistemaEvaluacionEN.Entregas.Remove (entregasENAux);
                                        entregasENAux.Evaluacion = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entrega you are trying to unrelationer, doesn't exist in SistemaEvaluacionEN");
                        }
                }

                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_evaluacion (int p_sistemaevaluacion, int p_evaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);

                if (sistemaEvaluacionEN.Evaluacion.Id == p_evaluacion) {
                        sistemaEvaluacionEN.Evaluacion = null;
                }
                else
                        throw new ModelException ("The identifier " + p_evaluacion + " in p_evaluacion you are trying to unrelationer, doesn't exist in SistemaEvaluacionEN");

                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_evaluaciones_alumno (int p_sistemaevaluacion, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistemaEvaluacionEN = null;
                sistemaEvaluacionEN = (SistemaEvaluacionEN)session.Load (typeof(SistemaEvaluacionEN), p_sistemaevaluacion);

                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluaciones_alumnoENAux = null;
                if (sistemaEvaluacionEN.Evaluaciones_alumno != null) {
                        foreach (int item in p_evaluacionalumno) {
                                evaluaciones_alumnoENAux = (DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN), item);
                                if (sistemaEvaluacionEN.Evaluaciones_alumno.Contains (evaluaciones_alumnoENAux) == true) {
                                        sistemaEvaluacionEN.Evaluaciones_alumno.Remove (evaluaciones_alumnoENAux);
                                        evaluaciones_alumnoENAux.Sistema_evaluacion = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_evaluacionalumno you are trying to unrelationer, doesn't exist in SistemaEvaluacionEN");
                        }
                }

                session.Update (sistemaEvaluacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in SistemaEvaluacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
