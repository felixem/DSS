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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de controles contenidos
    //que pertenecen a una asignatura anyo por su id
    public class DameTodosControlPorAsignaturaAnyo : IDameTodosControl
    {
        //Variables
        private int asignatura_anyo;

        //Constructor a partir de una id de asignatura_anyo
        public DameTodosControlPorAsignaturaAnyo(int asignatura_anyo)
        {
            this.asignatura_anyo = asignatura_anyo;
        }

        //Propiedades
        public int AsignaturaAnyo
        {
            get { return asignatura_anyo; }
            set { asignatura_anyo = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<ControlEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<ControlEN> lista = null;

            ControlCAD cad = new ControlCAD(session);
            ControlCEN en = new ControlCEN(cad);

            //Programar las lecturas
            lista = en.ReadAllPorAsignaturaAnyo(asignatura_anyo, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            ControlCAD cad = new ControlCAD(session);
            ControlCEN grupo = new ControlCEN(cad);

            return grupo.ReadCantidadPorAsignaturaAnyo(asignatura_anyo);
        }
    }
}

