using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;

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
            long total;
            binding.VincularDameTodos(consulta, drop, 0, -1, out total);
        }

        //Vincular a un DropDownList todas las asignaturas-anyo que se corresponden con un año determinado
        public void VincularDameTodosPorAnyo(DropDownList drop, int idAnyo)
        {
            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyoPorAnyo consulta = new DameTodosAsignaturaAnyoPorAnyo(idAnyo);
            long total;
            binding.VincularDameTodos(consulta, drop, 0, -1, out total);
        }

        //Vincular a un GridView todas las asignaturas-anyo
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            AsignaturaAnyoBinding binding = new AsignaturaAnyoBinding();
            DameTodosAsignaturaAnyo consulta = new DameTodosAsignaturaAnyo();
            binding.VincularDameTodos(consulta, grid, first, size, out numElements);
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

        //Método para obtener una asignatura-anyo por su id
        public AsignaturaAnyoEN DameAsignaturaAnyoPorId(int id)
        {
            AsignaturaAnyoEN asignaturaAnyo = null;
            AsignaturaAnyoCP cp = new AsignaturaAnyoCP();
            DameAsignaturaAnyoPorId consulta = new DameAsignaturaAnyoPorId(id);

            asignaturaAnyo = cp.DameAsignaturaAnyo(consulta);

            if (asignaturaAnyo == null)
                throw new Exception("AsignaturaAnyo no encontrada");

            return asignaturaAnyo;
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
    }
}
