using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular Evaluaciones con el contenido de una lista de Evaluacion
    public interface IBinderListaEvaluacion
    {
        //Realizar vinculación
        void Vincular(IList<EvaluacionEN> list);
    }
}