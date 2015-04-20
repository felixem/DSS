using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    public class ProfesorCP : BasicCP
    {
        //Constructor
        public ProfesorCP() : base() { }

        //Constructor con sesión
        public ProfesorCP(ISession sesion) : base(sesion) { }

        //Registra el profesor en la BD y de
        public string CrearProfesor(string nombre, string apellidos, string pass, DateTime fecha, string dni, string email, int cod)
        {
            string resultado;

            try
            {
                SessionInitializeTransaction();
                //Creo el profesor    
                ProfesorCAD cad = new ProfesorCAD(session);
                ProfesorCEN cen = new ProfesorCEN(cad);
                resultado = cen.New_(cod, email, dni, pass, nombre, apellidos, fecha);

                SessionCommit();
            }
            catch (Exception e)
            {
                SessionRollBack();
                throw e;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
            return resultado;
        }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de profesores que satisfacen la consulta
        public System.Collections.Generic.IList<ProfesorEN> DameTodosTotal(IDameTodosProfesor consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<ProfesorEN> lista = null;
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

        //Devolver el resultado de una consulta individual sobre un profesor
        public ProfesorEN DameProfesor(IDameProfesor consulta)
        {
            ProfesorEN prof = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                prof = consulta.Execute(session);

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

            return prof;
        }

        //Modificar profesor sin modificar su contraseña
        public void ModificarProfesorNoPassword(string email, int codProfesor, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                SessionInitializeTransaction();

                ProfesorCAD cad = new ProfesorCAD(session);
                ProfesorCEN cen = new ProfesorCEN(cad);
                //Ejecutar la modificación
                cen.ModifyNoPassword(email, dni, nombre, apellidos, fechaNacimiento, codProfesor);

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

        //Borrar profesor a partir de su código de profesor
        public void BorrarProfesor(int codProfesor)
        {
            try
            {
                SessionInitializeTransaction();

                ProfesorCAD cad = new ProfesorCAD(session);
                ProfesorCEN cen = new ProfesorCEN(cad);
                //Recuperar datos del profesor
                ProfesorEN prof = cen.ReadCod(codProfesor);
                //Ejecutar la modificación
                cen.Destroy(prof.Email);

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
