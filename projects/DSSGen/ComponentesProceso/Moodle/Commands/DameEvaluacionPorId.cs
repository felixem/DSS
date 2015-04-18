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
    //Clase que representa una operación para obtener una evaluacion por id
    public class DameEvaluacionPorId : IDameEvaluacion
    {
        //Código de Control
        private int cod;

        //Constructor a partir del código de evaluacion
        public DameEvaluacionPorId(int id)
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
        public EvaluacionEN Execute(ISession sesion)
        {
            EvaluacionCAD cad = new EvaluacionCAD(sesion);
            EvaluacionCEN cen = new EvaluacionCEN(cad);

            return cen.ReadOID(cod);
        }
    }
}
