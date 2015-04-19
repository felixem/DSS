using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;


namespace Fachadas.Moodle
{
    public class FachadaEvaluacion
    {
        public bool RegistrarEvaluacion(string p_nombre, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_abierta, int p_anyo_academico) {
            try
            {
                EvaluacionCP evaluacion = new EvaluacionCP();
                evaluacion.CrearEvaluacion(p_nombre, p_fecha_inicio,p_fecha_fin,p_abierta,p_anyo_academico);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool ModificarEvaluacion(int id,string p_nombre, Nullable<DateTime> p_fecha_inicio, Nullable<DateTime> p_fecha_fin, bool p_abierta)
        {
            try
            {
                EvaluacionCP evaluacion = new EvaluacionCP();
                evaluacion.ModificarEvaluacion(id,p_nombre, p_fecha_inicio, p_fecha_fin, p_abierta);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        //Método para vincular una evaluacion a partir de su id a textboxes
        public bool VincularEvaluacionPorId(int id, TextBox TextBox_Nom,
            TextBox TextBox_inicio,TextBox TextBox_fin,CheckBox abierta)
        {
            try
            {
                EvaluacionBinding binding = new EvaluacionBinding();
                DameEvaluacionPorId consulta = new DameEvaluacionPorId(id);
                BinderEvaluacion linker = new BinderEvaluacion(TextBox_Nom,
                    TextBox_inicio, TextBox_fin, abierta);

                binding.VincularDameEvaluacion(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //Vincular a un DropDownList todas las evaluaciones-anyo que se corresponden con un año determinado
        public void VincularDameTodosPorAnyo(int idAnyo, DropDownList drop)
        {
            EvaluacionBinding binding = new EvaluacionBinding();
            DameTodosEvaluacionPorAnyo consulta = new DameTodosEvaluacionPorAnyo(idAnyo);
            BinderListaEvaluacionDropDownList binder = new BinderListaEvaluacionDropDownList(drop);
            long total;
            binding.VincularDameTodosPorAnyo(consulta, binder, 0, -1, out total);
        }
        //Vincular a un grid view los Evaluaciones con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numEvaluaciones)
        {
            //Obtener Evaluaciones y enlazar sus datos con el gridview
            EvaluacionBinding EvaluacionBind = new EvaluacionBinding();
            IDameTodosEvaluacion consulta = new DameTodosEvaluacion();
            BinderListaEvaluacionGrid binder = new BinderListaEvaluacionGrid(grid);
            EvaluacionBind.VincularDameTodos(consulta, binder, first, size, out numEvaluaciones);
        }
        //Método para eliminar un control en la BD
        public bool BorrarEvaluacion(int cod)
        {
            try
            {
                EvaluacionCP cp = new EvaluacionCP();
                cp.BorrarEvaluacion(cod);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
