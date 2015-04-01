using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz utilizada para representar métodos que devuelven todas las bolsas de preguntas a partir
    //de un índice, un tamaño y devuelve la cantidad de filas totales resultado de la consulta
    public interface IDameTodosBolsaPreguntas
    {
        //Ejecutar el método
        System.Collections.Generic.IList<BolsaPreguntasEN> Execute(ISession session, int first, int size, out long total);
    }
}
