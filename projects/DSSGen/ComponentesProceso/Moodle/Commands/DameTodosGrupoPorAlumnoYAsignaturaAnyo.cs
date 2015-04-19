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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de asignaturas-anyo contenidas
    //a partir de la id del año
    public class DameTodosGrupoPorAlumnoYAsignaturaAnyo : IDameTodosGrupoTrabajo
    {
        //Variables
        private string alumno;
        private int asignaturaanyo;

        //Constructor a partir de una id de año
        public DameTodosGrupoPorAlumnoYAsignaturaAnyo(string alumno, int anyo)
        {
            this.alumno = alumno;
            this.asignaturaanyo = anyo;
        }

        //Propiedades
        public int AsignaturaAnyo
        {
            get { return asignaturaanyo; }
            set { asignaturaanyo = value; }
        }

        public string Alumno
        {
            get { return alumno; }
            set { alumno = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<GrupoTrabajoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<GrupoTrabajoEN> lista = null;

            GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
            GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);

            //Programar las lecturas
            lista = cen.ReadAllPorAlumnoYAsignaturaAnyo( alumno, asignaturaanyo, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
            GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);

            return cen.ReadCantidadPorAlumnoYAsignaturaAnyo(alumno, asignaturaanyo);
        }
    }
}
