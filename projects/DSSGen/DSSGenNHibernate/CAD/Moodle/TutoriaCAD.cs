
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
public partial class TutoriaCAD : BasicCAD, ITutoriaCAD
{
public TutoriaCAD() : base ()
{
}

public TutoriaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TutoriaEN ReadOIDDefault (int id)
{
        TutoriaEN tutoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tutoriaEN = (TutoriaEN)session.Get (typeof(TutoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tutoriaEN;
}


public int New_ (TutoriaEN tutoria)
{
        try
        {
                SessionInitializeTransaction ();
                if (tutoria.Profesor != null) {
                        tutoria.Profesor = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), tutoria.Profesor.Email);

                        tutoria.Profesor.Tutorias.Add (tutoria);
                }
                if (tutoria.Alumno != null) {
                        tutoria.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), tutoria.Alumno.Email);

                        tutoria.Alumno.Tutorias.Add (tutoria);
                }
                if (tutoria.Asignatura != null) {
                        tutoria.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), tutoria.Asignatura.Id);

                        tutoria.Asignatura.Tutorias.Add (tutoria);
                }

                session.Save (tutoria);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tutoria.Id;
}

public void Modify (TutoriaEN tutoria)
{
        try
        {
                SessionInitializeTransaction ();
                TutoriaEN tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), tutoria.Id);

                tutoriaEN.Tema = tutoria.Tema;


                tutoriaEN.Abierta = tutoria.Abierta;


                tutoriaEN.Fecha_creacion = tutoria.Fecha_creacion;


                tutoriaEN.Fecha_cierre = tutoria.Fecha_cierre;


                tutoriaEN.Por_responder = tutoria.Por_responder;

                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
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
                TutoriaEN tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), id);
                session.Delete (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<TutoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TutoriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TutoriaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TutoriaEN>();
                else
                        result = session.CreateCriteria (typeof(TutoriaEN)).List<TutoriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public TutoriaEN ReadOID (int id)
{
        TutoriaEN tutoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tutoriaEN = (TutoriaEN)session.Get (typeof(TutoriaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tutoriaEN;
}

public void Relationer_alumno (int p_tutoria, string p_alumno)
{
        DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);
                tutoriaEN.Alumno = (DSSGenNHibernate.EN.Moodle.AlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AlumnoEN), p_alumno);

                tutoriaEN.Alumno.Tutorias.Add (tutoriaEN);



                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_asignatura (int p_tutoria, int p_asignaturaanyo)
{
        DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);
                tutoriaEN.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), p_asignaturaanyo);

                tutoriaEN.Asignatura.Tutorias.Add (tutoriaEN);



                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_mensajes (int p_tutoria, System.Collections.Generic.IList<int> p_mensaje)
{
        DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);
                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (tutoriaEN.Mensajes == null) {
                        tutoriaEN.Mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
                }

                foreach (int item in p_mensaje) {
                        mensajesENAux = new DSSGenNHibernate.EN.Moodle.MensajeEN ();
                        mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                        mensajesENAux.Tutoria = tutoriaEN;

                        tutoriaEN.Mensajes.Add (mensajesENAux);
                }


                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_profesor (int p_tutoria, string p_profesor)
{
        DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
        try
        {
                SessionInitializeTransaction ();
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);
                tutoriaEN.Profesor = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), p_profesor);

                tutoriaEN.Profesor.Tutorias.Add (tutoriaEN);



                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_alumno (int p_tutoria, string p_alumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);

                if (tutoriaEN.Alumno.Email == p_alumno) {
                        tutoriaEN.Alumno = null;
                }
                else
                        throw new ModelException ("The identifier " + p_alumno + " in p_alumno you are trying to unrelationer, doesn't exist in TutoriaEN");

                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_asignatura (int p_tutoria, int p_asignaturaanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);

                if (tutoriaEN.Asignatura.Id == p_asignaturaanyo) {
                        tutoriaEN.Asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_asignaturaanyo + " in p_asignaturaanyo you are trying to unrelationer, doesn't exist in TutoriaEN");

                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_mensajes (int p_tutoria, System.Collections.Generic.IList<int> p_mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);

                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (tutoriaEN.Mensajes != null) {
                        foreach (int item in p_mensaje) {
                                mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                                if (tutoriaEN.Mensajes.Contains (mensajesENAux) == true) {
                                        tutoriaEN.Mensajes.Remove (mensajesENAux);
                                        mensajesENAux.Tutoria = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_mensaje you are trying to unrelationer, doesn't exist in TutoriaEN");
                        }
                }

                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_profesor (int p_tutoria, string p_profesor)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriaEN = null;
                tutoriaEN = (TutoriaEN)session.Load (typeof(TutoriaEN), p_tutoria);

                if (tutoriaEN.Profesor.Email == p_profesor) {
                        tutoriaEN.Profesor = null;
                }
                else
                        throw new ModelException ("The identifier " + p_profesor + " in p_profesor you are trying to unrelationer, doesn't exist in TutoriaEN");

                session.Update (tutoriaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in TutoriaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
