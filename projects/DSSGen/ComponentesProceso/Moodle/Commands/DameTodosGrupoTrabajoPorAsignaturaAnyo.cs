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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de grupos de trabajo contenidos
    //que pertenecen a una asignatura anyo por su id
    public class DameTodosGrupoTrabajoPorAsignaturaAnyo : IDameTodosGrupoTrabajo
    {
        //Variables
        private int asignatura_anyo;

        //Constructor a partir de una id de asignatura_anyo
        public DameTodosGrupoTrabajoPorAsignaturaAnyo(int asignatura_anyo)
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
        public System.Collections.Generic.IList<GrupoTrabajoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<GrupoTrabajoEN> lista = null;

            GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
            GrupoTrabajoCEN grupo = new GrupoTrabajoCEN(cad);

            //Programar las lecturas
            lista = grupo.ReadAllPorAsignaturaAnyo(asignatura_anyo,first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
            GrupoTrabajoCEN grupo = new GrupoTrabajoCEN(cad);

            return grupo.ReadCantidadPorAsignaturaAnyo(asignatura_anyo);
        }
    }
}
