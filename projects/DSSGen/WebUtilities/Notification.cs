using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebUtilities
{
    //Clase utilizada para mostrar notificaciones
    public class Notification
    {
        //Notificar mediante un messagebox de javascript un mensaje
        public static void Notify(HttpResponse Response, string message)
        {
            Response.Write("<script>window.alert('" + message + "');</script>");
        }
    }
}
