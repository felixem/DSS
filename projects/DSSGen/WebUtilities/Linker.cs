using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebUtilities
{
    //Clase utilizada para generar cadenas de url para redirección
    public class Linker
    {
        private bool cacheable;
        NavigationSession navegacion;

        //Constructor para indicar si la página actual debe ser o no cacheada
        public Linker(bool cach)
        {
            cacheable = cach;
            navegacion = NavigationSession.Current;
        }

        //Manipular el valor de cacheabilidad
        public bool Cacheable
        {
            get { return cacheable; }
            set { cacheable = value; }
        }

        //Crear un parámetro para añadir a una url
        private string Parameter(string paramName, string paramValue, bool isFirstParameter = true)
        {
            string cadena = "";
            //Añadir el comienzo correspondiente en caso de ser o no el primer parámetro
            if (isFirstParameter)
                cadena = "?";
            else
                cadena = "&";

            //Construir la cadena
            cadena += paramName + "=" + paramValue;
            return cadena;
        }

        //Método utilizado para redirigir hacia una dirección
        public void Redirect(HttpResponse response, String url)
        {
            navegacion.Cacheable = cacheable;
            response.Redirect(url);
        }

        //Cadena para la página anterior a la actual
        public string PreviousPage()
        {
            String url = navegacion.PopLastUrl();

            //Llevar a la página por defecto si no hay previa
            if (url == null)
                url = this.Default();

            return url;
        }

        //Cadena para la página de login
        public string Login()
        {
            return "~/Account/Login.aspx";
        }

        //Cadena para la página por defecto
        public string Default()
        {
            return "~/Default.aspx";
        }

        //Cadena para la página de bolsas de preguntas
        public string ListadoBolsaPreguntas()
        {
            return "~/Examen/bolsas_preguntas.aspx";
        }

        //Cadena para la página de creación de una bolsa de preguntas
        public string CrearBolsa()
        {
            return "~/Examen/crear_bolsa.aspx";
        }

        //Cadena para la página de modificación de una bolsa de preguntas
        public string ModificarBolsa(int id)
        {
            return "~/Examen/modificar_bolsa.aspx" +
                Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de creación de una pregunta
        public string CrearPregunta()
        {
            return "~/Examen/crear_pregunta.aspx";
        }

        //Cadena para la página de modificación de una pregunta
        public string ModificarPregunta(int id)
        {
            return "~/Examen/modificar_pregunta.aspx"
            + Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de creación de alumno
        public string CrearAlumno()
        {
            return "~/Alumno/crear_alumno.aspx";
        }

        //Cadena para la página de modificación de alumno
        public String ModificarAlumno(int cod)
        {
            return "~/Alumno/modificar_alumno.aspx" +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de creación de asignatura
        public String CrearAsignatura()
        {
            return "~/Asignatura/crear_asignatura.aspx";
        }

        //Cadena para la página de modificación de asignatura
        public String ModificarAsignatura(int cod)
        {
            return "~/Asignatura/modificar_asignatura.aspx" +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }
    }
}