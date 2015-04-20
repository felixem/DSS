using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fachadas.Excepciones
{
    class ExcepcionAccesoDatos : Exception
    {
        public ExcepcionAccesoDatos() : base("Hubo un problema en el acceso a datos")
        {
        }
    }
}
