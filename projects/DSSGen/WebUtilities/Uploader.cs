using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;

namespace WebUtilities
{
    //Clase utilizada para gestionar la lógica de la subida de ficheros
    public class Uploader
    {
        //Variables privadas estáticas
        private static string[] matchExtension = { ".rar", ".zip"};
        private static string[] matchMimeType = { "application/x-rar-compressed", "application/octet-stream", 
                                                    "application/zip", "application/x-zip-compressed",
                                                "multipart/x-zip", "application/x-rar"};
        private int maxKBytes = 20 * 1024;

        //Variables privadas de instancia
        HttpServerUtility Server;
        FileUpload FileUploadControl;

        //Constructor a partir de parámetros
        public Uploader(HttpServerUtility Server, FileUpload FileUploadControl)
        {
            this.Server = Server;
            this.FileUploadControl = FileUploadControl;
        }

        //Comprobar que se trata de un archivo comprimido
        private bool IsArchivoComprimido(HttpPostedFile file)
        {
            string fileName = file.FileName;
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string fileMimeType = file.ContentType;

            string type = file.ContentType.ToLower();
            return (matchExtension.Contains(fileExtension) && matchMimeType.Contains(fileMimeType));
        }

        //Comprobar que no exceda el máximo tamaño para un archivo individual
        private bool IsTamanyoAceptable(HttpPostedFile file)
        {
            int fileLengthInKB = file.ContentLength / 1024;
            return fileLengthInKB <= maxKBytes;
        }

        //Comprobar precondiciones de subida
        public bool ComprobarPrecondicionesSubidaAlumno(Label StatusLabel)
        {
            //Archivo subido
            if (FileUploadControl.HasFile)
            {
                try
                {
                    //Comprobar que es un archivo comprimido
                    if (this.IsArchivoComprimido(FileUploadControl.PostedFile))
                    {
                        //Tamaño máximo de la imagen
                        if (this.IsTamanyoAceptable(FileUploadControl.PostedFile))
                        {
                            StatusLabel.Text = "Estado de subida: Esperando Confirmación";
                            return true;
                        }
                        else
                            //El archivo subido es demasiado pesado
                            StatusLabel.Text = "Estado de subida: El archivo debe pesar menos que 20Mb!";
                    }
                    else
                        //El archivo de subida no tiene la extensión correcta
                        StatusLabel.Text = "Estado de subida: Sólo se aceptan archivos comprimidos .ZIP y .RAR";
                }
                catch (Exception ex)
                {
                    //Error de subida
                    StatusLabel.Text = "Estado de subida: El archivo no pudo ser subido. Ocurrió el siguiente error: " + ex.Message;
                }
            }

            else
                //Ningún fichero subido
                StatusLabel.Text = "Estado de subida: No se seleccionó ningún fichero ";

            return false;
        }

        //Subir al servidor físicamente la entrega del alumno a partir de una id de entrega
        public string SubirEntregaAlumno(int id, string extension)
        {
            string ruta = ResourceFinder.DirectorioEntregas() + id.ToString() + extension;
            FileUploadControl.SaveAs(Server.MapPath(ruta));

            return ruta;
        }

        //Borrar del servidor físicamente la entrega del alumno a partir de una id de entrega
        public void BorrarEntregaAlumno(int id, string extension)
        {
            string ruta = ResourceFinder.DirectorioEntregas() + id.ToString() + extension;
            string file = Server.MapPath(ruta);
            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
        }
    }
}
