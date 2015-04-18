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
    public class DameTodosAsignaturaAnyoPorAlumno : IDameTodosAsignaturaAnyo
    {
        //Variables
        private string alumno;
        private int anyo;

        //Constructor a partir de una id de año
        public DameTodosAsignaturaAnyoPorAlumno(string alumno, int anyo)
        {
            this.alumno = alumno;
            this.anyo = anyo;
        }

        //Propiedades
        public int Anyo
        {
            get { return anyo; }
            set { anyo = value; }
        }

        public string Alumno
        {
            get { return alumno; }
            set { alumno = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<AsignaturaAnyoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AsignaturaAnyoEN> lista = null;

            AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
            AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);

            //Programar las lecturas
            lista = cen.ReadAllPorAlumnoYAnyo(alumno,anyo, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
            AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);

            return cen.ReadCantidadPorAlumnoYAnyo(alumno, anyo);
        }
    }
}
