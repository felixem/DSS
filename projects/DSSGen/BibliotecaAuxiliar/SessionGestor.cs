using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;

namespace BibliotecaAuxiliar
{
    public class MySession
    {
        // private constructor
        private MySession()
        {
        }

        // Obtener la sesión actual.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // Propiedades de sesión
        public Object usuario { get; set; }
        public DateTime MyDate { get; set; }
        public int LoginId { get; set; }
    }
}
