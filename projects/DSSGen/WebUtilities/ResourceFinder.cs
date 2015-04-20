using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebUtilities
{
    public class ResourceFinder
    {
        private static string pathFotos = "/Resources/Fotos/";
        private static string pathIconos = "/Resources/Iconos/";

        private static string fotoProfesor = "profesor.png";
        private static string fotoAlumno = "alumno.png";
        private static string fotoAdmin = "administrador.jpg";

        private static string checked_true = "checked.png";
        private static string checked_false = "unchecked.gif";

        private static string dirEntregas = "/App_Data/Entregas/";

        //Obtener el icono de checkado
        public static string CheckImg(bool chequeado)
        {
            if (chequeado == true)
                return pathIconos + checked_true;
            else
                return pathIconos + checked_false;
        }

        //Buscar la foto correspondiente a una sesión
        public static string FotoSession(MySession sesion)
        {
            string relativePath = "";

            //Comprobar el tipo de sesión
            if(sesion.IsAdministrador())
                relativePath=fotoAdmin;
            else if (sesion.IsAlumno())
                relativePath=fotoAlumno;
            else if (sesion.IsProfesor())
                relativePath=fotoProfesor;
            else
                throw new Exception("Recurso no encontrado");

            return pathFotos + relativePath;
        }

        //Directorio de entregas de prácticas
        public static string DirectorioEntregas()
        {
            return dirEntregas;
        }
    }
}
