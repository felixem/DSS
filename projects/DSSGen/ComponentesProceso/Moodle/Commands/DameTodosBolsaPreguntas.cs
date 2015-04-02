using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de bolsas contenidas
    public class DameTodosBolsaPreguntas : IDameTodosBolsaPreguntas
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<BolsaPreguntasEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;

            BolsaPreguntasCAD cad = new BolsaPreguntasCAD(session);
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN(cad);

            //Programar las lecturas
            lista = bolsa.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Devolver la cantidad de objetos que cumplen las condiciones de la consulta sin rangos
        public long Total(ISession session)
        {
            BolsaPreguntasCAD cad = new BolsaPreguntasCAD(session);
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN(cad);

            return bolsa.ReadCantidad();
        }

    }
}
