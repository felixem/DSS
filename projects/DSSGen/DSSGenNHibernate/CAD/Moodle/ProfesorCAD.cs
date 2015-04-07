
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
public partial class ProfesorCAD : BasicCAD, IProfesorCAD
{
public ProfesorCAD() : base ()
{
}

public ProfesorCAD(ISession sessionAux) : base (sessionAux)
{
}



public ProfesorEN ReadOIDDefault (string email)
{
        ProfesorEN profesorEN = null;

        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Get (typeof(ProfesorEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return profesorEN;
}


public string New_ (ProfesorEN profesor)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (profesor);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return profesor.Email;
}

public void Modify (ProfesorEN profesor)
{
        try
        {
                SessionInitializeTransaction ();
                ProfesorEN profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), profesor.Email);

                profesorEN.Cod_profesor = profesor.Cod_profesor;


                profesorEN.Dni = profesor.Dni;


                profesorEN.Password = profesor.Password;


                profesorEN.Nombre = profesor.Nombre;


                profesorEN.Apellidos = profesor.Apellidos;


                profesorEN.Fecha_nacimiento = profesor.Fecha_nacimiento;

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email)
{
        try
        {
                SessionInitializeTransaction ();
                ProfesorEN profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), email);
                session.Delete (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProfesorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProfesorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProfesorEN>();
                else
                        result = session.CreateCriteria (typeof(ProfesorEN)).List<ProfesorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public ProfesorEN ReadOID (string email)
{
        ProfesorEN profesorEN = null;

        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Get (typeof(ProfesorEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return profesorEN;
}

public void Relationer_entregas_propuestas (string p_profesor, System.Collections.Generic.IList<int> p_entrega)
{
        DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);
                DSSGenNHibernate.EN.Moodle.EntregaEN entregas_propuestasENAux = null;
                if (profesorEN.Entregas_propuestas == null) {
                        profesorEN.Entregas_propuestas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaEN>();
                }

                foreach (int item in p_entrega) {
                        entregas_propuestasENAux = new DSSGenNHibernate.EN.Moodle.EntregaEN ();
                        entregas_propuestasENAux = (DSSGenNHibernate.EN.Moodle.EntregaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaEN), item);
                        entregas_propuestasENAux.Profesor = profesorEN;

                        profesorEN.Entregas_propuestas.Add (entregas_propuestasENAux);
                }


                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_materiales (string p_profesor, System.Collections.Generic.IList<int> p_material)
{
        DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);
                DSSGenNHibernate.EN.Moodle.MaterialEN materialesENAux = null;
                if (profesorEN.Materiales == null) {
                        profesorEN.Materiales = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MaterialEN>();
                }

                foreach (int item in p_material) {
                        materialesENAux = new DSSGenNHibernate.EN.Moodle.MaterialEN ();
                        materialesENAux = (DSSGenNHibernate.EN.Moodle.MaterialEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MaterialEN), item);
                        materialesENAux.Profesor = profesorEN;

                        profesorEN.Materiales.Add (materialesENAux);
                }


                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_mensajes (string p_profesor, System.Collections.Generic.IList<int> p_mensaje)
{
        DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);
                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (profesorEN.Mensajes == null) {
                        profesorEN.Mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
                }

                foreach (int item in p_mensaje) {
                        mensajesENAux = new DSSGenNHibernate.EN.Moodle.MensajeEN ();
                        mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                        mensajesENAux.Usuario = profesorEN;

                        profesorEN.Mensajes.Add (mensajesENAux);
                }


                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_tutorias (string p_profesor, System.Collections.Generic.IList<int> p_tutoria)
{
        DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
        try
        {
                SessionInitializeTransaction ();
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriasENAux = null;
                if (profesorEN.Tutorias == null) {
                        profesorEN.Tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
                }

                foreach (int item in p_tutoria) {
                        tutoriasENAux = new DSSGenNHibernate.EN.Moodle.TutoriaEN ();
                        tutoriasENAux = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), item);
                        tutoriasENAux.Profesor = profesorEN;

                        profesorEN.Tutorias.Add (tutoriasENAux);
                }


                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_entregas_propuestas (string p_profesor, System.Collections.Generic.IList<int> p_entrega)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);

                DSSGenNHibernate.EN.Moodle.EntregaEN entregas_propuestasENAux = null;
                if (profesorEN.Entregas_propuestas != null) {
                        foreach (int item in p_entrega) {
                                entregas_propuestasENAux = (DSSGenNHibernate.EN.Moodle.EntregaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaEN), item);
                                if (profesorEN.Entregas_propuestas.Contains (entregas_propuestasENAux) == true) {
                                        profesorEN.Entregas_propuestas.Remove (entregas_propuestasENAux);
                                        entregas_propuestasENAux.Profesor = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entrega you are trying to unrelationer, doesn't exist in ProfesorEN");
                        }
                }

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_materiales (string p_profesor, System.Collections.Generic.IList<int> p_material)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);

                DSSGenNHibernate.EN.Moodle.MaterialEN materialesENAux = null;
                if (profesorEN.Materiales != null) {
                        foreach (int item in p_material) {
                                materialesENAux = (DSSGenNHibernate.EN.Moodle.MaterialEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MaterialEN), item);
                                if (profesorEN.Materiales.Contains (materialesENAux) == true) {
                                        profesorEN.Materiales.Remove (materialesENAux);
                                        materialesENAux.Profesor = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_material you are trying to unrelationer, doesn't exist in ProfesorEN");
                        }
                }

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_mensajes (string p_profesor, System.Collections.Generic.IList<int> p_mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);

                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (profesorEN.Mensajes != null) {
                        foreach (int item in p_mensaje) {
                                mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                                if (profesorEN.Mensajes.Contains (mensajesENAux) == true) {
                                        profesorEN.Mensajes.Remove (mensajesENAux);
                                        mensajesENAux.Usuario = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_mensaje you are trying to unrelationer, doesn't exist in ProfesorEN");
                        }
                }

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_tutorias (string p_profesor, System.Collections.Generic.IList<int> p_tutoria)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.ProfesorEN profesorEN = null;
                profesorEN = (ProfesorEN)session.Load (typeof(ProfesorEN), p_profesor);

                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriasENAux = null;
                if (profesorEN.Tutorias != null) {
                        foreach (int item in p_tutoria) {
                                tutoriasENAux = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), item);
                                if (profesorEN.Tutorias.Contains (tutoriasENAux) == true) {
                                        profesorEN.Tutorias.Remove (tutoriasENAux);
                                        tutoriasENAux.Profesor = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_tutoria you are trying to unrelationer, doesn't exist in ProfesorEN");
                        }
                }

                session.Update (profesorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in ProfesorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
