
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
public partial class AlumnoCAD : BasicCAD, IAlumnoCAD
{
public AlumnoCAD() : base ()
{
}

public AlumnoCAD(ISession sessionAux) : base (sessionAux)
{
}



public AlumnoEN ReadOIDDefault (string email)
{
        AlumnoEN alumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Get (typeof(AlumnoEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumnoEN;
}


public string New_ (AlumnoEN alumno)
{
        try
        {
                SessionInitializeTransaction ();
                if (alumno.Expediente != null) {
                        alumno.Expediente.Alumno = alumno;
                        session.Save (alumno.Expediente);
                }

                session.Save (alumno);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumno.Email;
}

public void Modify (AlumnoEN alumno)
{
        try
        {
                SessionInitializeTransaction ();
                AlumnoEN alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), alumno.Email);

                alumnoEN.Cod_alumno = alumno.Cod_alumno;


                alumnoEN.Baneado = alumno.Baneado;


                alumnoEN.Dni = alumno.Dni;


                alumnoEN.Password = alumno.Password;


                alumnoEN.Nombre = alumno.Nombre;


                alumnoEN.Apellidos = alumno.Apellidos;


                alumnoEN.Fecha_nacimiento = alumno.Fecha_nacimiento;

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
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
                AlumnoEN alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), email);
                session.Delete (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlumnoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AlumnoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AlumnoEN>();
                else
                        result = session.CreateCriteria (typeof(AlumnoEN)).List<AlumnoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public AlumnoEN ReadOID (string email)
{
        AlumnoEN alumnoEN = null;

        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Get (typeof(AlumnoEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return alumnoEN;
}

public void Relationer_controles (string p_alumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlesENAux = null;
                if (alumnoEN.Controles == null) {
                        alumnoEN.Controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
                }

                foreach (int item in p_controlalumno) {
                        controlesENAux = new DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ();
                        controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), item);
                        controlesENAux.Alumno = alumnoEN;

                        alumnoEN.Controles.Add (controlesENAux);
                }


                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_entregas (string p_alumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregasENAux = null;
                if (alumnoEN.Entregas == null) {
                        alumnoEN.Entregas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
                }

                foreach (int item in p_entregaalumno) {
                        entregasENAux = new DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN ();
                        entregasENAux = (DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN), item);
                        entregasENAux.Alumno = alumnoEN;

                        alumnoEN.Entregas.Add (entregasENAux);
                }


                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_expediente (string p_alumno, int p_expediente)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                alumnoEN.Expediente = (DSSGenNHibernate.EN.Moodle.ExpedienteEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEN), p_expediente);

                alumnoEN.Expediente.Alumno = alumnoEN;




                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupos_trabajoENAux = null;
                if (alumnoEN.Grupos_trabajo == null) {
                        alumnoEN.Grupos_trabajo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();
                }

                foreach (int item in p_grupotrabajo) {
                        grupos_trabajoENAux = new DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN ();
                        grupos_trabajoENAux = (DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN), item);
                        grupos_trabajoENAux.Alumnos.Add (alumnoEN);

                        alumnoEN.Grupos_trabajo.Add (grupos_trabajoENAux);
                }


                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (alumnoEN.Mensajes == null) {
                        alumnoEN.Mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
                }

                foreach (int item in p_mensaje) {
                        mensajesENAux = new DSSGenNHibernate.EN.Moodle.MensajeEN ();
                        mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                        mensajesENAux.Usuario = alumnoEN;

                        alumnoEN.Mensajes.Add (mensajesENAux);
                }


                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_sistemas_evaluacion (string p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN sistemas_evaluacionENAux = null;
                if (alumnoEN.Sistemas_evaluacion == null) {
                        alumnoEN.Sistemas_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN>();
                }

                foreach (int item in p_evaluacionalumno) {
                        sistemas_evaluacionENAux = new DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN ();
                        sistemas_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN), item);
                        sistemas_evaluacionENAux.Alumno = alumnoEN;

                        alumnoEN.Sistemas_evaluacion.Add (sistemas_evaluacionENAux);
                }


                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria)
{
        DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
        try
        {
                SessionInitializeTransaction ();
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);
                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriasENAux = null;
                if (alumnoEN.Tutorias == null) {
                        alumnoEN.Tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
                }

                foreach (int item in p_tutoria) {
                        tutoriasENAux = new DSSGenNHibernate.EN.Moodle.TutoriaEN ();
                        tutoriasENAux = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), item);
                        tutoriasENAux.Alumno = alumnoEN;

                        alumnoEN.Tutorias.Add (tutoriasENAux);
                }


                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_controles (string p_alumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                DSSGenNHibernate.EN.Moodle.ControlAlumnoEN controlesENAux = null;
                if (alumnoEN.Controles != null) {
                        foreach (int item in p_controlalumno) {
                                controlesENAux = (DSSGenNHibernate.EN.Moodle.ControlAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ControlAlumnoEN), item);
                                if (alumnoEN.Controles.Contains (controlesENAux) == true) {
                                        alumnoEN.Controles.Remove (controlesENAux);
                                        controlesENAux.Alumno = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_controlalumno you are trying to unrelationer, doesn't exist in AlumnoEN");
                        }
                }

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_entregas (string p_alumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN entregasENAux = null;
                if (alumnoEN.Entregas != null) {
                        foreach (int item in p_entregaalumno) {
                                entregasENAux = (DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN), item);
                                if (alumnoEN.Entregas.Contains (entregasENAux) == true) {
                                        alumnoEN.Entregas.Remove (entregasENAux);
                                        entregasENAux.Alumno = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_entregaalumno you are trying to unrelationer, doesn't exist in AlumnoEN");
                        }
                }

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_expediente (string p_alumno, int p_expediente)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                if (alumnoEN.Expediente.Id == p_expediente) {
                        alumnoEN.Expediente = null;
                        DSSGenNHibernate.EN.Moodle.ExpedienteEN expedienteEN = (DSSGenNHibernate.EN.Moodle.ExpedienteEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ExpedienteEN), p_expediente);
                        expedienteEN.Alumno = null;
                }
                else
                        throw new ModelException ("The identifier " + p_expediente + " in p_expediente you are trying to unrelationer, doesn't exist in AlumnoEN");

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN grupos_trabajoENAux = null;
                if (alumnoEN.Grupos_trabajo != null) {
                        foreach (int item in p_grupotrabajo) {
                                grupos_trabajoENAux = (DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN), item);
                                if (alumnoEN.Grupos_trabajo.Contains (grupos_trabajoENAux) == true) {
                                        alumnoEN.Grupos_trabajo.Remove (grupos_trabajoENAux);
                                        grupos_trabajoENAux.Alumnos.Remove (alumnoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_grupotrabajo you are trying to unrelationer, doesn't exist in AlumnoEN");
                        }
                }

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                DSSGenNHibernate.EN.Moodle.MensajeEN mensajesENAux = null;
                if (alumnoEN.Mensajes != null) {
                        foreach (int item in p_mensaje) {
                                mensajesENAux = (DSSGenNHibernate.EN.Moodle.MensajeEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.MensajeEN), item);
                                if (alumnoEN.Mensajes.Contains (mensajesENAux) == true) {
                                        alumnoEN.Mensajes.Remove (mensajesENAux);
                                        mensajesENAux.Usuario = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_mensaje you are trying to unrelationer, doesn't exist in AlumnoEN");
                        }
                }

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_sistemas_evaluacion (string p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN sistemas_evaluacionENAux = null;
                if (alumnoEN.Sistemas_evaluacion != null) {
                        foreach (int item in p_evaluacionalumno) {
                                sistemas_evaluacionENAux = (DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN), item);
                                if (alumnoEN.Sistemas_evaluacion.Contains (sistemas_evaluacionENAux) == true) {
                                        alumnoEN.Sistemas_evaluacion.Remove (sistemas_evaluacionENAux);
                                        sistemas_evaluacionENAux.Alumno = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_evaluacionalumno you are trying to unrelationer, doesn't exist in AlumnoEN");
                        }
                }

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AlumnoEN alumnoEN = null;
                alumnoEN = (AlumnoEN)session.Load (typeof(AlumnoEN), p_alumno);

                DSSGenNHibernate.EN.Moodle.TutoriaEN tutoriasENAux = null;
                if (alumnoEN.Tutorias != null) {
                        foreach (int item in p_tutoria) {
                                tutoriasENAux = (DSSGenNHibernate.EN.Moodle.TutoriaEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.TutoriaEN), item);
                                if (alumnoEN.Tutorias.Contains (tutoriasENAux) == true) {
                                        alumnoEN.Tutorias.Remove (tutoriasENAux);
                                        tutoriasENAux.Alumno = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_tutoria you are trying to unrelationer, doesn't exist in AlumnoEN");
                        }
                }

                session.Update (alumnoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AlumnoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
