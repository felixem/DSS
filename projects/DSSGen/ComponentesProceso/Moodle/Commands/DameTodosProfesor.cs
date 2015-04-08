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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de profesores contenidos
    public class DameTodosProfesor : IDameTodosProfesor
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<ProfesorEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<ProfesorEN> lista = null;

            ProfesorCAD cad = new ProfesorCAD(session);
            ProfesorCEN profesor = new ProfesorCEN(cad);

            //Programar las lecturas
            lista = profesor.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            ProfesorCAD cad = new ProfesorCAD(session);
            ProfesorCEN profesor = new ProfesorCEN(cad);

            return profesor.ReadCantidad();
        }
    }
}
