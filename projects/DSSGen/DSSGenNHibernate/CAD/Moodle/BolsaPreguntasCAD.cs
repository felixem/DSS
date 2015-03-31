
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
public partial class BolsaPreguntasCAD : BasicCAD, IBolsaPreguntasCAD
{
public BolsaPreguntasCAD() : base ()
{
}

public BolsaPreguntasCAD(ISession sessionAux) : base (sessionAux)
{
}



public BolsaPreguntasEN ReadOIDDefault (int id)
{
        BolsaPreguntasEN bolsaPreguntasEN = null;

        try
        {
                SessionInitializeTransaction ();
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Get (typeof(BolsaPreguntasEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bolsaPreguntasEN;
}


public int New_ (BolsaPreguntasEN bolsaPreguntas)
{
        try
        {
                SessionInitializeTransaction ();
                if (bolsaPreguntas.Asignatura != null) {
                        bolsaPreguntas.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), bolsaPreguntas.Asignatura.Id);

                        bolsaPreguntas.Asignatura.Bolsas_preguntas.Add (bolsaPreguntas);
                }

                session.Save (bolsaPreguntas);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bolsaPreguntas.Id;
}

public void Modify (BolsaPreguntasEN bolsaPreguntas)
{
        try
        {
                SessionInitializeTransaction ();
                BolsaPreguntasEN bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), bolsaPreguntas.Id);

                bolsaPreguntasEN.Nombre = bolsaPreguntas.Nombre;


                bolsaPreguntasEN.Descripcion = bolsaPreguntas.Descripcion;


                bolsaPreguntasEN.Fecha_creacion = bolsaPreguntas.Fecha_creacion;


                bolsaPreguntasEN.Fecha_modificacion = bolsaPreguntas.Fecha_modificacion;

                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
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
                BolsaPreguntasEN bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), id);
                session.Delete (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<BolsaPreguntasEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BolsaPreguntasEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(BolsaPreguntasEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<BolsaPreguntasEN>();
                else
                        result = session.CreateCriteria (typeof(BolsaPreguntasEN)).List<BolsaPreguntasEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public BolsaPreguntasEN ReadOID (int id)
{
        BolsaPreguntasEN bolsaPreguntasEN = null;

        try
        {
                SessionInitializeTransaction ();
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Get (typeof(BolsaPreguntasEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bolsaPreguntasEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM BolsaPreguntasEN self where select count(*) FROM BolsaPreguntasEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("BolsaPreguntasENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_asignatura (int p_bolsapreguntas, int p_asignatura)
{
        DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsaPreguntasEN = null;
        try
        {
                SessionInitializeTransaction ();
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), p_bolsapreguntas);
                bolsaPreguntasEN.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaEN), p_asignatura);

                bolsaPreguntasEN.Asignatura.Bolsas_preguntas.Add (bolsaPreguntasEN);



                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_controles (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_control)
{
        DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsaPreguntasEN = null;
        try
        {
                SessionInitializeTransaction ();
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), p_bolsapreguntas);
                DSSGenNHibernate.EN.Moodle.ControlEN controlesENAux = null;
                if (bolsaPreguntasEN.Controles == null) {
                        bolsaPreguntasEN.Controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlEN>();
                }

                foreach (int item in p_control) {
                        controlesENAux = new DSSGenNHibernate.EN.Moodle.ControlEN ();
                        controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlEN), item);
                        controlesENAux.Bolsas_preguntas.Add (bolsaPreguntasEN);

                        bolsaPreguntasEN.Controles.Add (controlesENAux);
                }


                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_preguntas (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_pregunta)
{
        DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsaPreguntasEN = null;
        try
        {
                SessionInitializeTransaction ();
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), p_bolsapreguntas);
                DSSGenNHibernate.EN.Moodle.PreguntaEN preguntasENAux = null;
                if (bolsaPreguntasEN.Preguntas == null) {
                        bolsaPreguntasEN.Preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.PreguntaEN>();
                }

                foreach (int item in p_pregunta) {
                        preguntasENAux = new DSSGenNHibernate.EN.Moodle.PreguntaEN ();
                        preguntasENAux = (DSSGenNHibernate.EN.Moodle.PreguntaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaEN), item);
                        preguntasENAux.Bolsa = bolsaPreguntasEN;

                        bolsaPreguntasEN.Preguntas.Add (preguntasENAux);
                }


                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignatura (int p_bolsapreguntas, int p_asignatura)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsaPreguntasEN = null;
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), p_bolsapreguntas);

                if (bolsaPreguntasEN.Asignatura.Id == p_asignatura) {
                        bolsaPreguntasEN.Asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_asignatura + " in p_asignatura you are trying to unrelationer, doesn't exist in BolsaPreguntasEN");

                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_controles (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_control)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsaPreguntasEN = null;
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), p_bolsapreguntas);

                DSSGenNHibernate.EN.Moodle.ControlEN controlesENAux = null;
                if (bolsaPreguntasEN.Controles != null) {
                        foreach (int item in p_control) {
                                controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlEN), item);
                                if (bolsaPreguntasEN.Controles.Contains (controlesENAux) == true) {
                                        bolsaPreguntasEN.Controles.Remove (controlesENAux);
                                        controlesENAux.Bolsas_preguntas.Remove (bolsaPreguntasEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_control you are trying to unrelationer, doesn't exist in BolsaPreguntasEN");
                        }
                }

                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_preguntas (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_pregunta)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsaPreguntasEN = null;
                bolsaPreguntasEN = (BolsaPreguntasEN)session.Load (typeof(BolsaPreguntasEN), p_bolsapreguntas);

                DSSGenNHibernate.EN.Moodle.PreguntaEN preguntasENAux = null;
                if (bolsaPreguntasEN.Preguntas != null) {
                        foreach (int item in p_pregunta) {
                                preguntasENAux = (DSSGenNHibernate.EN.Moodle.PreguntaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaEN), item);
                                if (bolsaPreguntasEN.Preguntas.Contains (preguntasENAux) == true) {
                                        bolsaPreguntasEN.Preguntas.Remove (preguntasENAux);
                                        preguntasENAux.Bolsa = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_pregunta you are trying to unrelationer, doesn't exist in BolsaPreguntasEN");
                        }
                }

                session.Update (bolsaPreguntasEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in BolsaPreguntasCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
