using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle.Commands;
using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;
using BindingComponents.Moodle.Commands;

namespace BindingComponents.Moodle
{
    //Clase para vincular datos sobre sistemas evaluacion a alguna estructura de vista
    public class SistemaEvaluacionBinding : BasicBinding
    {
        public SistemaEvaluacionBinding() : base() { }
        public SistemaEvaluacionBinding(ISession sesion) : base(sesion) { }

        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosSistemaEvaluacion consulta, IBinderListaSistemaEvaluacion binder,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<SistemaEvaluacionEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                SistemaEvaluacionCP stmeval = new SistemaEvaluacionCP(session);
                //Ejecutar la consulta recibida
                lista = stmeval.DameTodosTotal(consulta, first, size, out total);
                SessionCommit();

                //Vincular
                binder.Vincular(lista);

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }
        //Vincular a TextBoxes el contenido de una consulta individual sobre un Control
        public void VincularDameSistema(IDameSistemaEvaluacion consulta, IBinderSistemaEvaluacion linker)
        {
            SistemaEvaluacionEN en = null;

            try
            {
                SessionInitializeTransaction();

                SistemaEvaluacionCP cp = new SistemaEvaluacionCP(session);
                //Ejecutar la consulta recibida
                en = cp.DameSistema(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado el Control
                if (en == null)
                    throw new Exception("Sistema de evaluacion no encontrado");

                //Vincular con los textboxes
                linker.Vincular(en);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
