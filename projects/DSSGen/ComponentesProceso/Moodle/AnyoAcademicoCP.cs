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
    //Componente de proceso para el año académico
    public class AnyoAcademicoCP : BasicCP
    {
        //Constructor
        public AnyoAcademicoCP() : base() { }

        //Constructor con sesión
        public AnyoAcademicoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de años académicos que satisfacen la consulta
        public System.Collections.Generic.IList<AnyoAcademicoEN> DameTodosTotal(IDameTodosAnyoAcademico consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AnyoAcademicoEN> lista = null;
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

        //Crear un año académico y devolver su id de creación
        public int CrearAnyoAcademico(int anyo, DateTime? fecha_inicio,
            DateTime? fecha_fin, bool finalizado)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear el año académico
                AnyoAcademicoCEN cen = new AnyoAcademicoCEN();
                id = cen.New_(anyo, fecha_inicio, fecha_fin, finalizado);

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

        //Devolver el resultado de una consulta individual sobre un año académico
        public AnyoAcademicoEN DameAnyoAcademico(IDameAnyoAcademico consulta)
        {
            AnyoAcademicoEN anyo = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                anyo = consulta.Execute(session);

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

            return anyo;
        }

        //Modificar año académico
        public void ModificarAnyoAcademico(int oid, int anyo, DateTime? fecha_inicio,
            DateTime? fecha_fin, bool finalizado)
        {
            try
            {
                SessionInitializeTransaction();

                AnyoAcademicoCEN cen = new AnyoAcademicoCEN();
                //Ejecutar la modificación
                cen.Modify(oid,anyo,fecha_inicio,fecha_fin,finalizado);

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

        //Borrar año académico a partir de su id
        public void BorrarAnyoAcademico(int id)
        {
            try
            {
                SessionInitializeTransaction();

                AnyoAcademicoCEN cen = new AnyoAcademicoCEN();
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
