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
    //Clase para vincular datos sobre asignaturas-anyo a alguna estructura de vista
    public class AsignaturaAnyoBinding : BasicBinding
    {
        public AsignaturaAnyoBinding() : base() { }
        public AsignaturaAnyoBinding(ISession sesion) : base(sesion) { }

        //Vincular a una estructura de vista múltiple el resultado de la consulta
        public void VincularDameTodos(IDameTodosAsignaturaAnyo consulta, IBinderListaAsignaturaAnyo binder,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AsignaturaAnyoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AsignaturaAnyoCP anyo = new AsignaturaAnyoCP(session);
                //Ejecutar la consulta recibida
                lista = anyo.DameTodosTotal(consulta, first, size, out total);
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

        //Vincular a TextBoxes el contenido de una consulta individual sobre una asignatura-anyo
        public void VincularDameAsignaturaAnyo(IDameAsignaturaAnyo consulta, IBinderAsignaturaAnyo linker)
        {
            AsignaturaAnyoEN asignatura = null;

            try
            {
                SessionInitializeTransaction();

                AsignaturaAnyoCP cp = new AsignaturaAnyoCP(session);
                //Ejecutar la consulta recibida
                asignatura = cp.DameAsignaturaAnyo(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado la asignatura
                if (asignatura == null)
                    throw new Exception("Asignatura no encontrada");

                //Vincular con los textboxes
                linker.Vincular(asignatura);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
