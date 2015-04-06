using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;

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

        //Vincular a un grid view los alumnos con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numBases)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumno();
            alumnoBind.VincularDameTodos(consulta, grid, first, size, out numBases);
        }
    }
}
