using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BindingComponents.Moodle.Commands
{
    //Interfaz para vincular controles con el contenido de una lista de años académicos
    public interface IBinderListaFecha
    {
        //Realizar vinculación
        void Vincular(ArrayList lista);

        //Realizar vinculación mes
        void VincularMes(ArrayList mes);
    }
}
