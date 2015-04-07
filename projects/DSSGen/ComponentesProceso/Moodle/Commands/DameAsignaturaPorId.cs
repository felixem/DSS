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
    //Clase que representa una operación para obtener una asignatura por id
    public class DameAsignaturaPorId :IDameAsignatura
    {
        //Código de alumno
        private int id;

        //Constructor a partir del id de asignatura
        public DameAsignaturaPorId(int id)
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
        public AsignaturaEN Execute(ISession sesion)
        {
            AsignaturaCAD cad = new AsignaturaCAD(sesion);
            AsignaturaCEN cen = new AsignaturaCEN(cad);

            return cen.ReadOID(id);
        }
    }
}
