using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BibliotecaAuxiliar.excepciones
{
    class ExcepcionLoginIncorrecto : Exception
    {
        public ExcepcionLoginIncorrecto() : base("Hubo un error al iniciar sesión")
        {
        }
    }
}
