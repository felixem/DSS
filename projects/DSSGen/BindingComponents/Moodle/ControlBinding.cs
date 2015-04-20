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
    public class ControlBinding : BasicBinding
    {
        public ControlBinding() : base() { }
        public ControlBinding(ISession sesion) : base(sesion) { }

        //Vincular GridView al resultado de la consulta especificada devolviendo los controles existentes
        public void VincularDameTodos(IDameTodosControl consulta, IBinderListaControl binder, 
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<ControlEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                ControlCP Control = new ControlCP(session);
                //Ejecutar la consulta recibida 
                lista = Control.DameTodosTotal(consulta, first, size, out numBases);
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
        public void VincularDameControl(IDameControl consulta, IBinderControl linker)
        {
            ControlEN en = null;

            try
            {
                SessionInitializeTransaction();

                ControlCP cp = new ControlCP(session);
                //Ejecutar la consulta recibida
                en = cp.DameControl(consulta);

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
                    throw new Exception("Control no encontrado");

                //Vincular con los textboxes
                linker.Vincular(en);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
