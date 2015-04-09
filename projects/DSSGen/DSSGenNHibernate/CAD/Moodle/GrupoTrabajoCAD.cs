
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
public partial class GrupoTrabajoCAD : BasicCAD, IGrupoTrabajoCAD
{
public GrupoTrabajoCAD() : base ()
{
}

public GrupoTrabajoCAD(ISession sessionAux) : base (sessionAux)
{
}



public GrupoTrabajoEN ReadOIDDefault (int id)
{
        GrupoTrabajoEN grupoTrabajoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoTrabajoEN = (GrupoTrabajoEN)session.Get (typeof(GrupoTrabajoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoTrabajoEN;
}


public int New_ (GrupoTrabajoEN grupoTrabajo)
{
        try
        {
                SessionInitializeTransaction ();
                if (grupoTrabajo.Asignatura != null) {
                        grupoTrabajo.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), grupoTrabajo.Asignatura.Id);

                        grupoTrabajo.Asignatura.Grupos_trabajo.Add (grupoTrabajo);
                }

                session.Save (grupoTrabajo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoTrabajo.Id;
}

public void Modify (GrupoTrabajoEN grupoTrabajo)
{
        try
        {
                SessionInitializeTransaction ();
                GrupoTrabajoEN grupoTrabajoEN = (GrupoTrabajoEN)session.Load (typeof(GrupoTrabajoEN), grupoTrabajo.Id);

                grupoTrabajoEN.Cod_grupo = grupoTrabajo.Cod_grupo;


                grupoTrabajoEN.Nombre = grupoTrabajo.Nombre;


                grupoTrabajoEN.Descripcion = grupoTrabajo.Descripcion;


                grupoTrabajoEN.Password = grupoTrabajo.Password;


                grupoTrabajoEN.Capacidad = grupoTrabajo.Capacidad;

                session.Update (grupoTrabajoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
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
                GrupoTrabajoEN grupoTrabajoEN = (GrupoTrabajoEN)session.Load (typeof(GrupoTrabajoEN), id);
                session.Delete (grupoTrabajoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<GrupoTrabajoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoTrabajoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GrupoTrabajoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GrupoTrabajoEN>();
                else
                        result = session.CreateCriteria (typeof(GrupoTrabajoEN)).List<GrupoTrabajoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public GrupoTrabajoEN ReadOID (int id)
{
        GrupoTrabajoEN grupoTrabajoEN = null;

        try
        {
                SessionInitializeTransaction ();
                grupoTrabajoEN = (GrupoTrabajoEN)session.Get (typeof(GrupoTrabajoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return grupoTrabajoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoTrabajoEN self where select count(*) FROM GrupoTrabajoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoTrabajoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public DSSGenNHibernate.EN.Moodle.AsignaturaEN ReadCod (string cod)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GrupoTrabajoEN self where FROM GrupoTrabajoEN grupo where grupo.Cod_grupo=:cod";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GrupoTrabajoENreadCodHQL");
                query.SetParameter ("cod", cod);


                result = query.UniqueResult<DSSGenNHibernate.EN.Moodle.AsignaturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_alumnos (int p_grupotrabajo, System.Collections.Generic.IList<string> p_alumno)
{
        DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupoTrabajoEN = null;
        try
        {
                SessionInitializeTransaction ();
                grupoTrabajoEN = (GrupoTrabajoEN)session.Load (typeof(GrupoTrabajoEN), p_grupotrabajo);
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnosENAux = null;
                if (grupoTrabajoEN.Alumnos == null) {
                        grupoTrabajoEN.Alumnos = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AlumnoEN>();
                }

                foreach (string item in p_alumno) {
                        alumnosENAux = new DSSGenNHibernate.EN.Moodle.AlumnoEN ();
                        alumnosENAux = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), item);
                        alumnosENAux.Grupos_trabajo.Add (grupoTrabajoEN);

                        grupoTrabajoEN.Alumnos.Add (alumnosENAux);
                }


                session.Update (grupoTrabajoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_asignatura (int p_grupotrabajo, int p_asignaturaanyo)
{
        DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupoTrabajoEN = null;
        try
        {
                SessionInitializeTransaction ();
                grupoTrabajoEN = (GrupoTrabajoEN)session.Load (typeof(GrupoTrabajoEN), p_grupotrabajo);
                grupoTrabajoEN.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), p_asignaturaanyo);

                grupoTrabajoEN.Asignatura.Grupos_trabajo.Add (grupoTrabajoEN);



                session.Update (grupoTrabajoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_alumnos (int p_grupotrabajo, System.Collections.Generic.IList<string> p_alumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupoTrabajoEN = null;
                grupoTrabajoEN = (GrupoTrabajoEN)session.Load (typeof(GrupoTrabajoEN), p_grupotrabajo);

                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnosENAux = null;
                if (grupoTrabajoEN.Alumnos != null) {
                        foreach (string item in p_alumno) {
                                alumnosENAux = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), item);
                                if (grupoTrabajoEN.Alumnos.Contains (alumnosENAux) == true) {
                                        grupoTrabajoEN.Alumnos.Remove (alumnosENAux);
                                        alumnosENAux.Grupos_trabajo.Remove (grupoTrabajoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_alumno you are trying to unrelationer, doesn't exist in GrupoTrabajoEN");
                        }
                }

                session.Update (grupoTrabajoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_asignatura (int p_grupotrabajo, int p_asignaturaanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupoTrabajoEN = null;
                grupoTrabajoEN = (GrupoTrabajoEN)session.Load (typeof(GrupoTrabajoEN), p_grupotrabajo);

                if (grupoTrabajoEN.Asignatura.Id == p_asignaturaanyo) {
                        grupoTrabajoEN.Asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_asignaturaanyo + " in p_asignaturaanyo you are trying to unrelationer, doesn't exist in GrupoTrabajoEN");

                session.Update (grupoTrabajoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in GrupoTrabajoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
