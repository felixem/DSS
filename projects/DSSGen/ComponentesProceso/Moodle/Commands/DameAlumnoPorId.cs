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
    //Clase que representa una operación para obtener un alumno por id
    public class DameAlumnoPorId :IDameAlumno
    {
        //Código de alumno
        private int cod;

        //Constructor a partir del código de alumno
        public DameAlumnoPorId(int id)
        {
            this.cod = id;
        }

        //Propiedades
        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        //Método de consulta
        public AlumnoEN Execute(ISession sesion)
        {
            AlumnoCAD cad = new AlumnoCAD(sesion);
            AlumnoCEN cen = new AlumnoCEN(cad);

            return cen.ReadCod(cod);
        }
    }
}
