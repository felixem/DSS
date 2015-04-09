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
        public int CrearGrupoTrabajo()
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear la asignatura
                GrupoTrabajoCEN grupo = new GrupoTrabajoCEN();
                id = grupo.New_(p_cod_grupo,p_nombre,p_descripcion,p_password,p_capacidad,p_asignatura);

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

        //Devolver el resultado de una consulta individual sobre una asignatura
        public AsignaturaEN DameAsignatura(IDameAsignatura consulta)
        {
            AsignaturaEN asig = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                asig = consulta.Execute(session);

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

            return asig;
        }

        //Modificar asignatura
        public void ModificarAsignatura(int oid, string codAsignatura, string nombre,
            string descripcion, bool optativa, bool vigente)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaCEN cen = new AsignaturaCEN();
                //Ejecutar la modificación
                cen.Modify(oid, codAsignatura, nombre, descripcion, optativa, vigente);

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

        //Borrar asignatura a partir de su id
        public void BorrarAsignatura(int id)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaCEN cen = new AsignaturaCEN();
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
