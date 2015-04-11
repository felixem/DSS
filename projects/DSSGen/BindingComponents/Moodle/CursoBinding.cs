using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle.Commands;
using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;

namespace BindingComponents.Moodle
{
    //Clase para vincular datos sobre cursos a alguna estructura de vista
    public class CursoBinding : BasicBinding
    {
        public CursoBinding() : base() { }
        public CursoBinding(ISession sesion) : base(sesion) { }

        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosCurso consulta, DropDownList drop,
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
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Vincular con el dropdownlist
                foreach (CursoEN x in lista)
                {
                    drop.Items.Add(new ListItem(x.Nombre, x.Id.ToString()));
                }

                //Cerrar sesión
                SessionClose();
            }
        }

        //Vincular a un GridView el resultado de la consulta
        public void VincularDameTodos(IDameTodosCurso consulta, GridView grid,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<CursoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                CursoCP curso = new CursoCP(session);
                //Ejecutar la consulta recibida sin paginar
                lista = curso.DameTodosTotal(consulta, first, size, out total);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Vincular con el grid view
                grid.DataSource = lista;
                grid.DataBind();

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
