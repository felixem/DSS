
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
public partial class ControlAlumnoCAD : BasicCAD, IControlAlumnoCAD
{
public ControlAlumnoCAD() : base ()
{
}

public ControlAlumnoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ControlAlumnoEN ReadOIDDefault (int id)
{
        ControlAlumnoEN controlAlumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                controlAlumnoEN = (ControlAlumnoEN)session.Get (typeof(ControlAlumnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return controlAlumnoEN;
}


public int New_ (ControlAlumnoEN controlAlumno)
{
        try
        {
                SessionInitializeTransaction ();
                if (controlAlumno.Alumno != null) {
                        controlAlumno.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), controlAlumno.Alumno.Email);

                        controlAlumno.Alumno.Controles.Add (controlAlumno);
                }
                if (controlAlumno.Control != null) {
                        controlAlumno.Control = (DSSGenNHibernate.EN.Moodle.ControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlEN), controlAlumno.Control.Id);

                        controlAlumno.Control.Controles_alumno.Add (controlAlumno);
                }

                session.Save (controlAlumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return controlAlumno.Id;
}

public void Modify (ControlAlumnoEN controlAlumno)
{
        try
        {
                SessionInitializeTransaction ();
                ControlAlumnoEN controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), controlAlumno.Id);

                controlAlumnoEN.Nota = controlAlumno.Nota;


                controlAlumnoEN.Terminado = controlAlumno.Terminado;


                controlAlumnoEN.Corregido = controlAlumno.Corregido;

                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
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
                ControlAlumnoEN controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), id);
                session.Delete (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ControlAlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ControlAlumnoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ControlAlumnoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ControlAlumnoEN>();
                else
                        result = session.CreateCriteria (typeof(ControlAlumnoEN)).List<ControlAlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ControlAlumnoEN ReadOID (int id)
{
        ControlAlumnoEN controlAlumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                controlAlumnoEN = (ControlAlumnoEN)session.Get (typeof(ControlAlumnoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return controlAlumnoEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ControlAlumnoEN self where select count(*) FROM ControlAlumnoEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ControlAlumnoENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ReadRelation (string p_alumno, int p_control)
{
        DSSGenNHibernate.EN.Moodle.ControlAlumnoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ControlAlumnoEN self where FROM ControlAlumnoEN cont_alu where cont_alu.Alumno.Email=:p_alumno AND cont_alu.Control.Id=:p_control";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ControlAlumnoENreadRelationHQL");
                query.SetParameter ("p_alumno", p_alumno);
                query.SetParameter ("p_control", p_control);


                result = query.UniqueResult<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_alumno (int p_controlalumno, string p_alumno)
{
        DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), p_controlalumno);
                controlAlumnoEN.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), p_alumno);

                controlAlumnoEN.Alumno.Controles.Add (controlAlumnoEN);



                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_control (int p_controlalumno, int p_control)
{
        DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), p_controlalumno);
                controlAlumnoEN.Control = (DSSGenNHibernate.EN.Moodle.ControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlEN), p_control);

                controlAlumnoEN.Control.Controles_alumno.Add (controlAlumnoEN);



                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol)
{
        DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlAlumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), p_controlalumno);
                DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntasENAux = null;
                if (controlAlumnoEN.Preguntas == null) {
                        controlAlumnoEN.Preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.PreguntaControlEN>();
                }

                foreach (int item in p_preguntacontrol) {
                        preguntasENAux = new DSSGenNHibernate.EN.Moodle.PreguntaControlEN ();
                        preguntasENAux = (DSSGenNHibernate.EN.Moodle.PreguntaControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaControlEN), item);
                        preguntasENAux.Control = controlAlumnoEN;

                        controlAlumnoEN.Preguntas.Add (preguntasENAux);
                }


                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_alumno (int p_controlalumno, string p_alumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlAlumnoEN = null;
                controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), p_controlalumno);

                if (controlAlumnoEN.Alumno.Email == p_alumno) {
                        controlAlumnoEN.Alumno = null;
                }
                else
                        throw new ModelException ("The identifier " + p_alumno + " in p_alumno you are trying to unrelationer, doesn't exist in ControlAlumnoEN");

                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_control (int p_controlalumno, int p_control)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlAlumnoEN = null;
                controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), p_controlalumno);

                if (controlAlumnoEN.Control.Id == p_control) {
                        controlAlumnoEN.Control = null;
                }
                else
                        throw new ModelException ("The identifier " + p_control + " in p_control you are trying to unrelationer, doesn't exist in ControlAlumnoEN");

                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlAlumnoEN = null;
                controlAlumnoEN = (ControlAlumnoEN)session.Load (typeof(ControlAlumnoEN), p_controlalumno);

                DSSGenNHibernate.EN.Moodle.PreguntaControlEN preguntasENAux = null;
                if (controlAlumnoEN.Preguntas != null) {
                        foreach (int item in p_preguntacontrol) {
                                preguntasENAux = (DSSGenNHibernate.EN.Moodle.PreguntaControlEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.PreguntaControlEN), item);
                                if (controlAlumnoEN.Preguntas.Contains (preguntasENAux) == true) {
                                        controlAlumnoEN.Preguntas.Remove (preguntasENAux);
                                        preguntasENAux.Control = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_preguntacontrol you are trying to unrelationer, doesn't exist in ControlAlumnoEN");
                        }
                }

                session.Update (controlAlumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ControlAlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
