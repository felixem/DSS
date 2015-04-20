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
    //a partir de la id del año y email el profesor que las imparte
    public class DameTodosAsignaturaAnyoPorAnyoYProfesor : IDameTodosAsignaturaAnyo
    {
        //Variables
        private int anyo;
        private string profesor;

        //Constructor a partir de una id de año y de profesor
        public DameTodosAsignaturaAnyoPorAnyoYProfesor(int anyo, string profesor)
        {
            this.anyo = anyo;
            this.profesor = profesor;
        }

        //Propiedades
        public int Anyo
        {
            get { return anyo; }
            set { anyo = value; }
        }

        public string Profesor
        {
            get { return profesor; }
            set { profesor = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<AsignaturaAnyoEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AsignaturaAnyoEN> lista = null;

            AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
            AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);

            //Programar las lecturas
            lista = cen.ReadAllPorAnyoYProfesor(anyo, profesor, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
            AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);

            return cen.ReadCantidadPorAnyoYProfesor(anyo, profesor);
        }
    }
}
