using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de un Control
    public interface IBinderEvaluacion
    {
        //Realizar vinculación
        void Vincular(EvaluacionEN en);
    }
}
