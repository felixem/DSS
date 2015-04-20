
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
public partial class MaterialCAD : BasicCAD, IMaterialCAD
{
public MaterialCAD() : base ()
{
}

public MaterialCAD(ISession sessionAux) : base (sessionAux)
{
}



public MaterialEN ReadOIDDefault (int id)
{
        MaterialEN materialEN = null;

        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Get (typeof(MaterialEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return materialEN;
}


public int New_ (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                if (material.Profesor != null) {
                        material.Profesor = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), material.Profesor.Email);

                        material.Profesor.Materiales.Add (material);
                }
                if (material.Asignatura != null) {
                        material.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), material.Asignatura.Id);

                        material.Asignatura.Materiales.Add (material);
                }

                session.Save (material);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return material.Id;
}

public void Modify (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                MaterialEN materialEN = (MaterialEN)session.Load (typeof(MaterialEN), material.Id);

                materialEN.Nombre = material.Nombre;


                materialEN.Descripcion = material.Descripcion;


                materialEN.Ruta = material.Ruta;


                materialEN.Tam = material.Tam;


                materialEN.Fecha_subida = material.Fecha_subida;


                materialEN.Visible = material.Visible;

                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
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
                MaterialEN materialEN = (MaterialEN)session.Load (typeof(MaterialEN), id);
                session.Delete (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<MaterialEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MaterialEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<MaterialEN>();
                else
                        result = session.CreateCriteria (typeof(MaterialEN)).List<MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public MaterialEN ReadOID (int id)
{
        MaterialEN materialEN = null;

        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Get (typeof(MaterialEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return materialEN;
}

public long ReadCantidad ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MaterialEN self where select count(*) FROM MaterialEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MaterialENreadCantidadHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Relationer_asignatura (int p_material, int p_asignaturaanyo)
{
        DSSGenNHibernate.EN.Moodle.MaterialEN materialEN = null;
        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Load (typeof(MaterialEN), p_material);
                materialEN.Asignatura = (DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN), p_asignaturaanyo);

                materialEN.Asignatura.Materiales.Add (materialEN);



                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Relationer_profesor (int p_material, string p_profesor)
{
        DSSGenNHibernate.EN.Moodle.MaterialEN materialEN = null;
        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Load (typeof(MaterialEN), p_material);
                materialEN.Profesor = (DSSGenNHibernate.EN.Moodle.ProfesorEN)session.Load (typeof(DSSGenNHibernate.EN.Moodle.ProfesorEN), p_profesor);

                materialEN.Profesor.Materiales.Add (materialEN);



                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Unrelationer_asignatura (int p_material, int p_asignaturaanyo)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.MaterialEN materialEN = null;
                materialEN = (MaterialEN)session.Load (typeof(MaterialEN), p_material);

                if (materialEN.Asignatura.Id == p_asignaturaanyo) {
                        materialEN.Asignatura = null;
                }
                else
                        throw new ModelException ("The identifier " + p_asignaturaanyo + " in p_asignaturaanyo you are trying to unrelationer, doesn't exist in MaterialEN");

                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Unrelationer_profesor (int p_material, string p_profesor)
{
        try
        {
                SessionInitializeTransaction ();
                DSSGenNHibernate.EN.Moodle.MaterialEN materialEN = null;
                materialEN = (MaterialEN)session.Load (typeof(MaterialEN), p_material);

                if (materialEN.Profesor.Email == p_profesor) {
                        materialEN.Profesor = null;
                }
                else
                        throw new ModelException ("The identifier " + p_profesor + " in p_profesor you are trying to unrelationer, doesn't exist in MaterialEN");

                session.Update (materialEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DSSGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DSSGenNHibernate.Exceptions.DataLayerException ("Error in MaterialCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
