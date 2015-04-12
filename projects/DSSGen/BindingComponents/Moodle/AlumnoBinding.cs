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
    public class AlumnoBinding : BasicBinding
    {
        public AlumnoBinding() : base() { }
        public AlumnoBinding(ISession sesion) : base(sesion) { }

        //Vincular GridView al resultado de la consulta especificada devolviendo la alumnos existentes
        public void VincularDameTodos(IDameTodosAlumno consulta, GridView grid, int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<AlumnoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AlumnoCP alumno = new AlumnoCP(session);
                //Ejecutar la consulta recibida 
                lista = alumno.DameTodosTotal(consulta, first, size, out numBases);
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

        //Vincular a TextBoxes el contenido de una consulta individual sobre un alumno
        public void VincularDameAlumno(IDameAlumno consulta, IVinculadorAlumno linker)
        {
            AlumnoEN alumno = null;

            try
            {
                SessionInitializeTransaction();

                AlumnoCP cp = new AlumnoCP(session);
                //Ejecutar la consulta recibida
                alumno = cp.DameAlumno(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado el alumno
                if (alumno == null)
                    throw new Exception("Alumno no encontrado");

                //Vincular con los textboxes
                linker.Vincular(alumno);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
