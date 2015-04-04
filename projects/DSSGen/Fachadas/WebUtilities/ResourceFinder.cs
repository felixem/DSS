using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Fachadas.WebUtilities
{
    public class ResourceFinder
    {
        private static string pathFotos = "Resources/Fotos/";
        private static string fotoProfesor = "profesor.png";
        private static string fotoAlumno = "alumno.png";
        private static string fotoAdmin = "administrador.png";

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
    }
}
