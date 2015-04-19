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
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string fileName = request.QueryString[PageParameters.DescargaEntregaAlumno];

            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
            response.ClearContent();
            response.Clear();
            response.ContentType = "text/plain";
            response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ";");
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