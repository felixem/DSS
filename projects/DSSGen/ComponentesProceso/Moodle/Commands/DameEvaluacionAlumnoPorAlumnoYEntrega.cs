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
    //Clase que representa una operación para obtener una EvaluacionAlumno a partir de un alumno y una entrega propuesta
    public class DameEvaluacionAlumnoPorAlumnoYEntrega : IDameEvaluacionAlumno
    {
        //Id de alumno
        private string alumno;
        //Id de control
        private int entrega;

        //Constructor a partir del código de Entrega
        public DameEvaluacionAlumnoPorAlumnoYEntrega(string alumno, int entrega)
        {
            this.alumno = alumno;
            this.entrega = entrega;
        }

        //Propiedades
        public string Alumno
        {
            get { return alumno; }
            set { alumno = value; }
        }

        public int Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        //Método de consulta
        public EvaluacionAlumnoEN Execute(ISession sesion)
        {
            EvaluacionAlumnoCAD cad = new EvaluacionAlumnoCAD(sesion);
            EvaluacionAlumnoCEN cen = new EvaluacionAlumnoCEN(cad);

            return cen.ReadPorAlumnoYEntrega(alumno,entrega);
        }
    }
}
