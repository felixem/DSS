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
    //Clase que representa una operación para obtener un año académico por id
    public class DameAnyoAcademicoPorId : IDameAnyoAcademico
    {
        //Código de año académico
        private int id;

        //Constructor a partir del id del año
        public DameAnyoAcademicoPorId(int id)
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
        public AnyoAcademicoEN Execute(ISession sesion)
        {
            AnyoAcademicoCAD cad = new AnyoAcademicoCAD(sesion);
            AnyoAcademicoCEN cen = new AnyoAcademicoCEN(cad);

            return cen.ReadOID(id);
        }
    }
}
