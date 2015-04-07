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
    //Fachada para la clase pregunta
    public class FachadaAsignatura
    {
        //Vincular a un DropDownList todas las preguntas
        public void VincularDameTodos(DropDownList drop)
        {
            AsignaturaBinding asig = new AsignaturaBinding();
            DameTodosAsignatura consulta = new DameTodosAsignatura();
            long total;
            asig.VincularDameTodos(consulta, drop, 0, -1, out total);
        }

        //Vincular a un GridView todas las preguntas
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            AsignaturaBinding asig = new AsignaturaBinding();
            DameTodosAsignatura consulta = new DameTodosAsignatura();
            asig.VincularDameTodos(consulta, grid, first, size, out numElements);
        }

        //Método para crear una asignatura en la BD
        public bool CrearAsignatura(string codigo, string nombre, string descripcion,
            bool optativa, bool vigente)
        {
            try
            {
                AsignaturaCP cp = new AsignaturaCP();
                cp.CrearAsignatura(codigo,nombre,descripcion,optativa,vigente);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para obtener una asignatura a partir de su id
        public AsignaturaEN DameAsignaturaPorId(int id)
        {
            AsignaturaEN asignatura = null;
            AsignaturaCP cp = new AsignaturaCP();
            DameAsignaturaPorId consulta = new DameAsignaturaPorId(id);

            asignatura = cp.DameAsignatura(consulta);

            if (asignatura == null)
                throw new Exception("Alumno no encontrado");

            return asignatura;
        }

        //Método para modificar una asignatura en la BD
        public bool ModificarAsignatura(int oid, string codAsignatura, string nombre,
            string descripcion, bool optativa, bool vigente)
        {
            try
            {
                AsignaturaCP cp = new AsignaturaCP();
                cp.ModificarAsignatura(oid,codAsignatura,nombre,descripcion,optativa,vigente);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar una asignatura de la BD
        public bool BorrarAsignatura(int id)
        {
            try
            {
                AsignaturaCP cp = new AsignaturaCP();
                cp.BorrarAsignatura(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
