
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
public partial class ExpedienteCAD : BasicCAD, IExpedienteCAD
{
public ExpedienteCAD() : base ()
{
}

public ExpedienteCAD(ISession sessionAux) : base (sessionAux)
{
}



public ExpedienteEN ReadOIDDefault (int id)
{
        ExpedienteEN expedienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteEN = (ExpedienteEN)session.Get (typeof(ExpedienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteEN;
}


public int New_ (ExpedienteEN expediente)
{
        try
        {
                SessionInitializeTransaction ();
                if (expediente.Alumno != null) {
                        expediente.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), expediente.Alumno.Email);

                        expediente.Alumno.Expediente = expediente;
                }

                session.Save (expediente);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expediente.Id;
}

public void Modify (ExpedienteEN expediente)
{
        try
        {
                SessionInitializeTransaction ();
                ExpedienteEN expedienteEN = (ExpedienteEN)session.Load (typeof(ExpedienteEN), expediente.Id);

                expedienteEN.Cod_expediente = expediente.Cod_expediente;


                expedienteEN.Nota_media = expediente.Nota_media;


                expedienteEN.Abierto = expediente.Abierto;

                session.Update (expedienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
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
                ExpedienteEN expedienteEN = (ExpedienteEN)session.Load (typeof(ExpedienteEN), id);
                session.Delete (expedienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ExpedienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ExpedienteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ExpedienteEN>();
                else
                        result = session.CreateCriteria (typeof(ExpedienteEN)).List<ExpedienteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ExpedienteEN ReadOID (int id)
{
        ExpedienteEN expedienteEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteEN = (ExpedienteEN)session.Get (typeof(ExpedienteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ExpedienteEN self where select count(*) FROM ExpedienteEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ExpedienteENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_alumno (int p_expediente, string p_alumno)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteEN expedienteEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteEN = (ExpedienteEN)session.Load (typeof(ExpedienteEN), p_expediente);
                expedienteEN.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), p_alumno);

                expedienteEN.Alumno.Expediente = expedienteEN;




                session.Update (expedienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expedientes_anyo (int p_expediente, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteEN expedienteEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteEN = (ExpedienteEN)session.Load (typeof(ExpedienteEN), p_expediente);
                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedientes_anyoENAux = null;
                if (expedienteEN.Expedientes_anyo == null) {
                        expedienteEN.Expedientes_anyo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN>();
                }

                foreach (int item in p_expedienteanyo) {
                        expedientes_anyoENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN ();
                        expedientes_anyoENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN), item);
                        expedientes_anyoENAux.Expediente = expedienteEN;

                        expedienteEN.Expedientes_anyo.Add (expedientes_anyoENAux);
                }


                session.Update (expedienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_alumno (int p_expediente, string p_alumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteEN expedienteEN = null;
                expedienteEN = (ExpedienteEN)session.Load (typeof(ExpedienteEN), p_expediente);

                if (expedienteEN.Alumno.Email == p_alumno) {
                        expedienteEN.Alumno = null;
                        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), p_alumno);
                        alumnoEN.Expediente = null;
                }
                else
                        throw new ModelException ("The identifier " + p_alumno + " in p_alumno you are trying to unrelationer, doesn't exist in ExpedienteEN");

                session.Update (expedienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expedientes_anyo (int p_expediente, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteEN expedienteEN = null;
                expedienteEN = (ExpedienteEN)session.Load (typeof(ExpedienteEN), p_expediente);

                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedientes_anyoENAux = null;
                if (expedienteEN.Expedientes_anyo != null) {
                        foreach (int item in p_expedienteanyo) {
                                expedientes_anyoENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN), item);
                                if (expedienteEN.Expedientes_anyo.Contains (expedientes_anyoENAux) == true) {
                                        expedienteEN.Expedientes_anyo.Remove (expedientes_anyoENAux);
                                        expedientes_anyoENAux.Expediente = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteanyo you are trying to unrelationer, doesn't exist in ExpedienteEN");
                        }
                }

                session.Update (expedienteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
