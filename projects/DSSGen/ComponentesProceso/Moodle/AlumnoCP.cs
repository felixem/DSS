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
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<AlumnoEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numBases = consulta.Total(session);

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
    }
}
