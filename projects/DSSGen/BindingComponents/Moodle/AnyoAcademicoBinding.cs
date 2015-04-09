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
    //Clase para vincular datos sobre años académicos a alguna estructura de vista
    public class AnyoAcademicoBinding : BasicBinding
    {
        public AnyoAcademicoBinding() : base() { }
        public AnyoAcademicoBinding(ISession sesion) : base(sesion) { }


        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosAnyoAcademico consulta, DropDownList drop,
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
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Vincular con el dropdownlist
                foreach (AnyoAcademicoEN x in lista)
                {
                    drop.Items.Add(new ListItem(x.Anyo.ToString(), x.Id.ToString()));
                }

                //Cerrar sesión
                SessionClose();
            }
        }

        //Vincular a un GridView el resultado de la consulta
        public void VincularDameTodos(IDameTodosAnyoAcademico consulta, GridView grid,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AnyoAcademicoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AnyoAcademicoCP anyo = new AnyoAcademicoCP(session);
                //Ejecutar la consulta recibida sin paginar
                lista = anyo.DameTodosTotal(consulta, first, size, out total);
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
