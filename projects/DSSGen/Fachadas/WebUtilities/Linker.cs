using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fachadas.WebUtilities
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
        public static string ListadoBolsaPreguntas()
        {
            return "~/Examen/bolsas_preguntas.aspx";
        }

        //Cadena para la página de creación de una bolsa de preguntas
        public static string CrearBolsa()
        {
            return "~/Examen/crear_bolsa.aspx";
        }

        //Cadena para la página de creación de una pregunta
        public static string CrearPregunta()
        {
            return "~/Examen/crear_pregunta.aspx";
        }

        //Cadena para la página de modificación de una pregunta
        public static string ModificarPregunta(int id)
        {
            return CrearPregunta() + "?id=" + id;
        }
    }
}