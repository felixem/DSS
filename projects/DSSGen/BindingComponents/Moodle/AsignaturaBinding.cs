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
    //Clase para vincular datos sobre asignaturas a alguna estructura de vista
    public class AsignaturaBinding : BasicBinding
    {
        public AsignaturaBinding() : base() { }
        public AsignaturaBinding(ISession sesion) : base(sesion) { }

        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosAsignatura consulta, IBinderListaAsignatura binder,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AsignaturaCP asig = new AsignaturaCP(session);
                //Ejecutar la consulta recibida
                lista = asig.DameTodosTotal(consulta, first, size, out total);
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

        //Vincular a TextBoxes el contenido de una consulta individual sobre una asignatura
        public void VincularDameAsignatura(IDameAsignatura consulta, IBinderAsignatura linker)
        {
            AsignaturaEN asignatura = null;

            try
            {
                SessionInitializeTransaction();

                AsignaturaCP cp = new AsignaturaCP(session);
                //Ejecutar la consulta recibida
                asignatura = cp.DameAsignatura(consulta);

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
