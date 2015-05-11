using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CAD.Moodle;
using WebUtilities;

namespace ComponentesProceso.Moodle
{
    public class EntregaAlumnoCP : BasicCP
    {
        //Constructor
        public EntregaAlumnoCP() : base() { }

        //Constructor con sesión
        public EntregaAlumnoCP(ISession sesion) : base(sesion) { }
        
        //Crear entrega de prácticas de un alumno
        public int CrearEntregaAlumno(Uploader Uploader, String p_nombre_fichero, String p_extension, String p_ruta,
            float p_tam,DateTime? p_fecha_entrega, float p_nota, bool p_corregido, String p_comentario_alumno, 
            String p_comentario_profesor, int p_entrega, IDameEvaluacionAlumno consulta)
        {
            int entregaAlumno=-1;

            try
            {
                SessionInitializeTransaction();

                //Obtener el objeto EvaluacionAlumno correspondiente
                EvaluacionAlumnoEN eval = consulta.Execute(session);
                if (eval == null)
                    throw new Exception("La evaluación del alumno no existe");

                //Comprobar si existe la entrega propuesta
                EntregaCAD entregaCad = new EntregaCAD(session);
                EntregaCEN entregaCen = new EntregaCEN(entregaCad);
                if (entregaCen.ReadOID(p_entrega) == null)
                    throw new Exception("La entrega propuesta no existe");

                EntregaAlumnoCAD cad = new EntregaAlumnoCAD(session);
                EntregaAlumnoCEN cen = new EntregaAlumnoCEN(cad);
                //Comprobar la existencia de una entrega previa
                if (cen.ReadRelation(eval.Id, p_entrega) != null)
                    throw new Exception("El alumno ya realizó la entrega de esta práctica");
                
                //Registrar la entrega en la BD
                entregaAlumno = cen.New_(p_nombre_fichero,p_extension,p_ruta,p_tam,p_fecha_entrega, p_nota,
                    p_corregido, p_comentario_alumno, p_comentario_profesor, p_entrega, eval.Id);

                //Subir el archivo al directorio físico
                p_ruta = Uploader.SubirEntregaAlumno(entregaAlumno,p_extension);

                //Establecer la ruta en la entrega
                cen.Modify(entregaAlumno, p_nombre_fichero, p_extension, p_ruta, p_tam, p_fecha_entrega, p_nota,
                    p_corregido, p_comentario_alumno, p_comentario_profesor);

                SessionCommit();
            }
            catch (Exception e)
            {
                SessionRollBack();

                //Borrar la entrega en caso de error
                Uploader.BorrarEntregaAlumno(entregaAlumno,p_extension);

                throw e;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
            return entregaAlumno;
        }

        //Modificar entrega de prácticas de un alumno
        public void ModificarEntregaAlumno(Uploader Uploader, String p_nombre_fichero, String p_extension, String p_ruta,
            float p_tam, DateTime? p_fecha_entrega, float p_nota, bool p_corregido, String p_comentario_alumno,
            String p_comentario_profesor, int p_entrega)
        {
            try
            {
                SessionInitializeTransaction();

                //Comprobar si existe la entrega propuesta
                EntregaAlumnoCAD entregaCad = new EntregaAlumnoCAD(session);
                EntregaAlumnoCEN entregaCen = new EntregaAlumnoCEN(entregaCad);
                if (entregaCen.ReadOID(p_entrega) == null)
                    throw new Exception("La entrega del alumno no existe");

                //Modificar el archivo al directorio físico
                p_ruta = Uploader.ModificarEntregaAlumno(p_entrega, p_extension);

                //Establecer la ruta en la entrega
                entregaCen.Modify(p_entrega, p_nombre_fichero, p_extension, p_ruta, p_tam, p_fecha_entrega, 
                    p_nota, p_corregido, p_comentario_alumno, p_comentario_profesor);

                //Borrar la copia provisional de la entrega
                Uploader.BorrarCopiaProvisional(p_entrega, p_extension);

                SessionCommit();
            }
            catch (Exception e)
            {
                SessionRollBack();

                //Borrar la entrega en caso de error
                Uploader.RecuperarEntregaAlumno(p_entrega, p_extension);

                throw e;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de Entrega que satisfacen la consulta
        public System.Collections.Generic.IList<EntregaAlumnoEN> DameTodosTotal(IDameTodosEntregaAlumno consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<EntregaAlumnoEN> lista = null;
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

        //Devolver el resultado de una consulta individual sobre un Control
        public EntregaAlumnoEN DameEntregaAlumno(IDameEntregaAlumno consulta)
        {
            EntregaAlumnoEN en = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                en = consulta.Execute(session);

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

            return en;
        }

        //Modifica el entrega en la BD
        public void CalificarEntrega(int p_oid, float nota, string comentario, bool corregido)
        {
            try
            {
                SessionInitializeTransaction();

                EntregaAlumnoCAD cad = new EntregaAlumnoCAD(session);
                EntregaAlumnoCEN cen = new EntregaAlumnoCEN(cad);

                EntregaAlumnoEN en = cen.ReadOID(p_oid);
                //Comprobar la existencia de la entrega
                if (en == null)
                    throw new Exception("La entrega del alumno no existe");

                //Ejecutar la modificación
                cen.Modify(p_oid,en.Nombre_fichero,en.Extension,en.Ruta,en.Tam,en.Fecha_entrega,nota,corregido,en.Comentario_alumno,comentario);

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
