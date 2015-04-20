using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;

namespace ComponentesProceso.Moodle.Commands
{
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de Control contenidos
    public class DameTodosEvaluacionPorAnyo : IDameTodosEvaluacion
    {
        private int anyo;

        public DameTodosEvaluacionPorAnyo(int anyo) {
            this.anyo = anyo;
        }
        //Propiedades
        public int Anyo
        {
            get { return anyo; }
            set {anyo = value; }
        }
        //Ejecutar el método
        public System.Collections.Generic.IList<EvaluacionEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<EvaluacionEN> lista = null;

            EvaluacionCAD cad = new EvaluacionCAD(session);
            EvaluacionCEN en = new EvaluacionCEN(cad);

            //Programar las lecturas
            lista = en.ReadAllPorAnyo(anyo,first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            EvaluacionCAD cad = new EvaluacionCAD(session);
            EvaluacionCEN en = new EvaluacionCEN(cad);

            return en.ReadCantidad();
        }
    }
}

