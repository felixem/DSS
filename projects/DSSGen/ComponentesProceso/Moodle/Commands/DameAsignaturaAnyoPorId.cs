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
    //Clase que representa una operación para obtener una asignatura-anyo por id
    public class DameAsignaturaAnyoPorId : IDameAsignaturaAnyo
    {
        //Código de asignatura-anyo
        private int id;

        //Constructor a partir del id
        public DameAsignaturaAnyoPorId(int id)
        {
            this.id = id;
        }

        //Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Método de consulta
        public AsignaturaAnyoEN Execute(ISession sesion)
        {
            AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(sesion);
            AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);

            return cen.ReadOID(id);
        }
    }
}
