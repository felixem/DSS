using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using ComponentesProceso.Moodle.Commands;

namespace ComponentesProceso.Moodle
{
    public class AlumnoCP : BasicCP
    {
         //Constructor
        public AlumnoCP() : base() { }

        //Constructor con sesión
        public AlumnoCP(ISession sesion) : base(sesion) { }

        //Registra el alumno en la BD
        public string CrearAlumno(string nombre, string apellidos, string pass, string fecha, string dni, string email, string cod)
        {
            AlumnoCEN aluCen = new AlumnoCEN();
            string resultado;

            try
            {
                resultado = aluCen.New_(Convert.ToInt32(cod), false, email, dni, pass, nombre, apellidos, Convert.ToDateTime(fecha), new ExpedienteEN());
            }
            catch (Exception)
            {
                resultado = "Invalido";
            }
            return resultado;
        }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de alumnos que satisfacen la consulta
        public System.Collections.Generic.IList<AlumnoEN> DameTodosTotal(IDameTodosAlumno consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AlumnoEN> lista = null;
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

        //Devolver el resultado de una consulta individual sobre un alumno
        public AlumnoEN DameAlumno(IDameAlumno consulta)
        {
            AlumnoEN alu = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                alu = consulta.Execute(session);

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

            return alu;
        }

        //Modificar alumno sin modificar su contraseña
        public void ModificarAlumno(string email,int codAlumno, bool baneado, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                SessionInitializeTransaction();

                AlumnoCEN cen = new AlumnoCEN();
                //Recuperar datos del alumno
                AlumnoEN alu = cen.ReadCod(codAlumno);
                //Ejecutar la modificación
                cen.Modify(email,codAlumno,baneado,dni,alu.Password,nombre,apellidos, fechaNacimiento);

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

        //Borrar alumno a partir de su código de alumno
        public void BorrarAlumno(int codAlumno)
        {
            try
            {
                SessionInitializeTransaction();

                AlumnoCEN cen = new AlumnoCEN();
                //Recuperar datos del alumno
                AlumnoEN alu = cen.ReadCod(codAlumno);
                //Ejecutar la modificación
                cen.Destroy(alu.Email);

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
