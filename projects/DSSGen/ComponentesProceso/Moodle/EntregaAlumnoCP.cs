﻿using System;
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
                    throw new Exception("No se encontró la Evaluación del Alumno");

                //Registrar la entrega en la BD
                EntregaAlumnoCAD cad = new EntregaAlumnoCAD(session);
                EntregaAlumnoCEN cen = new EntregaAlumnoCEN(cad);
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
    }
}