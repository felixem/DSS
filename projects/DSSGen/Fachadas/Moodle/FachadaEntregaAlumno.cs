﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

using ComponentesProceso.Moodle;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;
using WebUtilities;

namespace Fachadas.Moodle
{
    //Fachada para las entregas de un alumno
    public class FachadaEntregaAlumno
    {
        //Gestionar la subida provisional de un fichero
        public bool EntregarPractica(int idEntrega, MySession session, HttpServerUtility Server, 
            FileUpload FileUploadControl, Label StatusLabel, TextBox TextBox_Comentario, out int entregaAlumno)
        {
            Uploader uploader = new Uploader(Server, FileUploadControl);
            entregaAlumno = -1;

            //Comprobar las precondiciones del archivo
            if (!uploader.ComprobarPrecondicionesSubidaAlumno(StatusLabel))
                return false;

            //Inicializar las variables
            HttpPostedFile file = FileUploadControl.PostedFile;
            string nombreFichero = file.FileName;
            string extension = System.IO.Path.GetExtension(nombreFichero);
            string ruta = "";
            float tam = file.ContentLength;
            DateTime? fecha_entrega = DateTime.Now;
            float nota = 0;
            bool corregido = false;
            string comentarioAlumno = TextBox_Comentario.Text;
            string comentarioProfesor = "";

            //Crear método de consulta para obtener la EvaluacionAlumno a partir de un alumno y un control
            string email = session.Usuario.Email;
            DameEvaluacionAlumnoPorAlumnoYEntrega consulta = 
                new DameEvaluacionAlumnoPorAlumnoYEntrega(email,idEntrega);

            //Crear la entrega de prácticas en la base de datos
            EntregaAlumnoCP cp = new EntregaAlumnoCP();
            entregaAlumno = cp.CrearEntregaAlumno(uploader, nombreFichero, extension, ruta, tam, fecha_entrega, 
                nota, corregido, comentarioAlumno, comentarioProfesor, idEntrega, consulta);

            return true;

        }
        
    }
}