using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Web.UI.WebControls;
using ComponentesProceso.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;

namespace BindingComponents.Moodle
{
    public class EvaluacionBinding:BasicBinding
    {
        //Vincular a TextBoxes el contenido de una consulta individual sobre una evaluacion
        public void VincularDameEvaluacion(IDameEvaluacion consulta, IBinderEvaluacion linker)
        {
            EvaluacionEN en = null;

            try
            {
                SessionInitializeTransaction();

                EvaluacionCP cp = new EvaluacionCP(session);
                //Ejecutar la consulta recibida
                en = cp.DameEvaluacion(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado la evaluacion
                if (en == null)
                    throw new Exception("Evaluación no encontrada");

                //Vincular con los textboxes
                linker.Vincular(en);

                //Cerrar sesión
                SessionClose();
            }
        }
        //Vincular GridView al resultado de la consulta especificada devolviendo los Evaluaciones existentes
        public void VincularDameTodos(IDameTodosEvaluacion consulta, IBinderListaEvaluacion binder,
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<EvaluacionEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                EvaluacionCP Evaluacion = new EvaluacionCP(session);
                //Ejecutar la consulta recibida 
                lista = Evaluacion.DameTodosTotal(consulta, first, size, out numBases);
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
        //Vincular GridView al resultado de la consulta especificada devolviendo los Evaluaciones existentes
        public void VincularDameTodosPorAnyo(IDameTodosEvaluacion consulta, IBinderListaEvaluacion binder,
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<EvaluacionEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                EvaluacionCP Evaluacion = new EvaluacionCP(session);
                //Ejecutar la consulta recibida 
                lista = Evaluacion.DameTodosPorAnyo(consulta, first, size, out numBases);
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
    }
}
