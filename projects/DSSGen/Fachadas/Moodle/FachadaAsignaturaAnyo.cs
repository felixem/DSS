using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;

namespace Fachadas.Moodle
{
    //Fachada para la clase AsignaturaAnyo
    public class FachadaAsignaturaAnyo
    {
        //Vincular a un DropDownList todas las asignaturas-anyo
        public void VincularDameTodos(DropDownList drop)
        {
            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyo consulta = new DameTodosAsignaturaAnyo();
            BinderListaAsignaturaAnyoDropDownList binder = new BinderListaAsignaturaAnyoDropDownList(drop);
            long total;
            binding.VincularDameTodos(consulta, binder, 0, -1, out total);
        }

        //Vincular a un DropDownList todas las asignaturas-anyo que se corresponden con un año determinado
        public void VincularDameTodosPorAnyo(DropDownList drop, int idAnyo)
        {
            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyoPorAnyo consulta = new DameTodosAsignaturaAnyoPorAnyo(idAnyo);
            BinderListaAsignaturaAnyoDropDownList binder = new BinderListaAsignaturaAnyoDropDownList(drop);
            long total;
            binding.VincularDameTodos(consulta, binder, 0, -1, out total);
        }

        //Vincular a un Gridview todas las asignaturas-anyo que se corresponden con un año determinado
        public void VincularDameTodosPorAnyo(int idAnyo, GridView grid, int first, int size, out long numElements)
        {
            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyoPorAnyo consulta = new DameTodosAsignaturaAnyoPorAnyo(idAnyo);
            BinderListaAsignaturaAnyoGrid binder = new BinderListaAsignaturaAnyoGrid(grid);
            binding.VincularDameTodos(consulta, binder, 0, -1, out numElements);
        }

        //Vincular a un GridView todas las asignaturas-anyo
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyo consulta = new DameTodosAsignaturaAnyo();
            BinderListaAsignaturaAnyoGrid binder = new BinderListaAsignaturaAnyoGrid(grid);
            binding.VincularDameTodos(consulta, binder, first, size, out numElements);
        }

        //Método para vincular una asignatura a partir de su id a textboxes
        public bool VincularAsignaturaAnyoPorIdLigero(int id, TextBox TextBox_Asignatura)
        {
            try
            {
                AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
                DameAsignaturaAnyoPorId consulta = new DameAsignaturaAnyoPorId(id);
                BinderAsignaturaAnyoLigero vinculador =
                    new BinderAsignaturaAnyoLigero(TextBox_Asignatura);

                binding.VincularDameAsignaturaAnyo(consulta, vinculador);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para crear una asignatura-anyo en la BD
        public bool CrearAsignaturaAnyo(int idAnyo, int idAsignatura)
        {
            try
            {
                AsignaturaAnyoCP cp = new AsignaturaAnyoCP();
                cp.CrearAsignaturaAnyo(idAnyo,idAsignatura);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para modificar una asignatura-anyo en la BD
        public bool ModificarAsignaturaAnyo(int oid)
        {
            try
            {
                AsignaturaAnyoCP cp = new AsignaturaAnyoCP();
                cp.ModificarAsignaturaAnyo(oid);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar una asignatura-anyo de la BD
        public bool BorrarAsignaturaAnyo(int id)
        {
            try
            {
                AsignaturaAnyoCP cp = new AsignaturaAnyoCP();
                cp.BorrarAsignaturaAnyo(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para matricular un alumno en una asignatura anyo
        public bool MatricularAlumno(int codAlumno, int idAsignaturaAnyo)
        {
            try
            {
                AsignaturaAnyoCP cp = new AsignaturaAnyoCP();
                cp.MatricularAlumno(codAlumno, idAsignaturaAnyo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para desmatricular un alumno en una asignatura anyo
        public bool DesmatricularAlumno(int codAlumno, int idAsignaturaAnyo)
        {
            try
            {
                AsignaturaAnyoCP cp = new AsignaturaAnyoCP();
                cp.DesmatricularAlumno(codAlumno, idAsignaturaAnyo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular las asignaturas matriculadas de un alumno a un GridView
        public void VincularDameTodosPorMariculadoAnyo(int idAnyo, GridView grid, int first, int size, out long numElements)
        {

            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyoPorAnyo consulta = new DameTodosAsignaturaAnyoPorAnyo(idAnyo);
            BinderListaAsignaturaAnyoGrid binder = new BinderListaAsignaturaAnyoGrid(grid);
            binding.VincularDameTodos(consulta, binder, 0, -1, out numElements);

        }
    }
}
