
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
public partial class UsuarioComunCAD : BasicCAD, IUsuarioComunCAD
{
public UsuarioComunCAD() : base ()
{
}

public UsuarioComunCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioComunEN ReadOIDDefault (string email)
{
        UsuarioComunEN usuarioComunEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioComunEN = (UsuarioComunEN)session.Get (typeof(UsuarioComunEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioComunEN;
}


public string New_ (UsuarioComunEN usuarioComun)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioComun);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioComun.Email;
}

public void Modify (UsuarioComunEN usuarioComun)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioComunEN usuarioComunEN = (UsuarioComunEN)session.Load (typeof(UsuarioComunEN), usuarioComun.Email);

                usuarioComunEN.Dni = usuarioComun.Dni;


                usuarioComunEN.Password = usuarioComun.Password;


                usuarioComunEN.Nombre = usuarioComun.Nombre;


                usuarioComunEN.Apellidos = usuarioComun.Apellidos;


                usuarioComunEN.Fecha_nacimiento = usuarioComun.Fecha_nacimiento;

                session.Update (usuarioComunEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<UsuarioComunEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioComunEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioComunEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioComunEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioComunEN)).List<UsuarioComunEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public UsuarioComunEN ReadOID (string email)
{
        UsuarioComunEN usuarioComunEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioComunEN = (UsuarioComunEN)session.Get (typeof(UsuarioComunEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioComunEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioComunEN self where select count(*) FROM UsuarioComunEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioComunENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_mensajes (string p_usuariocomun, System.Collections.Generic.IList<int> p_mensaje)
{
        DSSGenNHibernate.EN.Moodle.UsuarioComunEN usuarioComunEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioComunEN = (UsuarioComunEN)session.Load (typeof(UsuarioComunEN), p_usuariocomun);
                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (usuarioComunEN.Mensajes == null) {
                        usuarioComunEN.Mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
                }

                foreach (int item in p_mensaje) {
                        mensajesENAux = new DSSGenNHibernate.EN.Moodle.MensajeEN ();
                        mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                        mensajesENAux.Usuario = usuarioComunEN;

                        usuarioComunEN.Mensajes.Add (mensajesENAux);
                }


                session.Update (usuarioComunEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_mensajes (string p_usuariocomun, System.Collections.Generic.IList<int> p_mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.UsuarioComunEN usuarioComunEN = null;
                usuarioComunEN = (UsuarioComunEN)session.Load (typeof(UsuarioComunEN), p_usuariocomun);

                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (usuarioComunEN.Mensajes != null) {
                        foreach (int item in p_mensaje) {
                                mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                                if (usuarioComunEN.Mensajes.Contains (mensajesENAux) == true) {
                                        usuarioComunEN.Mensajes.Remove (mensajesENAux);
                                        mensajesENAux.Usuario = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_mensaje you are trying to unrelationer, doesn't exist in UsuarioComunEN");
                        }
                }

                session.Update (usuarioComunEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioComunCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
