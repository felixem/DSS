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
        public System.Collections.Generic.IList<BolsaPreguntasEN> Execute(ISession session, int first, int size, out long total)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;

            BolsaPreguntasCAD cad = new BolsaPreguntasCAD(session);
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN(cad);

            //Programar las lecturas
            lista = bolsa.ReadAll(first, size);
            total = bolsa.ReadCantidad();

            //Devolver lista
            return lista;
        }
    }
}
