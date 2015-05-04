using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;
using WebUtilities;

namespace Fachadas.Moodle
{
    public class FachadaAlumno
    {
        //Metodo que registra al alumno en BD
        public bool RegistrarAlumno(string nombre, string apellidos, string pass, DateTime fecha, string dni, string email, int cod,
            string codExpediente, bool expedienteAbierto)
        {
            try
            {
                AlumnoCP alumno = new AlumnoCP();
                alumno.CrearAlumno(nombre, apellidos, pass, fecha, dni, email, cod, codExpediente, expedienteAbierto);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El alumno no pudo ser creado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El alumno ha sido creado");
            return true;
        }

        //Método para modificar un alumno en la BD sin modificar su password
        public bool ModificarAlumnoNoPassword(string email, int codAlumno, bool baneado, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                AlumnoCP cp = new AlumnoCP();
                cp.ModificarAlumnoNoPassword(email, codAlumno, baneado, dni, nombre, apellidos, fechaNacimiento);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un alumno en la BD
        public bool BorrarAlumno(int codAlumno)
        {
            try
            {
                AlumnoCP cp = new AlumnoCP();
                cp.BorrarAlumno(codAlumno);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Vincular a un grid view los alumnos con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumno();
            BinderListaAlumnoGrid binder = new BinderListaAlumnoGrid(grid);

            alumnoBind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Vincular a un gridview los alumnos matriculados en una asignatura con paginación
        public void VincularDameTodosPorAsignaturaAnyo(int idAsigAnyo, GridView grid, int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumnoPorAsignaturaAnyo(idAsigAnyo);
            BinderListaAlumnoGrid binder = new BinderListaAlumnoGrid(grid);

            alumnoBind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Vincular a un gridview los alumnos pertenecientes a un grupo de trabajo con paginación
        public void VincularDameTodosPorGrupo(int idGrupo, GridView grid, int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumnoPorGrupo(idGrupo);
            BinderListaAlumnoGrid binder = new BinderListaAlumnoGrid(grid);

            alumnoBind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Vincular a un gridview los alumnos pertenecientes que podrían ingresar dentro de un grupo con paginación
        public void VincularDameTodosIngresablesEnGrupo(int idGrupo, GridView grid, int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumnoIngresablesEnGrupo(idGrupo);
            BinderListaAlumnoGrid binder = new BinderListaAlumnoGrid(grid);

            alumnoBind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Vincular a un gridview los alumnos que podrían matricularse en una asignatura con paginación
        public void VincularDameTodosMatriculablesEnAsignaturaAnyo(int idAsig, GridView grid, int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            AlumnoBinding alumnoBind = new AlumnoBinding();
            IDameTodosAlumno consulta = new DameTodosAlumnoMatriculablesEnAsignaturaAnyo(idAsig);
            BinderListaAlumnoGrid binder = new BinderListaAlumnoGrid(grid);

            alumnoBind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Método para vincular un alumno a partir de su id a textboxes
        public bool VincularAlumnoPorId(int id, TextBox TextBox_NomAlu,
            TextBox TextBox_ApellAlu, TextBox TextBox_NaciAlu, TextBox TextBox_DNIAlu,
            TextBox TextBox_EmailAlu, TextBox TextBox_CodAlu, CheckBox CheckBox_Baneado,
            TextBox TextBox_CodExpediente)
        {
            try
            {
                AlumnoBinding binding = new AlumnoBinding();
                DameAlumnoPorId consulta = new DameAlumnoPorId(id);
                BinderAlumnoCompleto linker = new BinderAlumnoCompleto(TextBox_NomAlu,
                TextBox_ApellAlu, TextBox_NaciAlu, TextBox_DNIAlu, TextBox_EmailAlu,
                TextBox_CodAlu, CheckBox_Baneado, TextBox_CodExpediente);

                binding.VincularDameAlumno(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

    }
}
