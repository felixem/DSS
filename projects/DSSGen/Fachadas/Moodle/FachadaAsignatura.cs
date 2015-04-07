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
            asig.VincularDameTodos(consulta, drop);
        }
    }
}
