using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    public class FachadaProfesor
    {
        //Metodo que registra al profesor en BD
        public bool RegistrarProfesor(string nombre, string apellidos, string pass, DateTime fecha, string dni, string email, int cod)
        {
            try
            {
                ProfesorCP profesor = new ProfesorCP();
                profesor.CrearProfesor(nombre, apellidos, pass, fecha, dni, email, cod);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para modificar un profesor en la BD sin modificar su password
        public bool ModificarProfesorNoPassword(string email, int codProfesor, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                ProfesorCP cp = new ProfesorCP();
                cp.ModificarProfesorNoPassword(email, codProfesor, dni, nombre, apellidos, fechaNacimiento);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un profesor en la BD
        public bool BorrarProfesor(int codProfesor)
        {
            try
            {
                ProfesorCP cp = new ProfesorCP();
                cp.BorrarProfesor(codProfesor);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Vincular a un grid view los profesores con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numProfesores)
        {
            //Obtener profesores y enlazar sus datos con el gridview
            ProfesorBinding profesorBind = new ProfesorBinding();
            IDameTodosProfesor consulta = new DameTodosProfesor();
            profesorBind.VincularDameTodos(consulta, grid, first, size, out numProfesores);
        }

        //Devolver un profesor a partir de un id de profesor
        public ProfesorEN DameProfesorPorId(int id)
        {
            ProfesorEN profesor = null;
            ProfesorCP cp = new ProfesorCP();
            DameProfesorPorId consulta = new DameProfesorPorId(id);

            profesor = cp.DameProfesor(consulta);

            if (profesor == null)
                throw new Exception("Profesor no encontrado");

            return profesor;
        }
    }
}
