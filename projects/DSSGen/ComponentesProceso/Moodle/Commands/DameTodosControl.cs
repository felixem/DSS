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
    public class DameTodosControl : IDameTodosControl
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<ControlEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<ControlEN> lista = null;

            ControlCAD cad = new ControlCAD(session);
            ControlCEN en = new ControlCEN(cad);

            //Programar las lecturas
            lista = en.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            ControlCAD cad = new ControlCAD(session);
            ControlCEN en = new ControlCEN(cad);

            return en.ReadCantidad();
        }
    }
}
