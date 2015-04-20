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
    //Clase para vincular datos sobre años académicos a alguna estructura de vista
    public class AnyoAcademicoBinding : BasicBinding
    {
        public AnyoAcademicoBinding() : base() { }
        public AnyoAcademicoBinding(ISession sesion) : base(sesion) { }

        //Vincular a una vista de conjunto el contenido de la consulta
        public void VincularDameTodos(IDameTodosAnyoAcademico consulta, IBinderListaAnyoAcademico binder,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AnyoAcademicoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AnyoAcademicoCP anyo = new AnyoAcademicoCP(session);
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
    }
}
