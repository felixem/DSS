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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de Profesor-asignaturaanyo contenidas
    //a partir de la id del asignaturaanyo
    public class DameTodosProfesorPorAsignaturaAnyo : IDameTodosProfesor
    {
        //Variables
        private int asignaturaanyo;

        //Constructor a partir de una id de asignaturaanyo
        public DameTodosProfesorPorAsignaturaAnyo(int asignaturaanyo)
        {
            this.asignaturaanyo = asignaturaanyo;
        }

        //Propiedades
        public int AsignaturaAnyo
        {
            get { return asignaturaanyo; }
            set { asignaturaanyo = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<ProfesorEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<ProfesorEN> lista = null;

            ProfesorCAD cad = new ProfesorCAD(session);
            ProfesorCEN cen = new ProfesorCEN(cad);

            //Programar las lecturas
            lista = cen.ReadAllPorAsignaturaAnyo(asignaturaanyo, first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            ProfesorCAD cad = new ProfesorCAD(session);
            ProfesorCEN cen = new ProfesorCEN(cad);

            return cen.ReadCantidadPorAsignaturaAnyo(asignaturaanyo);
        }
    }
}