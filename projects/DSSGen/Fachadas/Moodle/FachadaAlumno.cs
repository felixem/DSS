using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;

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
    }
}
