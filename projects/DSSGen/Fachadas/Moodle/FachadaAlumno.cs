using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    public class FachadaAlumno
    {
        //Metodo que registra al alumno en BD
        public string RegistrarAlumno(string nombre, string apellidos, string pass, string fecha, string dni, string email, string cod)
        {
            AlumnoCP alumno = new AlumnoCP();
            return alumno.CrearAlumno(nombre, apellidos, pass, fecha, dni, email, cod);
        }

        //Método para modificar un alumno en la BD sin modificar su password
        public bool ModificarAlumnoNoPassword(string email, int codAlumno, bool baneado, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                AlumnoCP cp = new AlumnoCP();
                cp.ModificarAlumnoNoPassword(email, codAlumno, baneado, dni, nombre, apellidos, fechaNacimiento);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un alumno en la BD
        public bool BorrarAlumno(int codAlumno)
        {
            try
            {
                AlumnoCP cp = new AlumnoCP();
                cp.BorrarAlumno(codAlumno);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Vincular a un grid view los alumnos con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumno();
            alumnoBind.VincularDameTodos(consulta, grid, first, size, out numAlumnos);
        }

        //Devolver un alumno a partir de un id de alumno
        public AlumnoEN DameAlumno(int id)
        {
            AlumnoEN alumno = null;
            AlumnoCP cp = new AlumnoCP();
            DameAlumnoPorId consulta = new DameAlumnoPorId(id);

            alumno = cp.DameAlumno(consulta);

            if (alumno == null)
                throw new Exception("Alumno no encontrado");

            return alumno;
        }
    }
}
