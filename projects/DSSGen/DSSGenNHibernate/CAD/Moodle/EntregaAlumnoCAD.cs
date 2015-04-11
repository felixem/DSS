
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
public partial class EntregaAlumnoCAD : BasicCAD, IEntregaAlumnoCAD
{
public EntregaAlumnoCAD() : base ()
{
}

public EntregaAlumnoCAD(ISession sessionAux) : base (sessionAux)
{
}



public EntregaAlumnoEN ReadOIDDefault (int id)
{
        EntregaAlumnoEN entregaAlumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                entregaAlumnoEN = (EntregaAlumnoEN)session.Get (typeof(EntregaAlumnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entregaAlumnoEN;
}


public int New_ (EntregaAlumnoEN entregaAlumno)
{
        try
        {
                SessionInitializeTransaction ();
                if (entregaAlumno.Entrega != null) {
                        entregaAlumno.Entrega = (DSSGenNHibernate.EN.Moodle.EntregaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaEN), entregaAlumno.Entrega.Id);

                        entregaAlumno.Entrega.Entregas_alumno.Add (entregaAlumno);
                }
                if (entregaAlumno.Alumno != null) {
                        entregaAlumno.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), entregaAlumno.Alumno.Email);

                        entregaAlumno.Alumno.Entregas.Add (entregaAlumno);
                }

                session.Save (entregaAlumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entregaAlumno.Id;
}

public void Modify (EntregaAlumnoEN entregaAlumno)
{
        try
        {
                SessionInitializeTransaction ();
                EntregaAlumnoEN entregaAlumnoEN = (EntregaAlumnoEN)session.Load (typeof(EntregaAlumnoEN), entregaAlumno.Id);

                entregaAlumnoEN.Nombre_fichero = entregaAlumno.Nombre_fichero;


                entregaAlumnoEN.Extension = entregaAlumno.Extension;


                entregaAlumnoEN.Ruta = entregaAlumno.Ruta;


                entregaAlumnoEN.Tam = entregaAlumno.Tam;


                entregaAlumnoEN.Fecha_entrega = entregaAlumno.Fecha_entrega;


                entregaAlumnoEN.Nota = entregaAlumno.Nota;


                entregaAlumnoEN.Corregido = entregaAlumno.Corregido;


                entregaAlumnoEN.Comentario_alumno = entregaAlumno.Comentario_alumno;


                entregaAlumnoEN.Comentario_profesor = entregaAlumno.Comentario_profesor;

                session.Update (entregaAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
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
                EntregaAlumnoEN entregaAlumnoEN = (EntregaAlumnoEN)session.Load (typeof(EntregaAlumnoEN), id);
                session.Delete (entregaAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EntregaAlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntregaAlumnoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EntregaAlumnoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EntregaAlumnoEN>();
                else
                        result = session.CreateCriteria (typeof(EntregaAlumnoEN)).List<EntregaAlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public EntregaAlumnoEN ReadOID (int id)
{
        EntregaAlumnoEN entregaAlumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                entregaAlumnoEN = (EntregaAlumnoEN)session.Get (typeof(EntregaAlumnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entregaAlumnoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntregaAlumnoEN self where select count(*) FROM EntregaAlumnoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntregaAlumnoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_alumno (int p_entregaalumno, string p_alumno)
{
        DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregaAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                entregaAlumnoEN = (EntregaAlumnoEN)session.Load (typeof(EntregaAlumnoEN), p_entregaalumno);
                entregaAlumnoEN.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), p_alumno);

                entregaAlumnoEN.Alumno.Entregas.Add (entregaAlumnoEN);



                session.Update (entregaAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_entrega (int p_entregaalumno, int p_entrega)
{
        DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregaAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                entregaAlumnoEN = (EntregaAlumnoEN)session.Load (typeof(EntregaAlumnoEN), p_entregaalumno);
                entregaAlumnoEN.Entrega = (DSSGenNHibernate.EN.Moodle.EntregaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaEN), p_entrega);

                entregaAlumnoEN.Entrega.Entregas_alumno.Add (entregaAlumnoEN);



                session.Update (entregaAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_alumno (int p_entregaalumno, string p_alumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregaAlumnoEN = null;
                entregaAlumnoEN = (EntregaAlumnoEN)session.Load (typeof(EntregaAlumnoEN), p_entregaalumno);

                if (entregaAlumnoEN.Alumno.Email == p_alumno) {
                        entregaAlumnoEN.Alumno = null;
                }
                else
                        throw new ModelException ("The identifier " + p_alumno + " in p_alumno you are trying to unrelationer, doesn't exist in EntregaAlumnoEN");

                session.Update (entregaAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_entrega (int p_entregaalumno, int p_entrega)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregaAlumnoEN = null;
                entregaAlumnoEN = (EntregaAlumnoEN)session.Load (typeof(EntregaAlumnoEN), p_entregaalumno);

                if (entregaAlumnoEN.Entrega.Id == p_entrega) {
                        entregaAlumnoEN.Entrega = null;
                }
                else
                        throw new ModelException ("The identifier " + p_entrega + " in p_entrega you are trying to unrelationer, doesn't exist in EntregaAlumnoEN");

                session.Update (entregaAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
