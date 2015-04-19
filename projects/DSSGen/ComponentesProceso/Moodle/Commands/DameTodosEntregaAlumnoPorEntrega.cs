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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de entregas contenidos
    //que pertenecen a una asignatura anyo por su id
    public class DameTodosEntregaAlumnoPorEntrega : IDameTodosEntregaAlumno
    {
        //Variables
        private int entrega;

        //Constructor a partir de una id de entrega
        public DameTodosEntregaAlumnoPorEntrega(int entrega)
        {
            this.entrega = entrega;
        }

        //Propiedades
        public int Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<EntregaAlumnoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<EntregaAlumnoEN> lista = null;

            EntregaAlumnoCAD cad = new EntregaAlumnoCAD(session);
            EntregaAlumnoCEN en = new EntregaAlumnoCEN(cad);

            //Programar las lecturas
            lista = en.ReadAllPorEntrega(entrega, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            EntregaAlumnoCAD cad = new EntregaAlumnoCAD(session);
            EntregaAlumnoCEN en = new EntregaAlumnoCEN(cad);

            return en.ReadCantidadPorEntrega(entrega);
        }
    }
}

