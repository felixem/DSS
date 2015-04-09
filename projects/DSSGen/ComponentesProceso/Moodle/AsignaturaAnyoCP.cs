using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para la asignatura-anyo
    public class AsignaturaAnyoCP : BasicCP
    {
        //Constructor
        public AsignaturaAnyoCP() : base() { }

        //Constructor con sesión
        public AsignaturaAnyoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de asignaturas-anyo que satisfacen la consulta
        public System.Collections.Generic.IList<AsignaturaAnyoEN> DameTodosTotal(IDameTodosAsignaturaAnyo consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AsignaturaAnyoEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numElementos = consulta.Total(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return lista;
        }

        //Crear una asignatura-anyo devolver su id de creación
        public int CrearAsignaturaAnyo(int idAnyo, int idAsignatura)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear el año académico
                AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN();
                id = cen.New_(idAnyo,idAsignatura);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return id;
        }

        //Devolver el resultado de una consulta individual sobre una asignatura-anyo
        public AsignaturaAnyoEN DameAsignaturaAnyo(IDameAsignaturaAnyo consulta)
        {
            AsignaturaAnyoEN asignaturaAnyo = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                asignaturaAnyo = consulta.Execute(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return asignaturaAnyo;
        }

        //Modificar asignatura-anyo
        public void ModificarAsignaturaAnyo(int oid)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN();
                //Ejecutar la modificación
                cen.Modify(oid);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }

        //Borrar asignatura-anyo a partir de su id
        public void BorrarAsignaturaAnyo(int id)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN();
                //Ejecutar la modificación
                cen.Destroy(id);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
