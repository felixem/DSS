using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz que encapsula las consultas que devuelven una única asignatura
    public interface IDameAsignatura
    {
        //Ejecutar la consulta
        AsignaturaEN Execute(ISession sesion);
    }
}
