using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;
using WebUtilities;

namespace Fachadas.Moodle
{
    public class FachadaControl
    {
        //Metodo que registra el control en BD
        public bool RegistrarControl(string p_nombre, string p_descripcion, DateTime p_fecha_apertura,
            DateTime p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima,
            float p_penalizacion_fallo, int p_sistema_evaluacion)
        {
            try
            {
                ControlCP control = new ControlCP();
                control.CrearControl(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo, p_sistema_evaluacion);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El control no pudo ser creado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El control ha sido creado");
            return true;
        }
    
        //Metodo que modifica el control en BD
        public bool ModificarControl(int p_oid, string p_nombre, string p_descripcion, DateTime p_fecha_apertura,
            DateTime p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima, float p_penalizacion_fallo)
        {
            try
            {
                ControlCP cp = new ControlCP();
                cp.ModificarControl(p_oid, p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El control no pudo ser modificado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El control ha sido modificado");
            return true;
        }

        //Método para vincular un control a partir de su id a textboxes
        public bool VincularControlPorId(int id, TextBox TextBox_Nom,
            TextBox TextBox_Desc, DropDownList ddlAno, DropDownList ddlMes, DropDownList ddlDia,
            DropDownList ddlAnoC, DropDownList ddlMesC, DropDownList ddlDiaC,
            TextBox TextBox_Duracion, TextBox TextBox_PuntMax, TextBox TextBox_Penalizacion, 
            TextBox TextBox_Anyo, TextBox TextBox_Asignatura, TextBox TextBox_Evaluacion, TextBox TextBox_CodControl)
        {
            try
            {
                ControlBinding binding = new ControlBinding();
                DameControlPorId consulta = new DameControlPorId(id);
                IBinderControl linker = new BinderControl(TextBox_Nom,
                    TextBox_Desc,ddlAno, ddlMes, ddlDia, ddlAnoC, ddlMesC, ddlDiaC,
                    TextBox_Duracion, TextBox_PuntMax, TextBox_Penalizacion,
                    TextBox_Anyo, TextBox_Asignatura, TextBox_Evaluacion, TextBox_CodControl);

                binding.VincularDameControl(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Vincular a un grid view los controles con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numControles)
        {
            //Obtener controles y enlazar sus datos con el gridview
            ControlBinding controlBind = new ControlBinding();
            IDameTodosControl consulta = new DameTodosControl();
            BinderListaControlGrid binder = new BinderListaControlGrid(grid);
            controlBind.VincularDameTodos(consulta, binder, first, size, out numControles);
        }

        //Método para eliminar un control en la BD
        public bool BorrarControl(int cod)
        {
            try
            {
                ControlCP cp = new ControlCP();
                cp.BorrarControl(cod);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El control no pudo ser borrado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El control ha sido borrado");
            return true;
        }

        //Vincular a un gridview los controles pertenecientes a una asignatura-anyo con paginación
        public void VincularDameTodosPorAsignaturaAnyo(int idAsignaturaAnyo, GridView grid,
            int first, int size, out long numAlumnos)
        {
            //Obtener controles y enlazar sus datos con el gridview
            ControlBinding Bind = new ControlBinding();
            IDameTodosControl consulta = new DameTodosControlPorAsignaturaAnyo(idAsignaturaAnyo);
            BinderListaControlGrid binder = new BinderListaControlGrid(grid);

            Bind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }
    }
}
