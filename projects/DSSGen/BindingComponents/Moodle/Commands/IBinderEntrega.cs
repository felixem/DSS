﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de un Entrega
    public interface IBinderEntrega
    {
        //Realizar vinculación
        void Vincular(EntregaEN en);
    }
}
