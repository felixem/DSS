
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
public partial class AsignaturaCAD : BasicCAD, IAsignaturaCAD
{
public AsignaturaCAD() : base ()
{
}

public AsignaturaCAD(ISession sessionAux) : base (sessionAux)
{
}



public AsignaturaEN ReadOIDDefault (int id)
{
        AsignaturaEN asignaturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                asignaturaEN = (AsignaturaEN)session.Get (typeof(AsignaturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asignaturaEN;
}


public int New_ (AsignaturaEN asignatura)
{
        try
        {
                SessionInitializeTransaction ();
                if (asignatura.Curso != null) {
                        asignatura.Curso = (DSSGenNHibernate.EN.Moodle.CursoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.CursoEN), asignatura.Curso.Id);

                        asignatura.Curso.Asignaturas.Add (asignatura);
                }

                session.Save (asignatura);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asignatura.Id;
}

public void Modify (AsignaturaEN asignatura)
{
        try
        {
                SessionInitializeTransaction ();
                AsignaturaEN asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), asignatura.Id);

                asignaturaEN.Cod_asignatura = asignatura.Cod_asignatura;


                asignaturaEN.Nombre = asignatura.Nombre;


                asignaturaEN.Descripcion = asignatura.Descripcion;


                asignaturaEN.Optativa = asignatura.Optativa;


                asignaturaEN.Vigente = asignatura.Vigente;

                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
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
                AsignaturaEN asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), id);
                session.Delete (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<AsignaturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AsignaturaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AsignaturaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AsignaturaEN>();
                else
                        result = session.CreateCriteria (typeof(AsignaturaEN)).List<AsignaturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public AsignaturaEN ReadOID (int id)
{
        AsignaturaEN asignaturaEN = null;

        try
        {
                SessionInitializeTransaction ();
                asignaturaEN = (AsignaturaEN)session.Get (typeof(AsignaturaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return asignaturaEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaEN self where select count(*) FROM AsignaturaEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
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
                //String sql = @"FROM AsignaturaEN self where FROM AsignaturaEN asig where asig.Cod_asignatura=:cod";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaENreadCodHQL");
                query.SetParameter ("cod", cod);


                result = query.UniqueResult<DSSGenNHibernate.EN.Moodle.AsignaturaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public long ReadCantidadVinculablesAAnyo (int id)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AsignaturaEN self where select count(distinct asig) FROM AsignaturaEN asig where asig.Id NOT IN (select asignatura.Id FROM AsignaturaEN asignatura INNER JOIN asignatura.Asignaturas_anyo as asig_anyo where asig_anyo.Anyo.Id=:id) ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AsignaturaENreadCantidadVinculablesAAnyoHQL");
                query.SetParameter ("id", id);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_asignaturas_anyo (int p_asignatura, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), p_asignatura);
                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturas_anyoENAux = null;
                if (asignaturaEN.Asignaturas_anyo == null) {
                        asignaturaEN.Asignaturas_anyo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
                }

                foreach (int item in p_asignaturaanyo) {
                        asignaturas_anyoENAux = new DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ();
                        asignaturas_anyoENAux = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), item);
                        asignaturas_anyoENAux.Asignatura = asignaturaEN;

                        asignaturaEN.Asignaturas_anyo.Add (asignaturas_anyoENAux);
                }


                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_bolsas_preguntas (int p_asignatura, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), p_asignatura);
                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsas_preguntasENAux = null;
                if (asignaturaEN.Bolsas_preguntas == null) {
                        asignaturaEN.Bolsas_preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN>();
                }

                foreach (int item in p_bolsapreguntas) {
                        bolsas_preguntasENAux = new DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN ();
                        bolsas_preguntasENAux = (DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN), item);
                        bolsas_preguntasENAux.Asignatura = asignaturaEN;

                        asignaturaEN.Bolsas_preguntas.Add (bolsas_preguntasENAux);
                }


                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_curso (int p_asignatura, int p_curso)
{
        DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturaEN = null;
        try
        {
                SessionInitializeTransaction ();
                asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), p_asignatura);
                asignaturaEN.Curso = (DSSGenNHibernate.EN.Moodle.CursoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.CursoEN), p_curso);

                asignaturaEN.Curso.Asignaturas.Add (asignaturaEN);



                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignaturas_anyo (int p_asignatura, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturaEN = null;
                asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), p_asignatura);

                DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignaturas_anyoENAux = null;
                if (asignaturaEN.Asignaturas_anyo != null) {
                        foreach (int item in p_asignaturaanyo) {
                                asignaturas_anyoENAux = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), item);
                                if (asignaturaEN.Asignaturas_anyo.Contains (asignaturas_anyoENAux) == true) {
                                        asignaturaEN.Asignaturas_anyo.Remove (asignaturas_anyoENAux);
                                        asignaturas_anyoENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_asignaturaanyo you are trying to unrelationer, doesn't exist in AsignaturaEN");
                        }
                }

                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_bolsas_preguntas (int p_asignatura, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturaEN = null;
                asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), p_asignatura);

                DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsas_preguntasENAux = null;
                if (asignaturaEN.Bolsas_preguntas != null) {
                        foreach (int item in p_bolsapreguntas) {
                                bolsas_preguntasENAux = (DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN), item);
                                if (asignaturaEN.Bolsas_preguntas.Contains (bolsas_preguntasENAux) == true) {
                                        asignaturaEN.Bolsas_preguntas.Remove (bolsas_preguntasENAux);
                                        bolsas_preguntasENAux.Asignatura = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_bolsapreguntas you are trying to unrelationer, doesn't exist in AsignaturaEN");
                        }
                }

                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_curso (int p_asignatura, int p_curso)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.AsignaturaEN asignaturaEN = null;
                asignaturaEN = (AsignaturaEN)session.Load (typeof(AsignaturaEN), p_asignatura);

                if (asignaturaEN.Curso.Id == p_curso) {
                        asignaturaEN.Curso = null;
                }
                else
                        throw new ModelException ("The identifier " + p_curso + " in p_curso you are trying to unrelationer, doesn't exist in AsignaturaEN");

                session.Update (asignaturaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in AsignaturaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
