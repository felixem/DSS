using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz utilizada para representar métodos que devuelven todos los Entrega a partir
    //de un índice, un tamaño y devuelve la cantidad de filas totales resultado de la consulta
    public interface IDameTodosEntregaAlumno
    {
        //Ejecutar el método
        System.Collections.Generic.IList<EntregaAlumnoEN> Execute(ISession session, int first, int size);
        //Total de objectos que cumplen la condición de la consulta
        long Total(ISession session);
    }
}
