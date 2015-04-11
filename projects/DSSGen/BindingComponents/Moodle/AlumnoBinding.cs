using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Web.UI.WebControls;
using ComponentesProceso.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;

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
        public void VincularDameAlumno(IDameAlumno consulta, TextBox TextBox_NomAlu,
            TextBox TextBox_ApellAlu, TextBox TextBox_NaciAlu, TextBox TextBox_DNIAlu,
            TextBox TextBox_EmailAlu, TextBox TextBox_CodAlu, CheckBox CheckBox_Baneado)
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
                TextBox_NomAlu.Text = alumno.Nombre;
                TextBox_ApellAlu.Text = alumno.Apellidos;
                TextBox_NaciAlu.Text = alumno.Fecha_nacimiento.ToString();
                TextBox_DNIAlu.Text = alumno.Dni;
                TextBox_EmailAlu.Text = alumno.Email;
                TextBox_CodAlu.Text = alumno.Cod_alumno.ToString();
                CheckBox_Baneado.Checked = alumno.Baneado;

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
