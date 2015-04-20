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
    //Clase que representa una operación para obtener un Control por id
    public class DameControlPorId : IDameControl
    {
        //Código de Control
        private int cod;

        //Constructor a partir del código de profesor
        public DameControlPorId(int id)
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
        public ControlEN Execute(ISession sesion)
        {
            ControlCAD cad = new ControlCAD(sesion);
            ControlCEN cen = new ControlCEN(cad);

            return cen.ReadOID(cod);
        }
    }
}
