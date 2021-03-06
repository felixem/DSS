
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
public partial class PreguntaCAD : BasicCAD, IPreguntaCAD
{
public PreguntaCAD() : base ()
{
}

public PreguntaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PreguntaEN ReadOIDDefault (int id)
{
        PreguntaEN preguntaEN = null;

        try
        {
                SessionInitializeTransaction ();
                preguntaEN = (PreguntaEN)session.Get (typeof(PreguntaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preguntaEN;
}


public int New_ (PreguntaEN pregunta)
{
        try
        {
                SessionInitializeTransaction ();
                if (pregunta.Bolsa != null) {
                        pregunta.Bolsa = (DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN), pregunta.Bolsa.Id);

                        pregunta.Bolsa.Preguntas.Add (pregunta);
                }

                session.Save (pregunta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pregunta.Id;
}

public void Modify (PreguntaEN pregunta)
{
        try
        {
                SessionInitializeTransaction ();
                PreguntaEN preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), pregunta.Id);

                preguntaEN.Contenido = pregunta.Contenido;


                preguntaEN.Explicacion = pregunta.Explicacion;

                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
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
                PreguntaEN preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), id);
                session.Delete (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PreguntaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PreguntaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PreguntaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PreguntaEN>();
                else
                        result = session.CreateCriteria (typeof(PreguntaEN)).List<PreguntaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public PreguntaEN ReadOID (int id)
{
        PreguntaEN preguntaEN = null;

        try
        {
                SessionInitializeTransaction ();
                preguntaEN = (PreguntaEN)session.Get (typeof(PreguntaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return preguntaEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PreguntaEN self where select count(*) FROM PreguntaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PreguntaENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_bolsa (int p_pregunta, int p_bolsapreguntas)
{
        DSSGenNHibernate.EN.Moodle.PreguntaEN preguntaEN = null;
        try
        {
                SessionInitializeTransaction ();
                preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), p_pregunta);
                preguntaEN.Bolsa = (DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN), p_bolsapreguntas);

                preguntaEN.Bolsa.Preguntas.Add (preguntaEN);



                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_respuesta_correcta (int p_pregunta, int p_respuesta)
{
        DSSGenNHibernate.EN.Moodle.PreguntaEN preguntaEN = null;
        try
        {
                SessionInitializeTransaction ();
                preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), p_pregunta);
                preguntaEN.Respuesta_correcta = (DSSGenNHibernate.EN.Moodle.RespuestaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.RespuestaEN), p_respuesta);



                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_respuestas (int p_pregunta, System.Collections.Generic.IList<int> p_respuesta)
{
        DSSGenNHibernate.EN.Moodle.PreguntaEN preguntaEN = null;
        try
        {
                SessionInitializeTransaction ();
                preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), p_pregunta);
                DSSGenNHibernate.EN.Moodle.RespuestaEN respuestasENAux = null;
                if (preguntaEN.Respuestas == null) {
                        preguntaEN.Respuestas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.RespuestaEN>();
                }

                foreach (int item in p_respuesta) {
                        respuestasENAux = new DSSGenNHibernate.EN.Moodle.RespuestaEN ();
                        respuestasENAux = (DSSGenNHibernate.EN.Moodle.RespuestaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.RespuestaEN), item);
                        respuestasENAux.Pregunta = preguntaEN;

                        preguntaEN.Respuestas.Add (respuestasENAux);
                }


                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_bolsa (int p_pregunta, int p_bolsapreguntas)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.PreguntaEN preguntaEN = null;
                preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), p_pregunta);

                if (preguntaEN.Bolsa.Id == p_bolsapreguntas) {
                        preguntaEN.Bolsa = null;
                }
                else
                        throw new ModelException ("The identifier " + p_bolsapreguntas + " in p_bolsapreguntas you are trying to unrelationer, doesn't exist in PreguntaEN");

                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_respuesta_correcta (int p_pregunta, int p_respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.PreguntaEN preguntaEN = null;
                preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), p_pregunta);

                if (preguntaEN.Respuesta_correcta.Id == p_respuesta) {
                        preguntaEN.Respuesta_correcta = null;
                }
                else
                        throw new ModelException ("The identifier " + p_respuesta + " in p_respuesta you are trying to unrelationer, doesn't exist in PreguntaEN");

                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_respuestas (int p_pregunta, System.Collections.Generic.IList<int> p_respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.PreguntaEN preguntaEN = null;
                preguntaEN = (PreguntaEN)session.Load (typeof(PreguntaEN), p_pregunta);

                DSSGenNHibernate.EN.Moodle.RespuestaEN respuestasENAux = null;
                if (preguntaEN.Respuestas != null) {
                        foreach (int item in p_respuesta) {
                                respuestasENAux = (DSSGenNHibernate.EN.Moodle.RespuestaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.RespuestaEN), item);
                                if (preguntaEN.Respuestas.Contains (respuestasENAux) == true) {
                                        preguntaEN.Respuestas.Remove (respuestasENAux);
                                        respuestasENAux.Pregunta = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_respuesta you are trying to unrelationer, doesn't exist in PreguntaEN");
                        }
                }

                session.Update (preguntaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in PreguntaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
