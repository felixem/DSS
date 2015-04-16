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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de alumnos contenidos
    //que podrían matricularse en una asignatura-anyo a partir de la id de la asignatura
    public class DameTodosAlumnoMatriculablesEnAsignaturaAnyo : IDameTodosAlumno
    {
        //Variables
        private int asignatura_anyo;

        //Constructor a partir de una id de grupo
        public DameTodosAlumnoMatriculablesEnAsignaturaAnyo(int asig)
        {
            this.asignatura_anyo = asig;
        }

        //Propiedades
        public int AsignaturaAnyo
        {
            get { return asignatura_anyo; }
            set { asignatura_anyo = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<AlumnoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AlumnoEN> lista = null;

            AlumnoCAD cad = new AlumnoCAD(session);
            AlumnoCEN alumno = new AlumnoCEN(cad);

            //Programar las lecturas
            lista = alumno.ReadAllMatriculablesEnAsignaturaAnyo(asignatura_anyo,first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            AlumnoCAD cad = new AlumnoCAD(session);
            AlumnoCEN alumno = new AlumnoCEN(cad);

            return alumno.ReadCantidadMatriculablesEnAsignaturaAnyo(asignatura_anyo);
        }
    }
}
