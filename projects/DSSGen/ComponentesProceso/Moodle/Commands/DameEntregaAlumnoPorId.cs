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
    //Clase que representa una operación para obtener un Entrega por id
    public class DameEntregaAlumnoPorId : IDameEntregaAlumno
    {
        //Código de Control
        private int cod;

        //Constructor a partir del código de Entrega
        public DameEntregaAlumnoPorId(int id)
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
        public EntregaAlumnoEN Execute(ISession sesion)
        {
            EntregaAlumnoCAD cad = new EntregaAlumnoCAD(sesion);
            EntregaAlumnoCEN cen = new EntregaAlumnoCEN(cad);

            return cen.ReadOID(cod);
        }
    }
}

