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
            Permiso permisoTodosUsuarios = new Permiso(true, typeof(UsuarioEN));
            Permiso permisoSoloProfesor = new Permiso(true, typeof(ProfesorEN));
            Permiso permisoSoloAdmin = new Permiso(true, typeof(AdministradorEN));
            Permiso permisoSoloAlumno = new Permiso(true, typeof(AlumnoEN));
            Permiso permisoAdminProfesor = new Permiso(true, typeof(AdministradorEN), typeof(ProfesorEN));

            //Creación del hashmap
            permisos = new Dictionary<string, Permiso>();

            //AÑADIR LISTA DE PERMISOS

            //Permisos POR DEFECTO
            permisos.Add(Linker.login, permisoDefault);
            permisos.Add(Linker.pageDefault, permisoDefault);

            //Permisos para TODOS LOS USUARIOS LOGUEADOS
            permisos.Add(Linker.passChanged, permisoTodosUsuarios);
            permisos.Add(Linker.changePassword, permisoTodosUsuarios);

            //Permisos de ADMINISTRADOR
            //Páginas de modificación
            permisos.Add(Linker.modificarBolsa, permisoSoloAdmin);
            permisos.Add(Linker.modificarPregunta, permisoSoloAdmin);
            permisos.Add(Linker.modificarAlumno, permisoSoloAdmin);
            permisos.Add(Linker.modificarProfesor, permisoSoloAdmin);
            permisos.Add(Linker.modificarAsignatura, permisoSoloAdmin);
            permisos.Add(Linker.modificarGrupoTrabajo, permisoSoloAdmin);
            permisos.Add(Linker.modificarControl, permisoSoloAdmin);
            //Páginas de creación
            permisos.Add(Linker.crearGrupoTrabajoAsignaturaAnyo, permisoSoloAdmin);
            permisos.Add(Linker.matricularAlumnoEnAsignaturaAnyo, permisoSoloAdmin);
            permisos.Add(Linker.crearBolsa, permisoSoloAdmin);
            permisos.Add(Linker.crearControl, permisoSoloAdmin);
            permisos.Add(Linker.crearPregunta, permisoSoloAdmin);
            permisos.Add(Linker.crearAlumno, permisoSoloAdmin);
            permisos.Add(Linker.crearProfesor, permisoSoloAdmin);
            permisos.Add(Linker.crearAsignatura, permisoSoloAdmin);
            permisos.Add(Linker.crearGrupoTrabajo, permisoSoloAdmin);
            permisos.Add(Linker.crearAsignaturaAnyo, permisoSoloAdmin);
            permisos.Add(Linker.crearEntrega, permisoSoloAdmin);
            //Páginas de listado
            permisos.Add(Linker.listarAlumnosGrupoTrabajo, permisoSoloAdmin);
            permisos.Add(Linker.anyadirAlumnosGrupoTrabajo, permisoSoloAdmin);
            permisos.Add(Linker.listarGruposTrabajoAsignaturaAnyo, permisoSoloAdmin);
            permisos.Add(Linker.listarMatriculadosAsignaturaAnyo, permisoSoloAdmin);
            permisos.Add(Linker.listadoBolsaPreguntas, permisoSoloAdmin);
            permisos.Add(Linker.alumnos, permisoSoloAdmin);
            permisos.Add(Linker.profesores, permisoSoloAdmin);
            permisos.Add(Linker.asignaturas, permisoSoloAdmin);
            permisos.Add(Linker.gruposTrabajo, permisoSoloAdmin);
            permisos.Add(Linker.asignaturasImpartidas, permisoSoloAdmin);
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
