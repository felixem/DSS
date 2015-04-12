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
    //Clase para vincular datos sobre cursos a alguna estructura de vista
    public class CursoBinding : BasicBinding
    {
        public CursoBinding() : base() { }
        public CursoBinding(ISession sesion) : base(sesion) { }

        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosCurso consulta, IBinderListaCurso binder,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<CursoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                CursoCP curso = new CursoCP(session);
                //Ejecutar la consulta recibida
                lista = curso.DameTodosTotal(consulta, first, size, out total);
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
