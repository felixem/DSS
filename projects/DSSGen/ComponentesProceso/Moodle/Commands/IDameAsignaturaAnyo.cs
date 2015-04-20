using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz utilizada para representar operaciones de obtención de asignatura-anyo
    public interface IDameAsignaturaAnyo
    {
        //Ejecutar la consulta
        AsignaturaAnyoEN Execute(ISession sesion);
    }
}
