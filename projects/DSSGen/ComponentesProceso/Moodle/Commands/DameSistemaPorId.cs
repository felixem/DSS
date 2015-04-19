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
    public class DameSistemaPorId : IDameSistemaEvaluacion
    {
        //Código de Control
        private int cod;

        //Constructor a partir del código de profesor
        public DameSistemaPorId(int id)
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
        public SistemaEvaluacionEN Execute(ISession sesion)
        {
            SistemaEvaluacionCAD cad = new SistemaEvaluacionCAD(sesion);
            SistemaEvaluacionCEN cen = new SistemaEvaluacionCEN(cad);

            return cen.ReadOID(cod);
        }
    }
}
