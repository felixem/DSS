using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso de curso
    public class CursoCP : BasicCP
    {
        //Constructor
        public CursoCP() : base() { }

        //Constructor con sesión
        public CursoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de cursos que satisfacen la consulta
        public System.Collections.Generic.IList<CursoEN> DameTodosTotal(IDameTodosCurso consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<CursoEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numElementos = consulta.Total(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return lista;
        }

        //Crear un curso y devolver su id de creación
        public int CrearCurso(string p_cod_curso, string p_nombre)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear el curso
                CursoCAD cad = new CursoCAD(session);
                CursoCEN cen = new CursoCEN(cad);
                id = cen.New_(p_cod_curso,p_nombre);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return id;
        }

        //Devolver el resultado de una consulta individual sobre un curso
        public CursoEN DameCurso(IDameCurso consulta)
        {
            CursoEN curso = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                curso = consulta.Execute(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return curso;
        }

        //Modificar curso
        public void ModificarCurso(int p_oid, string p_cod_curso, string p_nombre)
        {
            try
            {
                SessionInitializeTransaction();

                CursoCAD cad = new CursoCAD(session);
                CursoCEN cen = new CursoCEN(cad);
                //Ejecutar la modificación
                cen.Modify(p_oid,p_cod_curso,p_nombre);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }

        //Borrar curso a partir de su id
        public void BorrarCurso(int id)
        {
            try
            {
                SessionInitializeTransaction();

                CursoCAD cad = new CursoCAD(session);
                CursoCEN cen = new CursoCEN(cad);
                //Ejecutar la modificación
                cen.Destroy(id);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
