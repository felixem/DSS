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
    //Clase que representa una operación para obtener un curso por id
    public class DameCursoPorId :IDameCurso
    {
        //Código de curso
        private int id;

        //Constructor a partir del id de curso
        public DameCursoPorId(int id)
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
        public CursoEN Execute(ISession sesion)
        {
            CursoCAD cad = new CursoCAD(sesion);
            CursoCEN cen = new CursoCEN(cad);

            return cen.ReadOID(id);
        }
    }
}
