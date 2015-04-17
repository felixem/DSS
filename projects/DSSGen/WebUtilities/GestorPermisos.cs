using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web;

namespace WebUtilities
{
    //Gestor de permisos de acceso para las páginas
    public partial class GestorPermisos
    {
        //Hashmap de permisos
        private Dictionary<string, Permiso> permisos;

        //Constructor privado para inicializar los permisos
        private GestorPermisos()
        {
            //Creación de los permisos
            Permiso permisoDefault = new Permiso(false);
            Permiso permisoSoloProfesor = new Permiso(true, typeof(ProfesorEN));
            Permiso permisoSoloAdmin = new Permiso(true, typeof(AdministradorEN));
            Permiso permisoSoloAlumno = new Permiso(true, typeof(AlumnoEN));

            //Creación del hashmap
            permisos = new Dictionary<string, Permiso>();

            //Añadir la lista de permisos
            permisos.Add(Linker.crearAlumno, permisoSoloAdmin);
        }

        //Constructor Singleton
        public static GestorPermisos Create
        {
            get
            {
                GestorPermisos gestor =
                  (GestorPermisos)HttpContext.Current.Session["__GestorPermisos__"];
                if (gestor == null)
                {
                    gestor = new GestorPermisos();
                    HttpContext.Current.Session["__GestorPermisos__"] = gestor;
                }
                return gestor;
            }
        }

        //Comprobar permisos de una url
        public void ComprobarPermisos(HttpResponse Response, HttpRequest Request, MySession sesion)
        {
            //Obtener la url de la página sin parámetros
            string reqURL = Request.Path;

            //Por defecto, el permiso es abierto para todos
            if (!permisos.ContainsKey(reqURL))
                return;

            //Comprobar permiso
            Permiso perm = permisos[reqURL];
            if (!perm.ComprobarPermisos(sesion))
            {
                Linker linker = new Linker(false);
                linker.Redirect(Response, linker.PreviousPage());
            }
        }
    }
}
