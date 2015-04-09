using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;

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
