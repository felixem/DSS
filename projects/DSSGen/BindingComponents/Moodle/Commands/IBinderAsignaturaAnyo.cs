﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de una asignatura anyo
    public interface IBinderAsignaturaAnyo
    {
        //Realizar vinculación
        void Vincular(AsignaturaAnyoEN asignaturaanyo);
    }
}
