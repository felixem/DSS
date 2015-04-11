using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Interfaz utilizada para representar métodos que devuelven todos los cursos a partir
    //de un índice, un tamaño y devuelve la cantidad de filas totales resultado de la consulta
    public interface IDameTodosCurso
    {
        //Ejecutar el método
        System.Collections.Generic.IList<CursoEN> Execute(ISession session, int first, int size);
        //Total de objectos que cumplen la condición de la consulta
        long Total(ISession session);
    }
}
