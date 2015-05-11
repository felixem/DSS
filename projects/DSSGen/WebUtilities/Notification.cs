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
        //Constructor privado
        private Notification()
        {
            mensajes = new Stack<string>();
        }

        // Obtener el gestor de notificaciones
        public static Notification Current
        {
            get
            {
                Notification notificacion =
                  (Notification)HttpContext.Current.Session["__Notification__"];
                if (notificacion == null)
                {
                    notificacion = new Notification();
                    HttpContext.Current.Session["__Notification__"] = notificacion;
                }
                return notificacion;
            }
        }

        //Limpiar las notificaciones
        public void Clear()
        {
            mensajes.Clear();
        }

        //Notificar mediante un messagebox de javascript un mensaje
        public static void Notify(HttpResponse Response, string message)
        {
            Response.Write("<script>window.alert('" + message + "');</script>");
        }

        //Notificar última notificación
        public void NotifyLastNotification(HttpResponse Response)
        {
            //Sacar último mensaje
            if (mensajes.Count > 0)
                Response.Write("<script>window.alert('" + mensajes.Pop() + "');</script>");
        }

        //Almacenar notificación en la pila
        public void AddNotification(string message)
        {
            mensajes.Push(message);
        }

        //Variable privada donde guardar las notificaciones
        private Stack<String> mensajes;

    }
}
