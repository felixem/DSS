using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebUtilities
{
    public class PageParameters
    {
        //Parámetro principal en las modificaciones
        private static string mainParameter = "id";
        //Parámetro para indicar que la página anterior no debe ser considerada como previa
        private static string noCacheParameter = "no_cache";
        //Valor que tiene el parámetro no caché para indicar que no debe ser considerada la página previa
        private static string noCacheValue = "true";
        //Parámetro para indicar una entregaalumno en una petición de descarga
        private static string descargaEntregaAlumno = "entrega";

        public static string MainParameter
        {
            get { return mainParameter; }
        }

        public static string NoCacheParameter
        {
            get { return noCacheParameter; }
        }

        public static string NoCacheValue
        {
            get { return noCacheValue; }
        }

        public static string DescargaEntregaAlumno
        {
            get { return descargaEntregaAlumno; }
        }
    }
}
