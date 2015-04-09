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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de años académicos contenidos
    public class DameTodosAnyoAcademico : IDameTodosAnyoAcademico
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<AnyoAcademicoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AnyoAcademicoEN> lista = null;

            AnyoAcademicoCAD cad = new AnyoAcademicoCAD(session);
            AnyoAcademicoCEN cen = new AnyoAcademicoCEN(cad);

            //Programar las lecturas
            lista = cen.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            AnyoAcademicoCAD cad = new AnyoAcademicoCAD(session);
            AnyoAcademicoCEN cen = new AnyoAcademicoCEN(cad);

            return cen.ReadCantidad();
        }
    }
}
