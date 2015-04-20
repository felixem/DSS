using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz utilizada para representar operaciones de obtención de año académico
    public interface IDameAnyoAcademico
    {
        //Ejecutar la consulta
        AnyoAcademicoEN Execute(ISession sesion);
    }
}
