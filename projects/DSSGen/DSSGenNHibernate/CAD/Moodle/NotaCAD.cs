
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
public partial class NotaCAD : BasicCAD, INotaCAD
{
public NotaCAD() : base ()
{
}

public NotaCAD(ISession sessionAux) : base (sessionAux)
{
}



public NotaEN ReadOIDDefault (int id)
{
        NotaEN notaEN = null;

        try
        {
                SessionInitializeTransaction ();
                notaEN = (NotaEN)session.Get (typeof(NotaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notaEN;
}


public int New_ (NotaEN nota)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (nota);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return nota.Id;
}

public void Modify (NotaEN nota)
{
        try
        {
                SessionInitializeTransaction ();
                NotaEN notaEN = (NotaEN)session.Load (typeof(NotaEN), nota.Id);

                notaEN.Nombre = nota.Nombre;


                notaEN.Abreviatura = nota.Abreviatura;


                notaEN.Ponderacion = nota.Ponderacion;

                session.Update (notaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
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
                NotaEN notaEN = (NotaEN)session.Load (typeof(NotaEN), id);
                session.Delete (notaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<NotaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<NotaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(NotaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<NotaEN>();
                else
                        result = session.CreateCriteria (typeof(NotaEN)).List<NotaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public NotaEN ReadOID (int id)
{
        NotaEN notaEN = null;

        try
        {
                SessionInitializeTransaction ();
                notaEN = (NotaEN)session.Get (typeof(NotaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return notaEN;
}

public void Relationer_expedientes (int p_nota, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        DSSGenNHibernate.EN.Moodle.NotaEN notaEN = null;
        try
        {
                SessionInitializeTransaction ();
                notaEN = (NotaEN)session.Load (typeof(NotaEN), p_nota);
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedientesENAux = null;
                if (notaEN.Expedientes == null) {
                        notaEN.Expedientes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN>();
                }

                foreach (int item in p_expedienteasignatura) {
                        expedientesENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN ();
                        expedientesENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), item);

                        notaEN.Expedientes.Add (expedientesENAux);
                }


                session.Update (notaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_expedientes (int p_nota, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.NotaEN notaEN = null;
                notaEN = (NotaEN)session.Load (typeof(NotaEN), p_nota);

                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedientesENAux = null;
                if (notaEN.Expedientes != null) {
                        foreach (int item in p_expedienteasignatura) {
                                expedientesENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), item);
                                if (notaEN.Expedientes.Contains (expedientesENAux) == true) {
                                        notaEN.Expedientes.Remove (expedientesENAux);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteasignatura you are trying to unrelationer, doesn't exist in NotaEN");
                        }
                }

                session.Update (notaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in NotaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
