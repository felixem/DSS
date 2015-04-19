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

namespace Fachadas.Moodle
{
    public class FachadaEntrega
    {
        //Metodo que registra la entrega en BD
        public bool RegistrarEntrega(string p_nombre, string p_descripcion, 
            Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, 
            float p_puntuacion_maxima, string p_profesor, int p_evaluacion)
        {
            try
            {
                EntregaCP entrega = new EntregaCP();
                entrega.CrearEntrega(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_puntuacion_maxima, p_profesor, p_evaluacion);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un entrega en la BD
        public bool BorrarEntrega(int cod)
        {
            try
            {
                EntregaCP cp = new EntregaCP();
                cp.BorrarEntrega(cod);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Vincular a un grid view los entregas con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numControles)
        {
            //Obtener Entrega y enlazar sus datos con el gridview
            EntregaBinding controlBind = new EntregaBinding();
            IDameTodosEntrega consulta = new DameTodosEntrega();
            BinderListaEntregaGrid binder = new BinderListaEntregaGrid(grid);
            controlBind.VincularDameTodos(consulta, binder, first, size, out numControles);
        }

        //Metodo que modifica el Entrega en BD
        public bool ModificarEntrega(int p_oid, string p_nombre, string p_descripcion,
            Nullable<DateTime> p_fecha_apertura,
            Nullable<DateTime> p_fecha_cierre, float p_puntuacion_maxima)
        {
            try
            {
                EntregaCP cp = new EntregaCP();
                cp.ModificarEntrega(p_oid, p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_puntuacion_maxima);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular un entrega a partir de su id a textboxes
        public bool VincularEntregaPorId(int id, TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertura, TextBox TextBox_Cierre,
            TextBox TextBox_PuntMax,
            TextBox TextBox_Anyo, TextBox TextBox_Asignatura, TextBox TextBox_Evaluacion, TextBox TextBox_Profesor, TextBox TextBox_CodEntrega)
        {
            try
            {
                EntregaBinding binding = new EntregaBinding();
                DameEntregaPorId consulta = new DameEntregaPorId(id);
                IBinderEntrega linker = new BinderEntrega(TextBox_Nom,
                    TextBox_Desc, TextBox_Apertura, TextBox_Cierre,
                    TextBox_PuntMax,
                    TextBox_Anyo, TextBox_Asignatura, TextBox_Evaluacion, TextBox_Profesor, TextBox_CodEntrega);

                binding.VincularDameEntrega(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para vincular un entrega a partir de su id a textboxes con vista ligera
        public bool VincularEntregaPorIdLigero(int id, TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertura, TextBox TextBox_Cierre,
            TextBox TextBox_PuntMax)
        {
            try
            {
                EntregaBinding binding = new EntregaBinding();
                DameEntregaPorId consulta = new DameEntregaPorId(id);
                IBinderEntrega linker = new BinderEntregaLigero(TextBox_Nom,
                    TextBox_Desc, TextBox_Apertura, TextBox_Cierre,
                    TextBox_PuntMax);

                binding.VincularDameEntrega(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Vincular a un gridview las entregas pertenecientes a una asignatura-anyo con paginación
        public void VincularDameTodosPorAsignaturaAnyo(int idAsignaturaAnyo, GridView grid,
            int first, int size, out long numAlumnos)
        {
            //Obtener entregas y enlazar sus datos con el gridview
            EntregaBinding Bind = new EntregaBinding();
            IDameTodosEntrega consulta = new DameTodosEntregaPorAsignaturaAnyo(idAsignaturaAnyo);
            BinderListaEntregaGrid binder = new BinderListaEntregaGrid(grid);

            Bind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Método para vincular un entrega a partir de su id a textboxes con vista ligera
        public bool VincularEntregaPorIdMuyLigero(int id, TextBox TextBox_Nom)
        {
            try
            {
                EntregaBinding binding = new EntregaBinding();
                DameEntregaPorId consulta = new DameEntregaPorId(id);
                IBinderEntrega linker = new BinderEntregaMuyLigero(TextBox_Nom);

                binding.VincularDameEntrega(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
