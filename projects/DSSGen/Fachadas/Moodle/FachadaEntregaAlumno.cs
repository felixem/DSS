using System;
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
            entregaAlumno = -1;

            try
            {
                Uploader uploader = new Uploader(Server, FileUploadControl);

                //Comprobar las precondiciones del archivo
                if (!uploader.ComprobarPrecondicionesSubidaAlumno(StatusLabel))
                    throw new Exception(StatusLabel.Text);

                //Inicializar las variables
                HttpPostedFile file = FileUploadControl.PostedFile;
                string nombreFichero = Path.GetFileNameWithoutExtension(file.FileName);
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
                    new DameEvaluacionAlumnoPorAlumnoYEntrega(email, idEntrega);

                //Crear la entrega de prácticas en la base de datos
                EntregaAlumnoCP cp = new EntregaAlumnoCP();
                entregaAlumno = cp.CrearEntregaAlumno(uploader, nombreFichero, extension, ruta, tam, fecha_entrega,
                    nota, corregido, comentarioAlumno, comentarioProfesor, idEntrega, consulta);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: La entrega no pudo ser realizada. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("La entrega ha sido realizada");
            return true;

        }

        //Modificar la entrega de la práctica del alumno
        public bool ModificarEntregaPractica(int idEntrega, HttpServerUtility Server,
            FileUpload FileUploadControl, Label StatusLabel, TextBox TextBox_Comentario)
        {
            try
            {
                Uploader uploader = new Uploader(Server, FileUploadControl);

                //Comprobar las precondiciones del archivo
                if (!uploader.ComprobarPrecondicionesSubidaAlumno(StatusLabel))
                    throw new Exception(StatusLabel.Text);

                //Inicializar las variables
                HttpPostedFile file = FileUploadControl.PostedFile;
                string nombreFichero = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = System.IO.Path.GetExtension(nombreFichero);
                string ruta = "";
                float tam = file.ContentLength;
                DateTime? fecha_entrega = DateTime.Now;
                float nota = 0;
                bool corregido = false;
                string comentarioAlumno = TextBox_Comentario.Text;
                string comentarioProfesor = "";

                //Crear la entrega de prácticas en la base de datos
                EntregaAlumnoCP cp = new EntregaAlumnoCP();
                cp.ModificarEntregaAlumno(uploader, nombreFichero, extension, ruta, tam, fecha_entrega,
                    nota, corregido, comentarioAlumno, comentarioProfesor, idEntrega);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: La entrega no pudo ser modificada. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("La entrega ha sido modificada");
            return true;

        }


        //Vincular a un gridview los controles pertenecientes a una entrega con paginación
        public void VincularDameTodosPorEntrega(int idEntrega, GridView grid,
            int first, int size, out long numAlumnos)
        {
            //Obtener entregas y enlazar sus datos con el gridview
            EntregaAlumnoBinding Bind = new EntregaAlumnoBinding();
            IDameTodosEntregaAlumno consulta = new DameTodosEntregaAlumnoPorEntrega(idEntrega);
            BinderListaEntregaAlumnoGrid binder = new BinderListaEntregaAlumnoGrid(grid);

            Bind.VincularDameTodos(consulta, binder, first, size, out numAlumnos);
        }

        //Método para vincular un entrega a partir de su id a textboxes
        public bool VincularEntregaAlumnoPorIdLigero(int id, TextBox TextBox_Cod, TextBox TextBox_NomAlu,
            TextBox TextBox_ApeAlu, TextBox TextBox_Dni, TextBox TextBox_ComentAlu, CheckBox CheckBox_Corregido)
        {
            try
            {
                EntregaAlumnoBinding binding = new EntregaAlumnoBinding();
                DameEntregaAlumnoPorId consulta = new DameEntregaAlumnoPorId(id);
                IBinderEntregaAlumno linker = new BinderEntregaAlumnoLigero(TextBox_Cod,
                    TextBox_NomAlu, TextBox_ApeAlu, TextBox_Dni,
                    TextBox_ComentAlu, CheckBox_Corregido);

                binding.VincularDameEntregaAlumno(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para vincular un entrega a partir de su id a textboxes
        public bool VincularEntregaAlumnoPorId(int id, TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertu, TextBox TextBox_Cierre, TextBox TextBox_Punt,
            TextBox TextBox_ComentarioAlumno, TextBox TextBox_NombreArchivo,
            Image Img_Corregido, TextBox TextBox_Nota, TextBox TextBox_ComentarioProfesor)
        {
            try
            {
                EntregaAlumnoBinding binding = new EntregaAlumnoBinding();
                DameEntregaAlumnoPorId consulta = new DameEntregaAlumnoPorId(id);
                IBinderEntregaAlumno linker = new BinderEntregaAlumnoCompleto(TextBox_Nom,
                        TextBox_Desc, TextBox_Apertu, TextBox_Cierre, TextBox_Punt,
                        TextBox_ComentarioAlumno, TextBox_NombreArchivo,
                        Img_Corregido, TextBox_Nota, TextBox_ComentarioProfesor);

                binding.VincularDameEntregaAlumno(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para vincular un entrega a partir de su id a textboxes
        public bool VincularEntregaAlumnoPorIdMuyLigero(int id, TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertu, TextBox TextBox_Cierre, TextBox TextBox_Punt,
            TextBox TextBox_Comentario)
        {
            try
            {
                EntregaAlumnoBinding binding = new EntregaAlumnoBinding();
                DameEntregaAlumnoPorId consulta = new DameEntregaAlumnoPorId(id);
                IBinderEntregaAlumno linker = new BinderEntregaAlumnoMuyLigero(TextBox_Nom,
                        TextBox_Desc, TextBox_Apertu, TextBox_Cierre, TextBox_Punt,
                        TextBox_Comentario);

                binding.VincularDameEntregaAlumno(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Metodo que modifica el Entrega en BD
        public bool CalificarEntrega(int p_oid, float nota, string comentario, bool corregido)
        {
            try
            {
                EntregaAlumnoCP cp = new EntregaAlumnoCP();
                cp.CalificarEntrega(p_oid, nota, comentario, corregido);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: La entrega no ha podido ser calificada. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("La entrega ha sido calificada");
            return true;
        }

        //Método que obtiene el nombre del fichero y la extensión a partir de la id de la entrega
        public bool ObtenerDatosFichero(int idEntregaAlumno, out string nombre, out string extension)
        {
            nombre = "";
            extension = "";

            try
            {
                //Obtener entrega
                EntregaAlumnoCP cp = new EntregaAlumnoCP();
                DameEntregaAlumnoPorId consulta = new DameEntregaAlumnoPorId(idEntregaAlumno);
                EntregaAlumnoEN entrega = cp.DameEntregaAlumno(consulta);

                nombre = entrega.Nombre_fichero;
                extension = entrega.Extension;

            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification(
                    "ERROR: Los datos del fichero no pudieron ser recuperados. " + ex.Message);
                return false;
            }

            return true;
        }

    }
}
