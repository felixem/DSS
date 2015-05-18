using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUtilities;
using Fachadas.Moodle;
using System.Web.SessionState;

namespace DSSGenNHibernate.EntregaAlumno
{
    /// <summary>
    /// Summary description for MiEntrega
    /// </summary>
    public class MiEntrega : IRequiresSessionState , IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            obtenerPaginaMiEntrega(context);
        }

        //Procesar petición página de entrega de alumno
        public void obtenerPaginaMiEntrega(HttpContext context)
        {
            //Obtener la id de la entrega
            System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;
            string id = request.QueryString[PageParameters.MainParameter];

            //Parámetro incorrecto
            if (id == null)
                throw new HttpException(404, "Page not found");

            //Capturar la página que realizó la petición
            NavigationSession navegacion = NavigationSession.Current;
            navegacion.SavePreviuosPage(context.Request);

            //Elaborar la respuesta
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

            //Comprobar si existe la entrega del alumno
            int entrega = Int32.Parse(id);
            int idEntregaAlu = -1;
            FachadaEntregaAlumno fachadaEntrega = new FachadaEntregaAlumno();
            Linker linker = new Linker(false);

            //Redireccionar a la página correspondiente
            if(fachadaEntrega.ExisteEntregaAlumno(entrega,MySession.Current,out idEntregaAlu))
                linker.Redirect(response,linker.DetallesMiEntregaAlumno(idEntregaAlu));
            else
                linker.Redirect(response,linker.RealizarEntregaPracticas(entrega));
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