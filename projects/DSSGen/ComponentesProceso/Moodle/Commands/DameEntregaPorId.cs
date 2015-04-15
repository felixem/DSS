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
    public class DameEntregaPorId : IDameEntrega
    {
        //Código de Control
        private int cod;

        //Constructor a partir del código de Entrega
        public DameEntregaPorId(int id)
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
        public EntregaEN Execute(ISession sesion)
        {
            EntregaCAD cad = new EntregaCAD(sesion);
            EntregaCEN cen = new EntregaCEN(cad);

            return cen.ReadOID(cod);
        }
    }
}
