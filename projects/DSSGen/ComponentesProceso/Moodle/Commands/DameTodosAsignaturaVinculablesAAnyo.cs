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
    //Devolver una consulta paginada de dameTodos junto con la cantidad total de asignaturas contenidas
    // que pueden ser vinculadas a un año académico
    public class DameTodosAsignaturaVinculablesAAnyo : IDameTodosAsignatura
    {
        //Variables
        private int anyo;

        //Constructor a partir de la id del año
        public DameTodosAsignaturaVinculablesAAnyo(int id_anyo)
        {
            anyo = id_anyo;
        }

        //Propiedades
        public int Anyo
        {
            get { return anyo; }
            set { anyo = value; }
        }

        //Ejecutar el método
        public System.Collections.Generic.IList<AsignaturaEN> Execute(ISession session, int first, int size)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;

            AsignaturaCAD cad = new AsignaturaCAD(session);
            AsignaturaCEN asignatura = new AsignaturaCEN(cad);

            //Programar las lecturas
            lista = asignatura.ReadAllVinculablesAAnyo(anyo,first, size);

            //Devolver lista
            return lista;
        }

        //Total de objetos afectados por la consulta
        public long Total(ISession session)
        {
            AsignaturaCAD cad = new AsignaturaCAD(session);
            AsignaturaCEN asignatura = new AsignaturaCEN(cad);

            return asignatura.ReadCantidadVinculablesAAnyo(anyo);
        }
    }
}
