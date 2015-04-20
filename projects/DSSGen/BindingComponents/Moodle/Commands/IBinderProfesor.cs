using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de un profesor
    public interface IBinderProfesor
    {
        //Realizar vinculación
        void Vincular(ProfesorEN profesor);
    }
}
