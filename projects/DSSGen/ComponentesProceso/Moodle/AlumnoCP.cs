﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using ComponentesProceso.Moodle.Commands;

namespace ComponentesProceso.Moodle
{
    public class AlumnoCP : BasicCP
    {
         //Constructor
        public AlumnoCP() : base() { }

        //Constructor con sesión
        public AlumnoCP(ISession sesion) : base(sesion) { }

        //Registra el alumno en la BD y de
        public string CrearAlumno(string nombre, string apellidos, string pass, DateTime fecha, string dni, string email, int cod,
            string codExpediente, bool expedienteAbierto)
        {
            string resultado;

            try
            {
                SessionInitializeTransaction();

                //Creo el alumno
                AlumnoCAD cad = new AlumnoCAD(session);
                AlumnoCEN cen = new AlumnoCEN(cad); 
           
                //Comprobar si ya está registrado el email
                if (cen.ReadOID(email) != null)
                    throw new Exception("El email ya está registrado");

                //Comprobar si el código ya está registrado
                if (cen.ReadCod(cod) != null)
                    throw new Exception("El código de alumno ya está registrado");

                //Comprobar si el dni ya está registrado
                UsuarioCAD userCad = new UsuarioCAD(session);
                UsuarioCEN userCen = new UsuarioCEN(userCad);

                //Comprobar si el dni está registrado
                if (userCen.ReadDni(dni) != null)
                    throw new Exception("El dni ya está registrado");

                //Comprobar si existe el expediente
                ExpedienteCAD expCad = new ExpedienteCAD(session);
                ExpedienteCEN expCen = new ExpedienteCEN(expCad);
                if (expCen.ReadCod(codExpediente) != null)
                    throw new Exception("El código de expediente ya está registrado");

                //Crear el expediente vacío a partir del código
                ExpedienteEN expediente = new ExpedienteEN();
                expediente.Cod_expediente = codExpediente;
                expediente.Abierto = expedienteAbierto;

                resultado = cen.New_(cod, false, email, dni, pass, nombre, apellidos, fecha, expediente);

                SessionCommit();
            }
            catch (Exception e)
            {
                SessionRollBack();
                throw e;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
            return resultado;
        }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de alumnos que satisfacen la consulta
        public System.Collections.Generic.IList<AlumnoEN> DameTodosTotal(IDameTodosAlumno consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AlumnoEN> lista = null;
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

        //Devolver el resultado de una consulta individual sobre un alumno
        public AlumnoEN DameAlumno(IDameAlumno consulta)
        {
            AlumnoEN alu = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                alu = consulta.Execute(session);

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

            return alu;
        }

        //Modificar alumno sin modificar su contraseña
        public void ModificarAlumnoNoPassword(string email,int codAlumno, bool baneado, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                SessionInitializeTransaction();

                AlumnoCAD cad = new AlumnoCAD(session);
                AlumnoCEN cen = new AlumnoCEN(cad);

                AlumnoEN actual = cen.ReadOID(email);
                if (actual == null)
                    throw new Exception("El alumno no existe");

                //Comprobar si el código cambia pero ya está registrado
                if (codAlumno != actual.Cod_alumno && cen.ReadCod(codAlumno) != null)
                    throw new Exception("El código de alumno ya está registrado");

                //Comprobar si el dni ya está registrado
                UsuarioCAD userCad = new UsuarioCAD(session);
                UsuarioCEN userCen = new UsuarioCEN(userCad);

                //Comprobar si el dni está registrado
                if (dni != actual.Dni && userCen.ReadDni(dni) != null)
                    throw new Exception("El dni ya está registrado");
    
                //Ejecutar la modificación
                cen.ModifyNoPassword(email,codAlumno,baneado,dni,nombre,apellidos, fechaNacimiento);

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

        //Borrar alumno a partir de su código de alumno
        public void BorrarAlumno(int codAlumno)
        {
            try
            {
                SessionInitializeTransaction();

                AlumnoCAD cad = new AlumnoCAD(session);
                AlumnoCEN cen = new AlumnoCEN(cad); 
   
                //Recuperar datos del alumno
                AlumnoEN alu = cen.ReadCod(codAlumno);
                if (alu == null)
                    throw new Exception("El alumno no existe");

                //Ejecutar la modificación
                cen.Destroy(alu.Email);

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
