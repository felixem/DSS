
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
public partial class RespuestaCAD : BasicCAD, IRespuestaCAD
{
public RespuestaCAD() : base ()
{
}

public RespuestaCAD(ISession sessionAux) : base (sessionAux)
{
}



public RespuestaEN ReadOIDDefault (int id)
{
        RespuestaEN respuestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Get (typeof(RespuestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuestaEN;
}


public int New_ (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                if (respuesta.Pregunta != null) {
                        respuesta.Pregunta = (DSSGenNHibernate.EN.Moodle.PreguntaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaEN), respuesta.Pregunta.Id);

                        respuesta.Pregunta.Respuestas.Add (respuesta);
                }

                session.Save (respuesta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuesta.Id;
}

public void Modify (RespuestaEN respuesta)
{
        try
        {
                SessionInitializeTransaction ();
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), respuesta.Id);

                respuestaEN.Contenido = respuesta.Contenido;

                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
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
                RespuestaEN respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), id);
                session.Delete (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<RespuestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RespuestaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RespuestaEN>();
                else
                        result = session.CreateCriteria (typeof(RespuestaEN)).List<RespuestaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public RespuestaEN ReadOID (int id)
{
        RespuestaEN respuestaEN = null;

        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Get (typeof(RespuestaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return respuestaEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RespuestaEN self where select count(*) FROM RespuestaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RespuestaENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_pregunta (int p_respuesta, int p_pregunta)
{
        DSSGenNHibernate.EN.Moodle.RespuestaEN respuestaEN = null;
        try
        {
                SessionInitializeTransaction ();
                respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), p_respuesta);
                respuestaEN.Pregunta = (DSSGenNHibernate.EN.Moodle.PreguntaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaEN), p_pregunta);

                respuestaEN.Pregunta.Respuestas.Add (respuestaEN);



                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_pregunta (int p_respuesta, int p_pregunta)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.RespuestaEN respuestaEN = null;
                respuestaEN = (RespuestaEN)session.Load (typeof(RespuestaEN), p_respuesta);

                if (respuestaEN.Pregunta.Id == p_pregunta) {
                        respuestaEN.Pregunta = null;
                }
                else
                        throw new ModelException ("The identifier " + p_pregunta + " in p_pregunta you are trying to unrelationer, doesn't exist in RespuestaEN");

                session.Update (respuestaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in RespuestaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
