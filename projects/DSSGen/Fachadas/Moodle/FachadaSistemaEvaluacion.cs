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
    //Fachada para la clase Sistema Evaluacion
    public class FachadaSistemaEvaluacion
    {
        //Vincular a un DropDownList todos los sistemas de evaluacion
        public void VincularDameTodos(DropDownList drop)
        {
            SistemaEvaluacionBinding stmeval = new SistemaEvaluacionBinding();
            DameTodosSistemaEvaluacion consulta = new DameTodosSistemaEvaluacion();
            BinderListaSistemaEvaluacionDropDownList binder = new BinderListaSistemaEvaluacionDropDownList(drop);
            long total;
            stmeval.VincularDameTodos(consulta, binder, 0, -1, out total);
        }

        //Vincular a un DropDownList todos los sistemas de evaluacion de ese AsignaturaAnyo
        public void VincularDameTodosPorAsignaturaAnyo(DropDownList drop, int idAsignaturaAnyo)
        {
            SistemaEvaluacionBinding stmeval = new SistemaEvaluacionBinding();
            DameTodosSistemaEvaluacionPorAsignaturaAnyo consulta = new DameTodosSistemaEvaluacionPorAsignaturaAnyo(idAsignaturaAnyo);
            BinderListaSistemaEvaluacionDropDownList binder = new BinderListaSistemaEvaluacionDropDownList(drop);
            long total;
            stmeval.VincularDameTodos(consulta, binder, 0, -1, out total);
        }
    }
}
