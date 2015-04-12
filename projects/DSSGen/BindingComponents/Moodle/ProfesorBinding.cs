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
    public class ProfesorBinding : BasicBinding
    {
        public ProfesorBinding() : base() { }
        public ProfesorBinding(ISession sesion) : base(sesion) { }

        //Vincular GridView al resultado de la consulta especificada devolviendo los profesores existentes
        public void VincularDameTodos(IDameTodosProfesor consulta, GridView grid, int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<ProfesorEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                ProfesorCP Profesor = new ProfesorCP(session);
                //Ejecutar la consulta recibida 
                lista = Profesor.DameTodosTotal(consulta, first, size, out numBases);
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

        //Vincular a TextBoxes el contenido de una consulta individual sobre un profesor
        public void VincularDameProfesor(IDameProfesor consulta, IVinculadorProfesor linker)
        {
            ProfesorEN profesor = null;

            try
            {
                SessionInitializeTransaction();

                ProfesorCP cp = new ProfesorCP(session);
                //Ejecutar la consulta recibida
                profesor = cp.DameProfesor(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado el profesor
                if (profesor == null)
                    throw new Exception("Profesor no encontrado");

                //Vincular con los textboxes
                linker.Vincular(profesor);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
