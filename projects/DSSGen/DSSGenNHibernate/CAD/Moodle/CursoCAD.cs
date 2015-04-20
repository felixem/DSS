
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
public partial class CursoCAD : BasicCAD, ICursoCAD
{
public CursoCAD() : base ()
{
}

public CursoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CursoEN ReadOIDDefault (int id)
{
        CursoEN cursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                cursoEN = (CursoEN)session.Get (typeof(CursoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cursoEN;
}


public int New_ (CursoEN curso)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (curso);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return curso.Id;
}

public void Modify (CursoEN curso)
{
        try
        {
                SessionInitializeTransaction ();
                CursoEN cursoEN = (CursoEN)session.Load (typeof(CursoEN), curso.Id);

                cursoEN.Cod_curso = curso.Cod_curso;


                cursoEN.Nombre = curso.Nombre;

                session.Update (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
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
                CursoEN cursoEN = (CursoEN)session.Load (typeof(CursoEN), id);
                session.Delete (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<CursoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CursoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CursoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CursoEN>();
                else
                        result = session.CreateCriteria (typeof(CursoEN)).List<CursoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public CursoEN ReadOID (int id)
{
        CursoEN cursoEN = null;

        try
        {
                SessionInitializeTransaction ();
                cursoEN = (CursoEN)session.Get (typeof(CursoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cursoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM CursoEN self where select count(*) FROM CursoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("CursoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_asignaturas (int p_curso, System.Collections.Generic.IList<int> p_asignatura)
{
        DSSGenNHibernate.EN.Moodle.CursoEN cursoEN = null;
        try
        {
                SessionInitializeTransaction ();
                cursoEN = (CursoEN)session.Load (typeof(CursoEN), p_curso);
                DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturasENAux = null;
                if (cursoEN.Asignaturas == null) {
                        cursoEN.Asignaturas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaEN>();
                }

                foreach (int item in p_asignatura) {
                        asignaturasENAux = new DSSGenNHibernate.EN.Moodle.AsignaturaEN ();
                        asignaturasENAux = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), item);
                        asignaturasENAux.Curso = cursoEN;

                        cursoEN.Asignaturas.Add (asignaturasENAux);
                }


                session.Update (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignaturas (int p_curso, System.Collections.Generic.IList<int> p_asignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.CursoEN cursoEN = null;
                cursoEN = (CursoEN)session.Load (typeof(CursoEN), p_curso);

                DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturasENAux = null;
                if (cursoEN.Asignaturas != null) {
                        foreach (int item in p_asignatura) {
                                asignaturasENAux = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), item);
                                if (cursoEN.Asignaturas.Contains (asignaturasENAux) == true) {
                                        cursoEN.Asignaturas.Remove (asignaturasENAux);
                                        asignaturasENAux.Curso = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_asignatura you are trying to unrelationer, doesn't exist in CursoEN");
                        }
                }

                session.Update (cursoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in CursoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
