using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz que encapsula las consultas que devuelven un único curso
    public interface IDameCurso
    {
        //Ejecutar la consulta
        CursoEN Execute(ISession sesion);
    }
}
