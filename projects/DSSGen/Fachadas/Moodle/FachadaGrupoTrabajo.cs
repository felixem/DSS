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
    public class FachadaGrupoTrabajo
    {
        //Vincular a un GridView todas los grupos de trabajo
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            GrupoTrabajoBinding grupo = new GrupoTrabajoBinding();
            DameTodosGrupoTrabajo consulta = new DameTodosGrupoTrabajo();
            grupo.VincularDameTodos(consulta, grid, first, size, out numElements);
        }

        //Método para crear un grupo de trabajo en la BD
        public bool CrearGrupoTrabajo(string codigo, string nombre, string descripcion,
            string password, int capacidad, int asignatura_anyo)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                cp.CrearGrupoTrabajo(codigo,nombre,descripcion,password,capacidad,asignatura_anyo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para obtener un grupo de trabajo a partir de su id
        public GrupoTrabajoEN DameGrupoTrabajoPorId(int id)
        {
            GrupoTrabajoEN grupo = null;
            GrupoTrabajoCP cp = new GrupoTrabajoCP();
            DameGrupoTrabajoPorId consulta = new DameGrupoTrabajoPorId(id);

            grupo = cp.DameGrupoTrabajo(consulta);

            if (grupo == null)
                throw new Exception("Grupo de trabajo no encontrado");

            return grupo;
        }

        //Método para modificar un grupo de trabajo en la BD
        public bool ModificarGrupoTrabajo(int oid, string cod, string nombre,
            string descripcion, string password, int capacidad)
        {
            try
            {
                GrupoTrabajoCP cp = new GrupoTrabajoCP();
                cp.ModificarGrupoTrabajo(oid,cod,nombre,descripcion,password,capacidad);
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
    }
}
