
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
public partial class ExpedienteAnyoCAD : BasicCAD, IExpedienteAnyoCAD
{
public ExpedienteAnyoCAD() : base ()
{
}

public ExpedienteAnyoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ExpedienteAnyoEN ReadOIDDefault (int id)
{
        ExpedienteAnyoEN expedienteAnyoEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Get (typeof(ExpedienteAnyoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteAnyoEN;
}


public int New_ (ExpedienteAnyoEN expedienteAnyo)
{
        try
        {
                SessionInitializeTransaction ();
                if (expedienteAnyo.Expediente != null) {
                        expedienteAnyo.Expediente = (DSSGenNHibernate.EN.Moodle.ExpedienteEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEN), expedienteAnyo.Expediente.Id);

                        expedienteAnyo.Expediente.Expedientes_anyo.Add (expedienteAnyo);
                }
                if (expedienteAnyo.Anyo != null) {
                        expedienteAnyo.Anyo = (DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN), expedienteAnyo.Anyo.Id);

                        expedienteAnyo.Anyo.Expedientes_anyo.Add (expedienteAnyo);
                }

                session.Save (expedienteAnyo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteAnyo.Id;
}

public void Modify (ExpedienteAnyoEN expedienteAnyo)
{
        try
        {
                SessionInitializeTransaction ();
                ExpedienteAnyoEN expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), expedienteAnyo.Id);

                expedienteAnyoEN.Nota_media = expedienteAnyo.Nota_media;


                expedienteAnyoEN.Abierto = expedienteAnyo.Abierto;

                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
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
                ExpedienteAnyoEN expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), id);
                session.Delete (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ExpedienteAnyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteAnyoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ExpedienteAnyoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ExpedienteAnyoEN>();
                else
                        result = session.CreateCriteria (typeof(ExpedienteAnyoEN)).List<ExpedienteAnyoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ExpedienteAnyoEN ReadOID (int id)
{
        ExpedienteAnyoEN expedienteAnyoEN = null;

        try
        {
                SessionInitializeTransaction ();
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Get (typeof(ExpedienteAnyoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return expedienteAnyoEN;
}

public void Relationer_anyo (int p_expedienteanyo, int p_anyoacademico)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedienteAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), p_expedienteanyo);
                expedienteAnyoEN.Anyo = (DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN), p_anyoacademico);

                expedienteAnyoEN.Anyo.Expedientes_anyo.Add (expedienteAnyoEN);



                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expediente (int p_expedienteanyo, int p_expediente)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedienteAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), p_expedienteanyo);
                expedienteAnyoEN.Expediente = (DSSGenNHibernate.EN.Moodle.ExpedienteEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEN), p_expediente);

                expedienteAnyoEN.Expediente.Expedientes_anyo.Add (expedienteAnyoEN);



                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expedientes_asignatura (int p_expedienteanyo, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedienteAnyoEN = null;
        try
        {
                SessionInitializeTransaction ();
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), p_expedienteanyo);
                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedientes_asignaturaENAux = null;
                if (expedienteAnyoEN.Expedientes_asignatura == null) {
                        expedienteAnyoEN.Expedientes_asignatura = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN>();
                }

                foreach (int item in p_expedienteasignatura) {
                        expedientes_asignaturaENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN ();
                        expedientes_asignaturaENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), item);
                        expedientes_asignaturaENAux.Expediente_anyo = expedienteAnyoEN;

                        expedienteAnyoEN.Expedientes_asignatura.Add (expedientes_asignaturaENAux);
                }


                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_anyo (int p_expedienteanyo, int p_anyoacademico)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedienteAnyoEN = null;
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), p_expedienteanyo);

                if (expedienteAnyoEN.Anyo.Id == p_anyoacademico) {
                        expedienteAnyoEN.Anyo = null;
                }
                else
                        throw new ModelException ("The identifier " + p_anyoacademico + " in p_anyoacademico you are trying to unrelationer, doesn't exist in ExpedienteAnyoEN");

                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expediente (int p_expedienteanyo, int p_expediente)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedienteAnyoEN = null;
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), p_expedienteanyo);

                if (expedienteAnyoEN.Expediente.Id == p_expediente) {
                        expedienteAnyoEN.Expediente = null;
                }
                else
                        throw new ModelException ("The identifier " + p_expediente + " in p_expediente you are trying to unrelationer, doesn't exist in ExpedienteAnyoEN");

                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expedientes_asignatura (int p_expedienteanyo, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedienteAnyoEN = null;
                expedienteAnyoEN = (ExpedienteAnyoEN)session.Load (typeof(ExpedienteAnyoEN), p_expedienteanyo);

                DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expedientes_asignaturaENAux = null;
                if (expedienteAnyoEN.Expedientes_asignatura != null) {
                        foreach (int item in p_expedienteasignatura) {
                                expedientes_asignaturaENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN), item);
                                if (expedienteAnyoEN.Expedientes_asignatura.Contains (expedientes_asignaturaENAux) == true) {
                                        expedienteAnyoEN.Expedientes_asignatura.Remove (expedientes_asignaturaENAux);
                                        expedientes_asignaturaENAux.Expediente_anyo = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteasignatura you are trying to unrelationer, doesn't exist in ExpedienteAnyoEN");
                        }
                }

                session.Update (expedienteAnyoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ExpedienteAnyoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
