using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUtilities;

namespace DSSGenNHibernate.Download
{
    /// <summary>
    /// Summary description for DownloadFile1
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

            //Construir el path del fichero
            string nombreFichero = "";
            string extension = "";

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + nombreFichero + ";");
            response.TransmitFile(context.Server.MapPath("FileDownload.csv"));
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