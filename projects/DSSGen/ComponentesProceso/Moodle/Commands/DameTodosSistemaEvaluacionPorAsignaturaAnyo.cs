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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de sistema evaluacion-asignaturaanyo contenidas
    //a partir de la id del asignaturaanyo
    public class DameTodosSistemaEvaluacionPorAsignaturaAnyo : IDameTodosSistemaEvaluacion
    {
        //Variables
        private int asignaturaanyo;

        //Constructor a partir de una id de asignaturaanyo
        public DameTodosSistemaEvaluacionPorAsignaturaAnyo(int asignaturaanyo)
        {
            this.asignaturaanyo = asignaturaanyo;
        }

        //Propiedades
        public int AsignaturaAnyo
        {
            get { return asignaturaanyo; }
            set { asignaturaanyo = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<SistemaEvaluacionEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<SistemaEvaluacionEN> lista = null;

            SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
            SistemaEvaluacionCEN cen = new SistemaEvaluacionCEN(cad);

            //Programar las lecturas
            lista = cen.ReadAllPorAsignaturaAnyo(asignaturaanyo, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(session);
            SistemaEvaluacionCEN cen = new SistemaEvaluacionCEN(cad);

            return cen.ReadCantidadPorAsignaturaAnyo(asignaturaanyo);
        }
    }
}
