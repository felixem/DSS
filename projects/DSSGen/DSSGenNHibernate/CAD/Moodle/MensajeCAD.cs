
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
public partial class MensajeCAD : BasicCAD, IMensajeCAD
{
public MensajeCAD() : base ()
{
}

public MensajeCAD(ISession sessionAux) : base (sessionAux)
{
}



public MensajeEN ReadOIDDefault (int id)
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}


public int New_ (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                if (mensaje.Tutoria != null) {
                        mensaje.Tutoria = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), mensaje.Tutoria.Id);

                        mensaje.Tutoria.Mensajes.Add (mensaje);
                }
                if (mensaje.Usuario != null) {
                        mensaje.Usuario = (DSSGenNHibernate.EN.Moodle.UsuarioComunEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.UsuarioComunEN), mensaje.Usuario.Email);

                        mensaje.Usuario.Mensajes.Add (mensaje);
                }

                session.Save (mensaje);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensaje.Id;
}

public void Modify (MensajeEN mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), mensaje.Id);

                mensajeEN.Contenido = mensaje.Contenido;


                mensajeEN.Fecha = mensaje.Fecha;


                mensajeEN.Respondido = mensaje.Respondido;

                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
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
                MensajeEN mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), id);
                session.Delete (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MensajeEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MensajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MensajeEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MensajeEN>();
                else
                        result = session.CreateCriteria (typeof(MensajeEN)).List<MensajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public MensajeEN ReadOID (int id)
{
        MensajeEN mensajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Get (typeof(MensajeEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return mensajeEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MensajeEN self where select count(*) FROM MensajeEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MensajeENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_tutoria (int p_mensaje, int p_tutoria)
{
        DSSGenNHibernate.EN.Moodle.MensajeEN mensajeEN = null;
        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), p_mensaje);
                mensajeEN.Tutoria = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), p_tutoria);

                mensajeEN.Tutoria.Mensajes.Add (mensajeEN);



                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_usuario (int p_mensaje, string p_usuariocomun)
{
        DSSGenNHibernate.EN.Moodle.MensajeEN mensajeEN = null;
        try
        {
                SessionInitializeTransaction ();
                mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), p_mensaje);
                mensajeEN.Usuario = (DSSGenNHibernate.EN.Moodle.UsuarioComunEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.UsuarioComunEN), p_usuariocomun);

                mensajeEN.Usuario.Mensajes.Add (mensajeEN);



                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_tutoria (int p_mensaje, int p_tutoria)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.MensajeEN mensajeEN = null;
                mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), p_mensaje);

                if (mensajeEN.Tutoria.Id == p_tutoria) {
                        mensajeEN.Tutoria = null;
                }
                else
                        throw new ModelException ("The identifier " + p_tutoria + " in p_tutoria you are trying to unrelationer, doesn't exist in MensajeEN");

                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_usuario (int p_mensaje, string p_usuariocomun)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.MensajeEN mensajeEN = null;
                mensajeEN = (MensajeEN)session.Load (typeof(MensajeEN), p_mensaje);

                if (mensajeEN.Usuario.Email == p_usuariocomun) {
                        mensajeEN.Usuario = null;
                }
                else
                        throw new ModelException ("The identifier " + p_usuariocomun + " in p_usuariocomun you are trying to unrelationer, doesn't exist in MensajeEN");

                session.Update (mensajeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MensajeCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
