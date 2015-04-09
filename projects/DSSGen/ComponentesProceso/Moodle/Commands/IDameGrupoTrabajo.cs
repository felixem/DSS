using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz que encapsula las consultas que devuelven un único grupo de trabajo
    public interface IDameGrupoTrabajo
    {
        //Ejecutar la consulta
        GrupoTrabajoEN Execute(ISession sesion);
    }
}
