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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de Entrega contenidos
    public class DameTodosEntrega : IDameTodosEntrega
    {
        //Ejecutar el método
        public System.Collections.Generic.IList<EntregaEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<EntregaEN> lista = null;

            EntregaCAD cad = new EntregaCAD(session);
            EntregaCEN en = new EntregaCEN(cad);

            //Programar las lecturas
            lista = en.ReadAll(first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            EntregaCAD cad = new EntregaCAD(session);
            EntregaCEN en = new EntregaCEN(cad);

            return en.ReadCantidad();
        }
    }
}
