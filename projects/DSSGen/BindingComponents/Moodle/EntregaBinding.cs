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
    public class EntregaBinding : BasicBinding
    {
        public EntregaBinding() : base() { }
        public EntregaBinding(ISession sesion) : base(sesion) { }

        //Vincular GridView al resultado de la consulta especificada devolviendo los controles existentes
        public void VincularDameTodos(IDameTodosEntrega consulta, IBinderListaEntrega binder,
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<EntregaEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                EntregaCP en = new EntregaCP(session);
                //Ejecutar la consulta recibida 
                lista = en.DameTodosTotal(consulta, first, size, out numBases);
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
        public void VincularDameEntrega(IDameEntrega consulta, IBinderEntrega linker)
        {
            EntregaEN en = null;

            try
            {
                SessionInitializeTransaction();

                EntregaCP cp = new EntregaCP(session);
                //Ejecutar la consulta recibida
                en = cp.DameEntrega(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado la Entrega
                if (en == null)
                    throw new Exception("Entrega no encontrada");

                //Vincular con los textboxes
                linker.Vincular(en);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
