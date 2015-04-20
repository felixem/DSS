using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUtilities;
using Fachadas.Moodle;

namespace DSSGenNHibernate.Download
{
    /// <summary>
    /// Summary description for DownloadFile
    /// </summary>
    public class DownloadFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            procesarPeticionEntregaAlumno(context);
        }

        //Procesar petición de descarga
        public void procesarPeticionEntregaAlumno(HttpContext context)
        {
            //Obtener el id del fichero
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string id = request.QueryString[PageParameters.DescargaEntregaAlumno];

            //Parámetro incorrecto
            if (id == null)
                throw new HttpException(404, "File not found");

            //Obtener el nombre y la extensión del fichero original
            string nombreFichero = "";
            string extension = "";

            //Consultar en la BD por el nombre
            FachadaEntregaAlumno fachadaEntrega = new FachadaEntregaAlumno();
            if(!fachadaEntrega.ObtenerDatosFichero(Int32.Parse(id), out nombreFichero, out extension))
                throw new HttpException(404, "File not found");

            //Obtener los paths
            string pathFisicoRelativo = ResourceFinder.DirectorioEntregas() + id + extension;
            string pathFisicoAbsoluto = System.Web.HttpContext.Current.Server.MapPath(pathFisicoRelativo);
            
            //Elaborar la respuesta
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();

            //Obtener el formato mime
            response.ContentType = MimeExtensionHelper.FindMime(pathFisicoAbsoluto, true);

            response.AddHeader("Content-Disposition", "attachment; filename=" + nombreFichero + extension + ";");
            response.TransmitFile(pathFisicoRelativo);
            response.Flush();
            response.End();
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}