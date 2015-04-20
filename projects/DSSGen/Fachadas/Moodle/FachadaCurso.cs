using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;

namespace Fachadas.Moodle
{
    //Fachada para la clase Curso
    public class FachadaCurso
    {
        //Vincular a un DropDownList todos los cursos
        public void VincularDameTodos(DropDownList drop)
        {
            CursoBinding curso = new CursoBinding();
            DameTodosCurso consulta = new DameTodosCurso();
            BinderListaCursoDropDownList binder = new BinderListaCursoDropDownList(drop);
            long total;
            curso.VincularDameTodos(consulta, binder, 0, -1, out total);
        }

        //Vincular a un GridView todas los cursos
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            CursoBinding curso = new CursoBinding();
            DameTodosCurso consulta = new DameTodosCurso();
            BinderListaCursoGrid binder = new BinderListaCursoGrid(grid);
            curso.VincularDameTodos(consulta, binder, first, size, out numElements);
        }

        //Método para crear un curso en la BD
        public bool CrearCurso(string p_cod_curso, string p_nombre)
        {
            try
            {
                CursoCP cp = new CursoCP();
                cp.CrearCurso(p_cod_curso,p_nombre);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para modificar un curso en la BD
        public bool ModificarCurso(int p_oid, string p_cod_curso, string p_nombre)
        {
            try
            {
                CursoCP cp = new CursoCP();
                cp.ModificarCurso(p_oid,p_cod_curso,p_nombre);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar un curso en la BD
        public bool BorrarCurso(int id)
        {
            try
            {
                CursoCP cp = new CursoCP();
                cp.BorrarCurso(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
