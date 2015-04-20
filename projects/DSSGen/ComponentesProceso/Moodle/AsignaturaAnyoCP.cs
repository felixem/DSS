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
    //Componente de proceso para la asignatura-anyo
    public class AsignaturaAnyoCP : BasicCP
    {
        //Constructor
        public AsignaturaAnyoCP() : base() { }

        //Constructor con sesión
        public AsignaturaAnyoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de asignaturas-anyo que satisfacen la consulta
        public System.Collections.Generic.IList<AsignaturaAnyoEN> DameTodosTotal(IDameTodosAsignaturaAnyo consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AsignaturaAnyoEN> lista = null;
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

        //Crear una asignatura-anyo devolver su id de creación
        public int CrearAsignaturaAnyo(int idAnyo, int idAsignatura)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();

                AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);

                //Comprobar si existe previamente una relación entre la asignatura y el año
                AsignaturaAnyoEN asig = cen.ReadRelation(idAsignatura, idAnyo);
                if (asig != null)
                    throw new Exception("Relación ya existente");

                //Crear la asignatura-anyo
                id = cen.New_(idAnyo,idAsignatura);

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

        //Devolver el resultado de una consulta individual sobre una asignatura-anyo
        public AsignaturaAnyoEN DameAsignaturaAnyo(IDameAsignaturaAnyo consulta)
        {
            AsignaturaAnyoEN asignaturaAnyo = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                asignaturaAnyo = consulta.Execute(session);

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

            return asignaturaAnyo;
        }

        //Modificar asignatura-anyo
        public void ModificarAsignaturaAnyo(int oid)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);
                //Ejecutar la modificación
                cen.Modify(oid);

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

        //Borrar asignatura-anyo a partir de su id
        public void BorrarAsignaturaAnyo(int id)
        {
            try
            {
                SessionInitializeTransaction();

                AsignaturaAnyoCAD cad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN cen = new AsignaturaAnyoCEN(cad);
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

        //Método para matricular un alumno en una asignatura anyo
        public void MatricularAlumno(int codAlumno, int idAsig)
        {
            try
            {
                SessionInitializeTransaction();

                //Obtener alumno
                AlumnoCAD aluCad = new AlumnoCAD(session);
                AlumnoCEN aluCen = new AlumnoCEN(aluCad);
                AlumnoEN alu = aluCen.ReadCod(codAlumno);

                if (alu == null)
                    throw new Exception("No se encontró el alumno");

                //Obtener expediente del alumno
                ExpedienteCAD expCad = new ExpedienteCAD(session);
                ExpedienteCEN expCen = new ExpedienteCEN(expCad);
                ExpedienteEN exp = expCen.ReadRelation(alu.Email);

                if (exp == null)
                    throw new Exception("No se encontró el expediente del Alumno");

                //Obtener la asignatura
                AsignaturaAnyoCAD asigCad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN asigCen = new AsignaturaAnyoCEN(asigCad);
                AsignaturaAnyoEN asig = asigCen.ReadOID(idAsig);

                if (asig == null)
                    throw new Exception("No se encontró la asignatura");

                //Obtener la id del Año académico
                int anyo = asig.Anyo.Id;

                //Obtener el expediente del alumno para el año académico
                ExpedienteAnyoCAD expAnyoCad = new ExpedienteAnyoCAD(session);
                ExpedienteAnyoCEN expAnyoCen = new ExpedienteAnyoCEN(expAnyoCad);
                ExpedienteAnyoEN expAnyo = expAnyoCen.ReadRelation(exp.Id, anyo);

                if (expAnyo == null)
                    throw new Exception("No se encontró el expediente del alumno para el año académico");

                //Comprobar que no exista matriculación todavía
                ExpedienteAsignaturaCAD expAsigCad = new ExpedienteAsignaturaCAD(session);
                ExpedienteAsignaturaCEN expAsigCen = new ExpedienteAsignaturaCEN(expAsigCad);
                ExpedienteAsignaturaEN expAsig = expAsigCen.ReadRelation(asig.Id, expAnyo.Id);

                if (expAsig != null)
                    throw new Exception("El alumno ya está matriculado en la asignatura");

                //Ejecutar la matriculación
                expAsigCen.New_(0, true, expAnyo.Id, asig.Id);

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

        //Método para matricular un alumno en una asignatura anyo
        public void DesmatricularAlumno(int codAlumno, int idAsig)
        {
            try
            {
                SessionInitializeTransaction();

                //Obtener alumno
                AlumnoCAD aluCad = new AlumnoCAD(session);
                AlumnoCEN aluCen = new AlumnoCEN(aluCad);
                AlumnoEN alu = aluCen.ReadCod(codAlumno);

                if (alu == null)
                    throw new Exception("No se encontró el alumno");

                //Obtener expediente del alumno
                ExpedienteCAD expCad = new ExpedienteCAD(session);
                ExpedienteCEN expCen = new ExpedienteCEN(expCad);
                ExpedienteEN exp = expCen.ReadRelation(alu.Email);

                if (exp == null)
                    throw new Exception("No se encontró el expediente del Alumno");

                //Obtener la asignatura
                AsignaturaAnyoCAD asigCad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN asigCen = new AsignaturaAnyoCEN(asigCad);
                AsignaturaAnyoEN asig = asigCen.ReadOID(idAsig);

                if (asig == null)
                    throw new Exception("No se encontró la asignatura");

                //Obtener la id del Año académico
                int anyo = asig.Anyo.Id;

                //Obtener el expediente del alumno para el año académico
                ExpedienteAnyoCAD expAnyoCad = new ExpedienteAnyoCAD(session);
                ExpedienteAnyoCEN expAnyoCen = new ExpedienteAnyoCEN(expAnyoCad);
                ExpedienteAnyoEN expAnyo = expAnyoCen.ReadRelation(exp.Id, anyo);

                if (expAnyo == null)
                    throw new Exception("No se encontró el expediente del alumno para el año académico");

                //Comprobar que no exista matriculación todavía
                ExpedienteAsignaturaCAD expAsigCad = new ExpedienteAsignaturaCAD(session);
                ExpedienteAsignaturaCEN expAsigCen = new ExpedienteAsignaturaCEN(expAsigCad);
                ExpedienteAsignaturaEN expAsig = expAsigCen.ReadRelation(asig.Id, expAnyo.Id);

                if (expAsig == null)
                    throw new Exception("El alumno no está matriculado en la asignatura");

                //Ejecutar la desmatriculación
                expAsigCen.Destroy(expAsig.Id);

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
