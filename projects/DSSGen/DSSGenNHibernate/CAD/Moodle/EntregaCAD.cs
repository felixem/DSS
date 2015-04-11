
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
public partial class EntregaCAD : BasicCAD, IEntregaCAD
{
public EntregaCAD() : base ()
{
}

public EntregaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EntregaEN ReadOIDDefault (int id)
{
        EntregaEN entregaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entregaEN = (EntregaEN)session.Get (typeof(EntregaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entregaEN;
}


public int New_ (EntregaEN entrega)
{
        try
        {
                SessionInitializeTransaction ();
                if (entrega.Profesor != null) {
                        entrega.Profesor = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), entrega.Profesor.Email);

                        entrega.Profesor.Entregas_propuestas.Add (entrega);
                }
                if (entrega.Evaluacion != null) {
                        entrega.Evaluacion = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), entrega.Evaluacion.Id);

                        entrega.Evaluacion.Entregas.Add (entrega);
                }

                session.Save (entrega);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entrega.Id;
}

public void Modify (EntregaEN entrega)
{
        try
        {
                SessionInitializeTransaction ();
                EntregaEN entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), entrega.Id);

                entregaEN.Nombre = entrega.Nombre;


                entregaEN.Descripcion = entrega.Descripcion;


                entregaEN.Fecha_apertura = entrega.Fecha_apertura;


                entregaEN.Fecha_cierre = entrega.Fecha_cierre;


                entregaEN.Puntuacion_maxima = entrega.Puntuacion_maxima;

                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
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
                EntregaEN entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), id);
                session.Delete (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EntregaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntregaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EntregaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EntregaEN>();
                else
                        result = session.CreateCriteria (typeof(EntregaEN)).List<EntregaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public EntregaEN ReadOID (int id)
{
        EntregaEN entregaEN = null;

        try
        {
                SessionInitializeTransaction ();
                entregaEN = (EntregaEN)session.Get (typeof(EntregaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return entregaEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EntregaEN self where select count(*) FROM EntregaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EntregaENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_entregas_alumno (int p_entrega, System.Collections.Generic.IList<int> p_entregaalumno)
{
        DSSGenNHibernate.EN.Moodle.EntregaEN entregaEN = null;
        try
        {
                SessionInitializeTransaction ();
                entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), p_entrega);
                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregas_alumnoENAux = null;
                if (entregaEN.Entregas_alumno == null) {
                        entregaEN.Entregas_alumno = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
                }

                foreach (int item in p_entregaalumno) {
                        entregas_alumnoENAux = new DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN ();
                        entregas_alumnoENAux = (DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN), item);
                        entregas_alumnoENAux.Entrega = entregaEN;

                        entregaEN.Entregas_alumno.Add (entregas_alumnoENAux);
                }


                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_evaluacion (int p_entrega, int p_sistemaevaluacion)
{
        DSSGenNHibernate.EN.Moodle.EntregaEN entregaEN = null;
        try
        {
                SessionInitializeTransaction ();
                entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), p_entrega);
                entregaEN.Evaluacion = (DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN), p_sistemaevaluacion);

                entregaEN.Evaluacion.Entregas.Add (entregaEN);



                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_profesor (int p_entrega, string p_profesor)
{
        DSSGenNHibernate.EN.Moodle.EntregaEN entregaEN = null;
        try
        {
                SessionInitializeTransaction ();
                entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), p_entrega);
                entregaEN.Profesor = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), p_profesor);

                entregaEN.Profesor.Entregas_propuestas.Add (entregaEN);



                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_entregas_alumno (int p_entrega, System.Collections.Generic.IList<int> p_entregaalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EntregaEN entregaEN = null;
                entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), p_entrega);

                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregas_alumnoENAux = null;
                if (entregaEN.Entregas_alumno != null) {
                        foreach (int item in p_entregaalumno) {
                                entregas_alumnoENAux = (DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN), item);
                                if (entregaEN.Entregas_alumno.Contains (entregas_alumnoENAux) == true) {
                                        entregaEN.Entregas_alumno.Remove (entregas_alumnoENAux);
                                        entregas_alumnoENAux.Entrega = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entregaalumno you are trying to unrelationer, doesn't exist in EntregaEN");
                        }
                }

                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_evaluacion (int p_entrega, int p_sistemaevaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EntregaEN entregaEN = null;
                entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), p_entrega);

                if (entregaEN.Evaluacion.Id == p_sistemaevaluacion) {
                        entregaEN.Evaluacion = null;
                }
                else
                        throw new ModelException ("The identifier " + p_sistemaevaluacion + " in p_sistemaevaluacion you are trying to unrelationer, doesn't exist in EntregaEN");

                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_profesor (int p_entrega, string p_profesor)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.EntregaEN entregaEN = null;
                entregaEN = (EntregaEN)session.Load (typeof(EntregaEN), p_entrega);

                if (entregaEN.Profesor.Email == p_profesor) {
                        entregaEN.Profesor = null;
                }
                else
                        throw new ModelException ("The identifier " + p_profesor + " in p_profesor you are trying to unrelationer, doesn't exist in EntregaEN");

                session.Update (entregaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in EntregaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
