
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
public partial class AnyoAcademicoCAD : BasicCAD, IAnyoAcademicoCAD
{
public AnyoAcademicoCAD() : base ()
{
}

public AnyoAcademicoCAD(ISession sessionAux) : base (sessionAux)
{
}



public AnyoAcademicoEN ReadOIDDefault (int id)
{
        AnyoAcademicoEN anyoAcademicoEN = null;

        try
        {
                SessionInitializeTransaction ();
                anyoAcademicoEN = (AnyoAcademicoEN)session.Get (typeof(AnyoAcademicoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anyoAcademicoEN;
}


public int New_ (AnyoAcademicoEN anyoAcademico)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (anyoAcademico);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anyoAcademico.Id;
}

public void Modify (AnyoAcademicoEN anyoAcademico)
{
        try
        {
                SessionInitializeTransaction ();
                AnyoAcademicoEN anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), anyoAcademico.Id);

                anyoAcademicoEN.Anyo = anyoAcademico.Anyo;


                anyoAcademicoEN.Fecha_inicio = anyoAcademico.Fecha_inicio;


                anyoAcademicoEN.Fecha_fin = anyoAcademico.Fecha_fin;


                anyoAcademicoEN.Finalizado = anyoAcademico.Finalizado;

                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
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
                AnyoAcademicoEN anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), id);
                session.Delete (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<AnyoAcademicoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AnyoAcademicoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AnyoAcademicoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AnyoAcademicoEN>();
                else
                        result = session.CreateCriteria (typeof(AnyoAcademicoEN)).List<AnyoAcademicoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public AnyoAcademicoEN ReadOID (int id)
{
        AnyoAcademicoEN anyoAcademicoEN = null;

        try
        {
                SessionInitializeTransaction ();
                anyoAcademicoEN = (AnyoAcademicoEN)session.Get (typeof(AnyoAcademicoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anyoAcademicoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnyoAcademicoEN self where select count(*) FROM AnyoAcademicoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnyoAcademicoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN ReadCod (int anyo)
{
        DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnyoAcademicoEN self where FROM AnyoAcademicoEN anyo where anyo.Anyo=:anyo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnyoAcademicoENreadCodHQL");
                query.SetParameter ("anyo", anyo);


                result = query.UniqueResult<DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_asignaturas (int p_anyoacademico, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyoAcademicoEN = null;
        try
        {
                SessionInitializeTransaction ();
                anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), p_anyoacademico);
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturasENAux = null;
                if (anyoAcademicoEN.Asignaturas == null) {
                        anyoAcademicoEN.Asignaturas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
                }

                foreach (int item in p_asignaturaanyo) {
                        asignaturasENAux = new DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ();
                        asignaturasENAux = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), item);
                        asignaturasENAux.Anyo = anyoAcademicoEN;

                        anyoAcademicoEN.Asignaturas.Add (asignaturasENAux);
                }


                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_evaluaciones (int p_anyoacademico, System.Collections.Generic.IList<int> p_evaluacion)
{
        DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyoAcademicoEN = null;
        try
        {
                SessionInitializeTransaction ();
                anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), p_anyoacademico);
                DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionesENAux = null;
                if (anyoAcademicoEN.Evaluaciones == null) {
                        anyoAcademicoEN.Evaluaciones = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EvaluacionEN>();
                }

                foreach (int item in p_evaluacion) {
                        evaluacionesENAux = new DSSGenNHibernate.EN.Moodle.EvaluacionEN ();
                        evaluacionesENAux = (DSSGenNHibernate.EN.Moodle.EvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionEN), item);
                        evaluacionesENAux.Anyo_academico = anyoAcademicoEN;

                        anyoAcademicoEN.Evaluaciones.Add (evaluacionesENAux);
                }


                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expedientes_anyo (int p_anyoacademico, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyoAcademicoEN = null;
        try
        {
                SessionInitializeTransaction ();
                anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), p_anyoacademico);
                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedientes_anyoENAux = null;
                if (anyoAcademicoEN.Expedientes_anyo == null) {
                        anyoAcademicoEN.Expedientes_anyo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN>();
                }

                foreach (int item in p_expedienteanyo) {
                        expedientes_anyoENAux = new DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN ();
                        expedientes_anyoENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN), item);
                        expedientes_anyoENAux.Anyo = anyoAcademicoEN;

                        anyoAcademicoEN.Expedientes_anyo.Add (expedientes_anyoENAux);
                }


                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignaturas (int p_anyoacademico, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyoAcademicoEN = null;
                anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), p_anyoacademico);

                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturasENAux = null;
                if (anyoAcademicoEN.Asignaturas != null) {
                        foreach (int item in p_asignaturaanyo) {
                                asignaturasENAux = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), item);
                                if (anyoAcademicoEN.Asignaturas.Contains (asignaturasENAux) == true) {
                                        anyoAcademicoEN.Asignaturas.Remove (asignaturasENAux);
                                        asignaturasENAux.Anyo = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_asignaturaanyo you are trying to unrelationer, doesn't exist in AnyoAcademicoEN");
                        }
                }

                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_evaluaciones (int p_anyoacademico, System.Collections.Generic.IList<int> p_evaluacion)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyoAcademicoEN = null;
                anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), p_anyoacademico);

                DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacionesENAux = null;
                if (anyoAcademicoEN.Evaluaciones != null) {
                        foreach (int item in p_evaluacion) {
                                evaluacionesENAux = (DSSGenNHibernate.EN.Moodle.EvaluacionEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionEN), item);
                                if (anyoAcademicoEN.Evaluaciones.Contains (evaluacionesENAux) == true) {
                                        anyoAcademicoEN.Evaluaciones.Remove (evaluacionesENAux);
                                        evaluacionesENAux.Anyo_academico = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_evaluacion you are trying to unrelationer, doesn't exist in AnyoAcademicoEN");
                        }
                }

                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expedientes_anyo (int p_anyoacademico, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyoAcademicoEN = null;
                anyoAcademicoEN = (AnyoAcademicoEN)session.Load (typeof(AnyoAcademicoEN), p_anyoacademico);

                DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expedientes_anyoENAux = null;
                if (anyoAcademicoEN.Expedientes_anyo != null) {
                        foreach (int item in p_expedienteanyo) {
                                expedientes_anyoENAux = (DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN), item);
                                if (anyoAcademicoEN.Expedientes_anyo.Contains (expedientes_anyoENAux) == true) {
                                        anyoAcademicoEN.Expedientes_anyo.Remove (expedientes_anyoENAux);
                                        expedientes_anyoENAux.Anyo = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_expedienteanyo you are trying to unrelationer, doesn't exist in AnyoAcademicoEN");
                        }
                }

                session.Update (anyoAcademicoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AnyoAcademicoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
