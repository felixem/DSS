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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de cursos contenidos
    public class DameTodosCurso : IDameTodosCurso
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<CursoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<CursoEN> lista = null;

            CursoCAD cad = new CursoCAD(session);
            CursoCEN curso = new CursoCEN(cad);

            //Programar las lecturas
            lista = curso.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            CursoCAD cad = new CursoCAD(session);
            CursoCEN curso = new CursoCEN(cad);

            return curso.ReadCantidad();
        }
    }
}
