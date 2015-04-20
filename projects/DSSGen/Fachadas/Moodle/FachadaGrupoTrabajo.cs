using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using BindingComponents.Moodle.Commands;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    public class FachadaGrupoTrabajo
    {
        //Vincular a un GridView todas los grupos de trabajo
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            GrupoTrabajoBinding grupo = new GrupoTrabajoBinding();
            DameTodosGrupoTrabajo consulta = new DameTodosGrupoTrabajo();
            BinderListaGrupoTrabajoGrid binder = new BinderListaGrupoTrabajoGrid(grid);

            grupo.VincularDameTodos(consulta, binder, first, size, out numElements);
        }

        //Vincular a un gridview los grupos de trabajo pertenecientes a una asignatura-anyo con paginación
        public void VincularDameTodosPorAsignaturaAnyo(int idAsignaturaAnyo, GridView grid, 
            int first, int size, out long numAlumnos)
        {
            //Obtener alumnos y enlazar sus datos con el gridview
            GrupoTrabajoBinding grupoBind = new GrupoTrabajoBinding();
            IDameTodosGrupoTrabajo consulta = new DameTodosGrupoTrabajoPorAsignaturaAnyo(idAsignaturaAnyo);
            BinderListaGrupoTrabajoGrid binder = new BinderListaGrupoTrabajoGrid(grid);

            grupoBind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Método para crear un grupo de trabajo en la BD
        public bool CrearGrupoTrabajo(string codigo, string nombre, string descripcion,
            string password, int capacidad, int asignatura_anyo)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                cp.CrearGrupoTrabajo(codigo, nombre, descripcion, password, capacidad, asignatura_anyo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular un grupo de trabajo a partir de su id a textboxes
        public bool VincularGrupoTrabajoPorIdCompleto(int id, TextBox TextBox_CodGrupo,
            TextBox TextBox_NomGrupo, TextBox TextBox_DescGrupo, TextBox TextBox_Capacidad,
            TextBox TextBox_Anyo, TextBox TextBox_Asignatura)
        {
            try
            {
                GrupoTrabajoBinding binding = new GrupoTrabajoBinding();
                DameGrupoTrabajoPorId consulta = new DameGrupoTrabajoPorId(id);
                IBinderGrupoTrabajo vinculador = new BinderGrupoTrabajoCompleto(TextBox_CodGrupo,
                    TextBox_NomGrupo, TextBox_DescGrupo, TextBox_Capacidad,
                    TextBox_Anyo, TextBox_Asignatura);

                binding.VincularDameGrupoTrabajo(consulta, vinculador);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para vincular un grupo de trabajo a partir de su id a textboxes
        public bool VincularGrupoTrabajoPorIdLigero(int id, TextBox TextBox_NomGrupo, 
            TextBox TextBox_Capacidad)
        {
            try
            {
                GrupoTrabajoBinding binding = new GrupoTrabajoBinding();
                DameGrupoTrabajoPorId consulta = new DameGrupoTrabajoPorId(id);
                IBinderGrupoTrabajo vinculador = new BinderGrupoTrabajoParcial(TextBox_NomGrupo, 
                    TextBox_Capacidad);

                binding.VincularDameGrupoTrabajo(consulta, vinculador);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para modificar un grupo de trabajo en la BD
        public bool ModificarGrupoTrabajo(int oid, string cod, string nombre,
            string descripcion, string password, int capacidad)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                cp.ModificarGrupoTrabajo(oid, cod, nombre, descripcion, password, capacidad);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un grupo de trabajo de la BD
        public bool BorrarGrupoTrabajo(int id)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                cp.BorrarGrupoTrabajo(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para desvincular un alumno de un grupo de trabajo
        public bool DesvincularAlumno(int idGrupo, string email)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                List<string> emails = new List<string>();

                emails.Add(email);
                cp.DesvincularAlumnos(idGrupo,emails);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular un alumno a grupo de trabajo
        public bool VincularAlumno(int idGrupo, string email)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                List<string> emails = new List<string>();

                emails.Add(email);
                cp.VincularAlumnos(idGrupo, emails);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular a un GridView los grupos a los que pertenece un Alumno en una AsignaturaAnyo
        public void VincularDameTodosPorAlumnoYAsignaturaAnyo(string alumno,int idAsignaturaAnyo, GridView grid,
            int first, int size, out long numGrupos)
        {
            GrupoTrabajoBinding grupo = new GrupoTrabajoBinding();
            IDameTodosGrupoTrabajo consulta=new DameTodosGrupoPorAlumnoYAsignaturaAnyo(alumno,idAsignaturaAnyo);
            BinderListaGrupoTrabajoGrid binder = new BinderListaGrupoTrabajoGrid(grid);

            grupo.VincularDameTodos(consulta, binder, first, size, out numGrupos);
        }

        //Método para comprobar el password del grupo
        public bool VincularAlumnoConPassword(int grupoId, string alumno, string password)
        {
            GrupoTrabajoCP cp;

            try
            {
                cp = new GrupoTrabajoCP();
                cp.VincularAlumnoConPassword(grupoId, alumno, password);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
