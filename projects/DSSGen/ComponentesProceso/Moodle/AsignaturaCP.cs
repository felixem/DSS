﻿using System;
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
    //Componente de proceso para la asignaturas
    public class AsignaturaCP : BasicCP
    {
        //Constructor
        public AsignaturaCP() : base() { }

        //Constructor con sesión
        public AsignaturaCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de asignatura que satisfacen la consulta
        public System.Collections.Generic.IList<AsignaturaEN> DameTodosTotal(IDameTodosAsignatura consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;
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

        //Crear una asignatura y devolver su id de creación
        public int CrearAsignatura(string codigo, string nombre, string descripcion,
            bool optativa, bool vigente, int p_curso)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear la asignatura
                AsignaturaCAD cad = new AsignaturaCAD(session);
                AsignaturaCEN cen = new AsignaturaCEN(cad);

                //Comprobar si ya existe una asignatura con ese código
                if (cen.ReadCod(codigo) != null)
                    throw new Exception("El código de la asignatura ya está registrado");

                //Comprobar si existe el curso académico
                CursoCAD cursoCad = new CursoCAD(session);
                CursoCEN cursoCen = new CursoCEN(cursoCad);

                if (cursoCen.ReadOID(p_curso) == null)
                    throw new Exception("El curso no existe");

                id = cen.New_(codigo, nombre, descripcion, optativa, vigente, p_curso);

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

        //Devolver el resultado de una consulta individual sobre una asignatura
        public AsignaturaEN DameAsignatura(IDameAsignatura consulta)
        {
            AsignaturaEN asig = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                asig = consulta.Execute(session);

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

            return asig;
        }

        //Modificar asignatura
        public void ModificarAsignatura(int oid, string codAsignatura, string nombre,
            string descripcion, bool optativa, bool vigente)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaCAD cad = new AsignaturaCAD(session);
                AsignaturaCEN cen = new AsignaturaCEN(cad);

                //Comprobar si existe la asignatura
                AsignaturaEN en = cen.ReadOID(oid);
                if (en == null)
                    throw new Exception("La asignatura no existe");

                //Comprobar si el código cambia y no entra en conflicto con otros
                if (codAsignatura != en.Cod_asignatura && cen.ReadCod(codAsignatura) != null)
                    throw new Exception("El código de la asignatura ya está registrado");

                //Ejecutar la modificación
                cen.Modify(oid,codAsignatura,nombre,descripcion,optativa,vigente);

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

        //Borrar asignatura a partir de su id
        public void BorrarAsignatura(int id)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaCAD cad = new AsignaturaCAD(session);
                AsignaturaCEN cen = new AsignaturaCEN(cad);

                //Comprobar si existe la asignatura
                if (cen.ReadOID(id) == null)
                    throw new Exception("La asignatura no existe");

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
