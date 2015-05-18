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
    public class EntregaAlumnoBinding : BasicBinding
    {
        public EntregaAlumnoBinding() : base() { }
        public EntregaAlumnoBinding(ISession sesion) : base(sesion) { }

        //Vincular GridView al resultado de la consulta especificada devolviendo los controles existentes
        public void VincularDameTodos(IDameTodosEntregaAlumno consulta, IBinderListaEntregaAlumno binder,
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<EntregaAlumnoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                EntregaAlumnoCP en = new EntregaAlumnoCP(session);
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
        public void VincularDameEntregaAlumno(IDameEntregaAlumno consulta, IBinderEntregaAlumno linker)
        {
            EntregaAlumnoEN en = null;

            try
            {
                SessionInitializeTransaction();

                EntregaAlumnoCP cp = new EntregaAlumnoCP(session);
                //Ejecutar la consulta recibida
                en = cp.DameEntregaAlumno(consulta);

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
