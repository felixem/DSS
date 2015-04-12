using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para los grupos de trabajo
    public class GrupoTrabajoCP : BasicCP
    {
        //Constructor
        public GrupoTrabajoCP() : base() { }

        //Constructor con sesión
        public GrupoTrabajoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de grupos de trabajo que satisfacen la consulta
        public System.Collections.Generic.IList<GrupoTrabajoEN> DameTodosTotal(IDameTodosGrupoTrabajo consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<GrupoTrabajoEN> lista = null;
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

        //Crear un grupo de trabajo y devolver su id de creación
        public int CrearGrupoTrabajo(string cod, string nombre, string descripcion,
            string password, int capacidad, int asignatura_anyo)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear la asignatura
                GrupoTrabajoCEN grupo = new GrupoTrabajoCEN();
                id = grupo.New_(cod,nombre,descripcion,password,capacidad,asignatura_anyo);

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

        //Devolver el resultado de una consulta individual sobre un grupo de trabajo
        public GrupoTrabajoEN DameGrupoTrabajo(IDameGrupoTrabajo consulta)
        {
            GrupoTrabajoEN grupo = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                grupo = consulta.Execute(session);

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

            return grupo;
        }

        //Modificar grupo de trabajo
        public void ModificarGrupoTrabajo(int id, string cod, string nombre, string descripcion,
            string password, int capacidad)
        {
            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCEN cen = new GrupoTrabajoCEN();
                //Ejecutar la modificación
                cen.Modify(id,cod,nombre,descripcion,password,capacidad);

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

        //Borrar grupo de trabajo a partir de su id
        public void BorrarGrupoTrabajo(int id)
        {
            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCEN cen = new GrupoTrabajoCEN();
                //Ejecutar el borrado
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

        //Desvincular alumnos de un grupo de trabajo
        public void DesvincularAlumnos(int id, IList<string> emails)
        {
            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCEN cen = new GrupoTrabajoCEN();
                //Ejecutar el borrado
                cen.Unrelationer_alumnos(id, emails);

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
