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
using WebUtilities;

namespace Fachadas.Moodle
{
    //Fachada para la clase Sistema Evaluacion
    public class FachadaSistemaEvaluacion
    {
        //Crear sistema
        public bool RegistrarSistema(float puntuacion,int asignaturaany,int eval)
        {
            try
            {
                SistemaEvaluacionCP evaluacion = new SistemaEvaluacionCP();
                evaluacion.CrearSistema(puntuacion,asignaturaany,eval);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El sistema de evaluación no pudo ser creado. " 
                    + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El sistema de evaluación ha sido creado");
            return true;
        }
        //Metodo que modifica el sitema en BD
        public bool ModificarSistemaEvaluacion(int p_oid, float p_maxima)
        {
            try
            {
               SistemaEvaluacionCP cp = new SistemaEvaluacionCP();
               cp.ModificarSistemaEvaluacion(p_oid, p_maxima);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El sistema de evaluación no pudo ser modificado. "
                    + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El sistema de evaluación ha sido modificado");
            return true;
        }
        //Método para eliminar un sistema en la BD
        public bool BorrarSistemaEvaluacion(int cod)
        {
            try
            {
               SistemaEvaluacionCP cp = new SistemaEvaluacionCP();
                cp.BorrarSistemaEvaluacion(cod);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El sistema de evaluación no pudo ser borrado. "
                    + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El sistema de evaluación ha sido borrado");
            return true;
        }
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
        //Método para vincular un control a partir de su id a textboxes
        public bool VincularSistemaPorId(int id, TextBox TextBox_Puntuacion)
        {
            try
            {
                SistemaEvaluacionBinding binding = new SistemaEvaluacionBinding();
                DameSistemaPorId consulta = new DameSistemaPorId(id);
                IBinderSistemaEvaluacion linker = new BinderSistemaEvaluacion(TextBox_Puntuacion);

                binding.VincularDameSistema(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
