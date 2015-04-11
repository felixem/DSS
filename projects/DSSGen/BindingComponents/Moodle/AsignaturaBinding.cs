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
    //Clase para vincular datos sobre asignaturas a alguna estructura de vista
    public class AsignaturaBinding : BasicBinding
    {
        public AsignaturaBinding() : base() { }
        public AsignaturaBinding(ISession sesion) : base(sesion) { }

        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosAsignatura consulta, DropDownList drop,
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
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Vincular con el dropdownlist
                foreach (AsignaturaEN x in lista)
                {
                    drop.Items.Add(new ListItem(x.Nombre, x.Id.ToString()));
                }

                //Cerrar sesión
                SessionClose();
            }
        }

        //Vincular a un GridView el resultado de la consulta
        public void VincularDameTodos(IDameTodosAsignatura consulta, GridView grid,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AsignaturaCP asig = new AsignaturaCP(session);
                //Ejecutar la consulta recibida sin paginar
                lista = asig.DameTodosTotal(consulta, first, size, out total);
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

        //Vincular a TextBoxes el contenido de una consulta individual sobre una asignatura
        public void VincularDameAsignatura(IDameAsignatura consulta, TextBox TextBox_IdAsig,
            TextBox TextBox_CodAsig, TextBox TextBox_NomAsig, TextBox TextBox_DescAsig,
            CheckBox CheckBox_OptativaAsig, CheckBox CheckBox_VigenteAsig)
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
                TextBox_IdAsig.Text = asignatura.Id.ToString();
                TextBox_CodAsig.Text = asignatura.Cod_asignatura;
                TextBox_NomAsig.Text = asignatura.Nombre;
                TextBox_DescAsig.Text = asignatura.Descripcion;
                CheckBox_OptativaAsig.Checked = asignatura.Optativa;
                CheckBox_VigenteAsig.Checked = asignatura.Vigente;

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
