
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
public partial class PreguntaControlCAD : BasicCAD, IPreguntaControlCAD
{
public PreguntaControlCAD() : base ()
{
}

public PreguntaControlCAD(ISession sessionAux) : base (sessionAux)
{
}



public PreguntaControlEN ReadOIDDefault (int id)
{
        PreguntaControlEN preguntaControlEN = null;

        try
        {
                SessionInitializeTransaction ();
                preguntaControlEN = (PreguntaControlEN)session.Get (typeof(PreguntaControlEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preguntaControlEN;
}


public int New_ (PreguntaControlEN preguntaControl)
{
        try
        {
                SessionInitializeTransaction ();
                if (preguntaControl.Control != null) {
                        preguntaControl.Control = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), preguntaControl.Control.Id);

                        preguntaControl.Control.Preguntas.Add (preguntaControl);
                }
                if (preguntaControl.Pregunta != null) {
                        preguntaControl.Pregunta = (DSSGenNHibernate.EN.Moodle.PreguntaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaEN), preguntaControl.Pregunta.Id);
                }

                session.Save (preguntaControl);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preguntaControl.Id;
}

public void Modify (PreguntaControlEN preguntaControl)
{
        try
        {
                SessionInitializeTransaction ();
                PreguntaControlEN preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), preguntaControl.Id);
                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
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
                PreguntaControlEN preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), id);
                session.Delete (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PreguntaControlEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PreguntaControlEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PreguntaControlEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PreguntaControlEN>();
                else
                        result = session.CreateCriteria (typeof(PreguntaControlEN)).List<PreguntaControlEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public PreguntaControlEN ReadOID (int id)
{
        PreguntaControlEN preguntaControlEN = null;

        try
        {
                SessionInitializeTransaction ();
                preguntaControlEN = (PreguntaControlEN)session.Get (typeof(PreguntaControlEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preguntaControlEN;
}

public void Relationer_control (int p_preguntacontrol, int p_controlalumno)
{
        DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntaControlEN = null;
        try
        {
                SessionInitializeTransaction ();
                preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), p_preguntacontrol);
                preguntaControlEN.Control = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), p_controlalumno);

                preguntaControlEN.Control.Preguntas.Add (preguntaControlEN);



                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_pregunta (int p_preguntacontrol, int p_pregunta)
{
        DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntaControlEN = null;
        try
        {
                SessionInitializeTransaction ();
                preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), p_preguntacontrol);
                preguntaControlEN.Pregunta = (DSSGenNHibernate.EN.Moodle.PreguntaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaEN), p_pregunta);



                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_respuesta_elegida (int p_preguntacontrol, int p_respuesta)
{
        DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntaControlEN = null;
        try
        {
                SessionInitializeTransaction ();
                preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), p_preguntacontrol);
                preguntaControlEN.Respuesta_elegida = (DSSGenNHibernate.EN.Moodle.RespuestaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.RespuestaEN), p_respuesta);



                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_control (int p_preguntacontrol, int p_controlalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntaControlEN = null;
                preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), p_preguntacontrol);

                if (preguntaControlEN.Control.Id == p_controlalumno) {
                        preguntaControlEN.Control = null;
                }
                else
                        throw new ModelException ("The identifier " + p_controlalumno + " in p_controlalumno you are trying to unrelationer, doesn't exist in PreguntaControlEN");

                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_pregunta (int p_preguntacontrol, int p_pregunta)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntaControlEN = null;
                preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), p_preguntacontrol);

                if (preguntaControlEN.Pregunta.Id == p_pregunta) {
                        preguntaControlEN.Pregunta = null;
                }
                else
                        throw new ModelException ("The identifier " + p_pregunta + " in p_pregunta you are trying to unrelationer, doesn't exist in PreguntaControlEN");

                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_respuesta_elegida (int p_preguntacontrol, int p_respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntaControlEN = null;
                preguntaControlEN = (PreguntaControlEN)session.Load (typeof(PreguntaControlEN), p_preguntacontrol);

                if (preguntaControlEN.Respuesta_elegida.Id == p_respuesta) {
                        preguntaControlEN.Respuesta_elegida = null;
                }
                else
                        throw new ModelException ("The identifier " + p_respuesta + " in p_respuesta you are trying to unrelationer, doesn't exist in PreguntaControlEN");

                session.Update (preguntaControlEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaControlCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
