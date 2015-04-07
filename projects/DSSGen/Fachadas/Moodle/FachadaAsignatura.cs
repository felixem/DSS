using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;

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
    }
}
