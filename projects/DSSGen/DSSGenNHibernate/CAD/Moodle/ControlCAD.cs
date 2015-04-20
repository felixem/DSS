
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
public partial class ControlCAD : BasicCAD, IControlCAD
{
public ControlCAD() : base ()
{
}

public ControlCAD(ISession sessionAux) : base (sessionAux)
{
}



public ControlEN ReadOIDDefault (int id)
{
        ControlEN controlEN = null;

        try
        {
                SessionInitializeTransaction ();
                controlEN = (ControlEN)session.Get (typeof(ControlEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return controlEN;
}


public int New_ (ControlEN control)
{
        try
        {
                SessionInitializeTransaction ();
                if (control.Sistema_evaluacion != null) {
                        control.Sistema_evaluacion = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), control.Sistema_evaluacion.Id);

                        control.Sistema_evaluacion.Controles.Add (control);
                }

                session.Save (control);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return control.Id;
}

public void Modify (ControlEN control)
{
        try
        {
                SessionInitializeTransaction ();
                ControlEN controlEN = (ControlEN)session.Load (typeof(ControlEN), control.Id);

                controlEN.Nombre = control.Nombre;


                controlEN.Descripcion = control.Descripcion;


                controlEN.Fecha_apertura = control.Fecha_apertura;


                controlEN.Fecha_cierre = control.Fecha_cierre;


                controlEN.Duracion_minutos = control.Duracion_minutos;


                controlEN.Puntuacion_maxima = control.Puntuacion_maxima;


                controlEN.Penalizacion_fallo = control.Penalizacion_fallo;

                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
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
                ControlEN controlEN = (ControlEN)session.Load (typeof(ControlEN), id);
                session.Delete (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ControlEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ControlEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ControlEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ControlEN>();
                else
                        result = session.CreateCriteria (typeof(ControlEN)).List<ControlEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ControlEN ReadOID (int id)
{
        ControlEN controlEN = null;

        try
        {
                SessionInitializeTransaction ();
                controlEN = (ControlEN)session.Get (typeof(ControlEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return controlEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ControlEN self where select count(*) FROM ControlEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ControlENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public long ReadCantidadPorAsignaturaAnyo (int id)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ControlEN self where select count (distinct control) FROM ControlEN as control where control.Sistema_evaluacion.Asignatura.Id=:id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ControlENreadCantidadPorAsignaturaAnyoHQL");
                query.SetParameter ("id", id);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_bolsas_preguntas (int p_control, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        DSSGenNHibernate.EN.Moodle.ControlEN controlEN = null;
        try
        {
                SessionInitializeTransaction ();
                controlEN = (ControlEN)session.Load (typeof(ControlEN), p_control);
                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsas_preguntasENAux = null;
                if (controlEN.Bolsas_preguntas == null) {
                        controlEN.Bolsas_preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN>();
                }

                foreach (int item in p_bolsapreguntas) {
                        bolsas_preguntasENAux = new DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN ();
                        bolsas_preguntasENAux = (DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN), item);
                        bolsas_preguntasENAux.Controles.Add (controlEN);

                        controlEN.Bolsas_preguntas.Add (bolsas_preguntasENAux);
                }


                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_controles_alumno (int p_control, System.Collections.Generic.IList<int> p_controlalumno)
{
        DSSGenNHibernate.EN.Moodle.ControlEN controlEN = null;
        try
        {
                SessionInitializeTransaction ();
                controlEN = (ControlEN)session.Load (typeof(ControlEN), p_control);
                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controles_alumnoENAux = null;
                if (controlEN.Controles_alumno == null) {
                        controlEN.Controles_alumno = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
                }

                foreach (int item in p_controlalumno) {
                        controles_alumnoENAux = new DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ();
                        controles_alumnoENAux = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), item);
                        controles_alumnoENAux.Control = controlEN;

                        controlEN.Controles_alumno.Add (controles_alumnoENAux);
                }


                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_sistema_evaluacion (int p_control, int p_sistemaevaluacion)
{
        DSSGenNHibernate.EN.Moodle.ControlEN controlEN = null;
        try
        {
                SessionInitializeTransaction ();
                controlEN = (ControlEN)session.Load (typeof(ControlEN), p_control);
                controlEN.Sistema_evaluacion = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), p_sistemaevaluacion);

                controlEN.Sistema_evaluacion.Controles.Add (controlEN);



                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_bolsas_preguntas (int p_control, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ControlEN controlEN = null;
                controlEN = (ControlEN)session.Load (typeof(ControlEN), p_control);

                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsas_preguntasENAux = null;
                if (controlEN.Bolsas_preguntas != null) {
                        foreach (int item in p_bolsapreguntas) {
                                bolsas_preguntasENAux = (DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN), item);
                                if (controlEN.Bolsas_preguntas.Contains (bolsas_preguntasENAux) == true) {
                                        controlEN.Bolsas_preguntas.Remove (bolsas_preguntasENAux);
                                        bolsas_preguntasENAux.Controles.Remove (controlEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_bolsapreguntas you are trying to unrelationer, doesn't exist in ControlEN");
                        }
                }

                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_controles_alumno (int p_control, System.Collections.Generic.IList<int> p_controlalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ControlEN controlEN = null;
                controlEN = (ControlEN)session.Load (typeof(ControlEN), p_control);

                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controles_alumnoENAux = null;
                if (controlEN.Controles_alumno != null) {
                        foreach (int item in p_controlalumno) {
                                controles_alumnoENAux = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), item);
                                if (controlEN.Controles_alumno.Contains (controles_alumnoENAux) == true) {
                                        controlEN.Controles_alumno.Remove (controles_alumnoENAux);
                                        controles_alumnoENAux.Control = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_controlalumno you are trying to unrelationer, doesn't exist in ControlEN");
                        }
                }

                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_sistema_evaluacion (int p_control, int p_sistemaevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ControlEN controlEN = null;
                controlEN = (ControlEN)session.Load (typeof(ControlEN), p_control);

                if (controlEN.Sistema_evaluacion.Id == p_sistemaevaluacion) {
                        controlEN.Sistema_evaluacion = null;
                }
                else
                        throw new ModelException ("The identifier " + p_sistemaevaluacion + " in p_sistemaevaluacion you are trying to unrelationer, doesn't exist in ControlEN");

                session.Update (controlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
