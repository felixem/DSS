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
        //Variables privadas de navegación
        private bool cacheable;
        private NavigationSession navegacion;

        //Variables estáticas de direcciones
        internal static readonly string modificarBolsa = "/Examen/modificar_bolsa.aspx";
        internal static readonly string modificarControl = "/Control/modificar_control.aspx";
        internal static readonly string modificarPregunta = "/Examen/modificar_pregunta.aspx";
        internal static readonly string modificarAlumno = "/Alumno/modificar_alumno.aspx";
        internal static readonly string modificarProfesor = "/Profesor/modificar_profesor.aspx";
        internal static readonly string modificarAsignatura = "/Asignatura/modificar_asignatura.aspx";

        internal static readonly string modificarGrupoTrabajo = "/GrupoTrabajo/modificar_grupotrabajo.aspx";
        internal static readonly string listarAlumnosGrupoTrabajo = "/GrupoTrabajo/alumnos_grupo_trabajo.aspx";
        internal static readonly string anyadirAlumnosGrupoTrabajo = "/GrupoTrabajo/anyadiralumnos_grupo_trabajo.aspx";
        internal static readonly string listarGruposTrabajoAsignaturaAnyo = "/GrupoTrabajo/grupos_trabajo_asignatura.aspx";
        internal static readonly string listarMisGruposTrabajoAsignatura = "/GrupoTrabajo/mis_grupos_trabajo_asignatura.aspx";
        internal static readonly string crearGrupoTrabajoAsignaturaAnyo = "/GrupoTrabajo/crear_grupotrabajo_asignatura.aspx";
        internal static readonly string listarGruposTrabajoAsignaturaAnyoAlumno = "/GrupoTrabajo/grupos_trabajo_asignatura_alumno.aspx";
        internal static readonly string accesoGrupoTrabajo = "/GrupoTrabajo/acceso_grupotrabajo.aspx";

        internal static readonly string listarMatriculadosAsignaturaAnyo = "/Alumno/alumnos_matriculados.aspx";
        internal static readonly string matricularAlumnoEnAsignaturaAnyo = "/AsignaturaAnyo/matricular_alumno_asignatura.aspx";
        internal static readonly string listarAsignaturasAnyoDeAlumno = "/AsignaturaAnyo/asignaturas_matriculado_alumno.aspx";
        
        internal static readonly string login = "/Account/Login.aspx";
        internal static readonly string pageDefault = "/Default.aspx";

        internal static readonly string listadoBolsaPreguntas = "/Examen/bolsas_preguntas.aspx";
        internal static readonly string crearBolsa = "/Examen/crear_bolsa.aspx";

        internal static readonly string crearControl = "/Control/crear_control.aspx";
        internal static readonly string listarControles = "/Control/controles.aspx";
        internal static readonly string crearControlAsignaturaAnyo = "/Control/crear_control_asignatura.aspx";

        internal static readonly string crearPregunta = "/Examen/crear_pregunta.aspx";

        internal static readonly string alumnos = "/Alumno/alumnos.aspx";
        internal static readonly string crearAlumno = "/Alumno/crear_alumno.aspx";

        internal static readonly string profesores = "/Profesor/profesores.aspx";
        internal static readonly string crearProfesor = "/Profesor/crear_profesor.aspx";

        internal static readonly string asignaturas = "/Asignatura/asignaturas.aspx";
        internal static readonly string crearAsignatura = "/Asignatura/crear_asignatura.aspx";

        internal static readonly string gruposTrabajo = "/GrupoTrabajo/grupos_trabajo.aspx";
        internal static readonly string crearGrupoTrabajo = "/GrupoTrabajo/crear_grupotrabajo.aspx";

        internal static readonly string crearAsignaturaAnyo = "/AsignaturaAnyo/crear_asignaturaanyo.aspx";

        internal static readonly string crearEntrega = "/Entrega/crear_entrega.aspx";
        internal static readonly string listarEntregas = "/Entrega/entregas.aspx";
        internal static readonly string crearEntregaAsignaturaAnyo = "/Entrega/crear_entrega_asignatura.aspx";

        internal static readonly string asignaturasImpartidas = "/AsignaturaAnyo/asignaturas_impartidas.aspx";
        internal static readonly string changePassword = "/Account/ChangePassword.aspx";

        internal static readonly string crearEvaluacion = "/Evaluacion/crear_evaluacion.aspx";
        internal static readonly string modificarEvaluacion = "/Evaluacion/modificar_evaluacion.aspx";
        internal static readonly string listarEvaluaciones = "/Evaluacion/evaluaciones.aspx";

        internal static readonly string misAsignaturasImpartidas = "/AsignaturaAnyo/mis_asignaturas_impartidas.aspx";
        internal static readonly string misAlumnosMatriculadosAsignaturaAnyo = "/Alumno/mis_alumnos_matriculados.aspx";
        internal static readonly string realizarEntregaPracticas = "/EntregaAlumno/realizar_entrega.aspx";

        internal static readonly string listarEntregaAsignaturaAnyo = "/Entrega/entregas_asignatura.aspx";
        internal static readonly string listarControlAsignaturaAnyo = "/Control/controles_asignatura.aspx";

        internal static readonly string calificarEntregaAlumno = "/EntregaAlumno/calificar.aspx";

        internal static readonly string listarSistemaEvaluacion = "/Sistema Evaluacion/sistemas_evaluacion.aspx";
        internal static readonly string crearSistemaEvaluacion = "/Sistema Evaluacion/crear_evaluacion.aspx";
        internal static readonly string modificarSistemaEvaluacion = "/Sistema Evaluacion/modificar_evaluacion.aspx";

        internal static readonly string listarEntregasAlumno = "/EntregaAlumno/entregas_alumnos.aspx";

        internal static readonly string descargarRecurso = "/Download/DownloadFile.ashx";

        internal static readonly string entregasProgramadasAsignaturaAlumno = "/Entrega/entregas_asignatura_vista_alumno.aspx";

        internal static readonly string detallesMiEntregaAlumno = "/EntregaAlumno/detalles_entrega_alumno.aspx";
        

        internal static readonly string error404 = "/Errors/404.aspx";
        internal static readonly string error403 = "/Errors/403.aspx";


        //Constructor para indicar si la página actual debe ser o no cacheada
        public Linker(bool cach)
        {
            cacheable = cach;
        }

        //Manipular el valor de cacheabilidad
        public bool Cacheable
        {
            get { return cacheable; }
            set { cacheable = value; }
        }

        //Crear un parámetro para añadir a una url
        private static string Parameter(string paramName, string paramValue, bool isFirstParameter = true)
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
            //Inicializar variable
            if (navegacion == null)
                navegacion = NavigationSession.Current;

            navegacion.Cacheable = cacheable;
            response.Redirect(url);
        }

        //Cadena para la página anterior a la actual
        public string PreviousPage()
        {
            //Inicializar variable
            if (navegacion == null)
                navegacion = NavigationSession.Current;

            String url = navegacion.PopLastUrl();

            //Llevar a la página por defecto si no hay previa
            if (url == null)
                url = this.Default();

            return url;
        }

        //Cadena para la página de login
        public string Login()
        {
            return login;
        }

        //Cadena para la página por defecto
        public string Default()
        {
            return pageDefault;
        }

        //Cadena para la página de bolsas de preguntas
        public string ListadoBolsaPreguntas()
        {
            return listadoBolsaPreguntas;
        }

        //Cadena para la página de creación de una bolsa de preguntas
        public string CrearBolsa()
        {
            return crearBolsa;
        }

        //Cadena para la página de creación de una entrega
        public string CrearEntrega()
        {
            return crearEntrega;
        }

        //Cadena para la interfaz de acceso a la base de datos
        public string AccesoGrupoTrabajo(int id)
        {
            return accesoGrupoTrabajo + Parameter(PageParameters.MainParameter, id.ToString());
        }

        public string MisGruposTrabajoAsignatura(int id)
        {
            return listarMisGruposTrabajoAsignatura + Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de creación de un control
        public string CrearControl()
        {
            return crearControl;
        }

        //Cadena para la página de modificación de una bolsa de preguntas
        public string ModificarBolsa(int id)
        {
            return modificarBolsa +
                Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de modificación de una bolsa de preguntas
        public string CalificarEntregaAlumno(int id)
        {
            return calificarEntregaAlumno +
                Parameter(PageParameters.MainParameter, id.ToString());
        }        

        //Cadena para la página de modificación de un control
        public string ModificarControl(int id)
        {
            return modificarControl +
                Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de modificación de una entrega
        public string ModificarEntrega(int id)
        {
            return "~/Entrega/modificar_entrega.aspx" +
                Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de los grupos de trabajo de una asignatura de un alumno
        public string ListarGruposTrabajoAsignaturaAnyoAlumno(int cod)
        {
            return listarGruposTrabajoAsignaturaAnyoAlumno + Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de creación de una pregunta
        public string CrearPregunta()
        {
            return crearPregunta;
        }

        //Cadena para la página de modificación de una pregunta
        public string ModificarPregunta(int id)
        {
            return modificarPregunta
            + Parameter(PageParameters.MainParameter, id.ToString());
        }

        //Cadena para la página de gestión de alumnos
        public string Alumnos()
        {
            return alumnos;
        }

        //Cadena para la página de creación de alumno
        public string CrearAlumno()
        {
            return crearAlumno;
        }

        //Cadena para la página de gestión de profesores
        public string Profesores()
        {
            return profesores;
        }

        //Cadena para la página de modificación de alumno
        public string ModificarAlumno(int cod)
        {
            return modificarAlumno +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de creación de profesor
        public string CrearProfesor()
        {
            return crearProfesor;
        }

        //Cadena para la página de modificación de profesor
        public string ModificarProfesor(int cod)
        {
            return modificarProfesor +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de gestión de asignaturas
        public string Asignaturas()
        {
            return asignaturas;
        }

        //Cadena para la página de creación de asignatura
        public string CrearAsignatura()
        {
            return crearAsignatura;
        }

        //Cadena para la página de modificación de asignatura
        public string ModificarAsignatura(int cod)
        {
            return modificarAsignatura +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de creación de grupo de trabajo
        public string GruposTrabajo()
        {
            return gruposTrabajo;
        }

        //Cadena para la página de creación de grupo de trabajo
        public string CrearGrupoTrabajo()
        {
            return crearGrupoTrabajo;
        }

        //Cadena para la página de modificación de grupo de trabajo
        public string ModificarGrupoTrabajo(int cod)
        {
            return modificarGrupoTrabajo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para listar alumnos de un grupo de trabajo
        public string ListarAlumnosGrupoTrabajo(int cod)
        {
            return listarAlumnosGrupoTrabajo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para listar las entregas programadas de una asignatura
        public string EntregasProgramadasAsignaturaVistaAlumno(int cod)
        {
            return entregasProgramadasAsignaturaAlumno +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de creación de grupo de trabajo
        public string ListarAsignaturasAnyoDeAlumno()
        {
            return listarAsignaturasAnyoDeAlumno;
        }

        //Cadena para la página para añadir a un alumno a un grupo de trabajo
        public string AnyadirAlumnosGrupoTrabajo(int cod)
        {
            return anyadirAlumnosGrupoTrabajo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para vincular una asignatura con un año
        public string CrearAsignaturaAnyo()
        {
            return crearAsignaturaAnyo;
        }

        //Cadena para la página cambiar contraseña
        public string  ChangePassword(){
            return changePassword;
        }

        //Cadena para la página para listar los controles de una asignatura-anyo
        public string ListarControlAsignaturaAnyo(int cod)
        {
            return listarControlAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para listar las entregas de una asignatura-anyo
        public string ListarEntregaAsignaturaAnyo(int cod)
        {
            return listarEntregaAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para listar los grupos de trabajo de una asignatura-anyo
        public string ListarGruposTrabajoAsignaturaAnyo(int cod)
        {
            return listarGruposTrabajoAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para crear un grupo de trabajo para una asignatura-anyo
        public string CrearGrupoTrabajoAsignaturaAnyo(int cod)
        {
            return crearGrupoTrabajoAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para crear una entrega para una asignatura-anyo
        public string CrearEntregaAsignaturaAnyo(int cod)
        {
            return crearEntregaAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para crear un control para una asignatura-anyo
        public string CrearControlAsignaturaAnyo(int cod)
        {
            return crearControlAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para listar los alumnos matriculados en una asignatura
        public string ListarMatriculadosAsignaturaAnyo(int cod)
        {
            return listarMatriculadosAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para listar la lista de evaluacion
        public string ListarEvaluaciones()
        {
            return listarEvaluaciones;
        }

        //Cadena para la ruta para listar los controles
        public string ListarControles()
        {
            return listarControles;
        }

        //Cadena para la ruta para listar las entregas
        public string ListarEntregas()
        {
            return listarEntregas;
        }

        //Cadena para la página para matricular alumnos en una asignatura
        public string MatricularAlumnoEnAsignaturaAnyo(int cod)
        {
            return matricularAlumnoEnAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de asignaturas-anyo impartidas
        public string AsignaturasImpartidas()
        {
            return asignaturasImpartidas;
        }

        public String CrearEvaluacion() {
            return crearEvaluacion;
        }
        public String ModificarEvaluacion(int cod)
        {
            return modificarEvaluacion + Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de las asignaturas-anyo impartidas por el profesor
        public string MisAsignaturasImpartidas()
        {
            return misAsignaturasImpartidas;
        }

        //Cadena para la página de los alumnos matriculados en una asignatura-anyo impartida por un profesor
        public string MisAlumnosMatriculadosAsignaturaAnyo(int cod)
        {
            return misAlumnosMatriculadosAsignaturaAnyo +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página para realizar entrega de prácticas sobre una entrega propuesta
        public string RealizarEntregaPracticas(int cod)
        {
            return realizarEntregaPracticas +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Listar Entregas de Alumnos
        public string ListarEntregasAlumno(int cod)
        {
            return listarEntregasAlumno +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Ver detalles de una entrega del alumno (vista desde el alumno)
        public string DetallesMiEntregaAlumno(int cod)
        {
            return detallesMiEntregaAlumno +
                Parameter(PageParameters.MainParameter, cod.ToString());
        }

        //Cadena para la página de error 403
        public string Error403()
        {
            return error403;
        }

        //Cadena para la página de error 404
        public string Error404()
        {
            return error404;
        }

        //Cadena para el controlador de descarga de entregas de prácticas
        public string DescargaEntregaPracticas(int cod)
        {
            return descargarRecurso +
                Parameter(PageParameters.DescargaEntregaAlumno, cod.ToString());
        }

    }
        
}