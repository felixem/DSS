using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using NHibernate;

namespace ComponentesProceso.Moodle.Commands
{
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de sistemas de evaluacion contenidos
    public class DameTodosSistemaEvaluacion : IDameTodosSistemaEvaluacion
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<SistemaEvaluacionEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<SistemaEvaluacionEN> lista = null;

            SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
            SistemaEvaluacionCEN stmeval = new SistemaEvaluacionCEN(cad);

            //Programar las lecturas
            lista = stmeval.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
            SistemaEvaluacionCEN stmeval = new SistemaEvaluacionCEN(cad);

            return stmeval.ReadCantidad();
        }
    }
}
