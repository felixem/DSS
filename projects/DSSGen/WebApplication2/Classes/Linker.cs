using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Classes
{
    //Clase utilizada para generar cadenas de url para redirección
    public class Linker
    {
        //Cadena para la página de login
        public static string Login()
        {
            return "~/Account/Login.aspx";
        }

        //Cadena para la página por defecto
        public static string Default()
        {
            return "~/Default.aspx";
        }

        //Cadena para la página de bolsas de preguntas
        public static string BolsaPreguntas()
        {
            return "~/Examen/bolsas_preguntas.aspx";
        }
    }
}