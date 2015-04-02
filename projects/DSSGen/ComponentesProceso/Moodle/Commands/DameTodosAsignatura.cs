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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de asignaturas contenidas
    public class DameTodosAsignatura : IDameTodosAsignatura
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<AsignaturaEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;

            AsignaturaCAD cad = new AsignaturaCAD(session);
            AsignaturaCEN asignatura = new AsignaturaCEN(cad);

            //Programar las lecturas
            lista = asignatura.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            throw new Exception("Not yet implemented");
        }
    }
}
