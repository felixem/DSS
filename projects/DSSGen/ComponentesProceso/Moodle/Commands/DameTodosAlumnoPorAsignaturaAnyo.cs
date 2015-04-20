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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de alumnos matriculados
    //a partir de la id de una asignatura año
    public class DameTodosAlumnoPorAsignaturaAnyo : IDameTodosAlumno
    {
        //Variables
        private int asignaturaAnyo;

        //Constructor a partir de una id de grupo
        public DameTodosAlumnoPorAsignaturaAnyo(int asig)
        {
            this.asignaturaAnyo = asig;
        }

        //Propiedades
        public int AsignaturaAnyo
        {
            get { return asignaturaAnyo; }
            set { asignaturaAnyo = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<AlumnoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AlumnoEN> lista = null;

            AlumnoCAD cad = new AlumnoCAD(session);
            AlumnoCEN alumno = new AlumnoCEN(cad);

            //Programar las lecturas
            lista = alumno.ReadAllPorAsignaturaAnyo(asignaturaAnyo,first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            AlumnoCAD cad = new AlumnoCAD(session);
            AlumnoCEN alumno = new AlumnoCEN(cad);

            return alumno.ReadCantidadPorAsignaturaAnyo(asignaturaAnyo);
        }
    }
}
