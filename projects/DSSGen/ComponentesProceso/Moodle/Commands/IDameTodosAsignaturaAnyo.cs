using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz utilizada para representar métodos que devuelven todas las asignaturas-anyo a partir
    //de un índice, un tamaño y devuelve la cantidad de filas totales resultado de la consulta
    public interface IDameTodosAsignaturaAnyo
    {
        //Ejecutar el método
        System.Collections.Generic.IList<AsignaturaAnyoEN> Execute(ISession session, int first, int size);
        //Total de objectos que cumplen la condición de la consulta
        long Total(ISession session);
    }
}
