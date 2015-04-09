using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    //Fachada para la clase AnyoAcademico
    public class FachadaAnyoAcademico
    {
        //Vincular a un DropDownList todos los años académicos
        public void VincularDameTodos(DropDownList drop)
        {
            AnyoAcademicoBinding anyo = new AnyoAcademicoBinding();
            DameTodosAnyoAcademico consulta = new DameTodosAnyoAcademico();
            long total;
            anyo.VincularDameTodos(consulta, drop, 0, -1, out total);
        }

        //Vincular a un GridView todos los años académicos
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            AnyoAcademicoBinding anyo = new AnyoAcademicoBinding();
            DameTodosAnyoAcademico consulta = new DameTodosAnyoAcademico();
            anyo.VincularDameTodos(consulta, grid, first, size, out numElements);
        }

        //Método para crear un año académico en la BD
        public bool CrearAnyoAcademico(int anyo, DateTime? fecha_inicio, DateTime? fecha_fin, bool finalizado)
        {
            try
            {
                AnyoAcademicoCP cp = new AnyoAcademicoCP();
                cp.CrearAnyoAcademico(anyo,fecha_inicio,fecha_fin,finalizado);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para obtener un año académico a partir de su id
        public AnyoAcademicoEN DameAnyoAcademicoPorId(int id)
        {
            AnyoAcademicoEN anyo = null;
            AnyoAcademicoCP cp = new AnyoAcademicoCP();
            DameAnyoAcademicoPorId consulta = new DameAnyoAcademicoPorId(id);

            anyo = cp.DameAnyoAcademico(consulta);

            if (anyo == null)
                throw new Exception("Año académico no encontrado");

            return anyo;
        }

        //Método para modificar un año académico en la BD
        public bool ModificarAnyoAcademico(int oid, int anyo, DateTime? fecha_inicio,
            DateTime? fecha_fin, bool finalizado)
        {
            try
            {
                AnyoAcademicoCP cp = new AnyoAcademicoCP();
                cp.ModificarAnyoAcademico(oid,anyo,fecha_inicio,fecha_fin,finalizado);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un año académico de la BD
        public bool BorrarAnyoAcademico(int id)
        {
            try
            {
                AnyoAcademicoCP cp = new AnyoAcademicoCP();
                cp.BorrarAnyoAcademico(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
