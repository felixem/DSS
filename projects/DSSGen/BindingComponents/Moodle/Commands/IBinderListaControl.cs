using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de una lista de Control
    public interface IBinderListaControl
    {
        //Realizar vinculación
        void Vincular(IList<ControlEN> list);
    }
}
