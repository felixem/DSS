using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de una lista de grupos de trabajo
    public interface IBinderListaGrupoTrabajo
    {
        //Realizar vinculación
        void Vincular(IList<GrupoTrabajoEN> grupo);
    }
}
