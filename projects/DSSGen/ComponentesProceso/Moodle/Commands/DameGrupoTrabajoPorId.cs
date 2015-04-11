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
    //Clase que representa una operación para obtener un grupo de trabajo por id
    public class DameGrupoTrabajoPorId : IDameGrupoTrabajo
    {
        //Código de grupo
        private int id;

        //Constructor a partir del id del grupo de trabajo
        public DameGrupoTrabajoPorId(int id)
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
        public GrupoTrabajoEN Execute(ISession sesion)
        {
            GrupoTrabajoCAD cad = new GrupoTrabajoCAD(sesion);
            GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);
            GrupoTrabajoEN grupo = cen.ReadOID(id);

            return grupo;
        }
    }
}
