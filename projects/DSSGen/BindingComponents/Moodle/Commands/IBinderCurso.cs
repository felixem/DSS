using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de un curso
    public interface IBinderCurso
    {
        //Realizar vinculación
        void Vincular(CursoEN curso);
    }
}
