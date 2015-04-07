using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;

namespace WebUtilities
{
    public class NavigationSession
    {
        private List<String> listaUrls;
        //Variable utilizada para indicar si la página actual debe ser cacheada o no
        private bool cacheable;

        //Constructor privado
        private NavigationSession()
        {
            listaUrls = new List<string>();
            cacheable = false;
        }

        //Obtener la sesión de navegación actual
        public static NavigationSession Current
        {
            get
            {
                NavigationSession session =
                  (NavigationSession)HttpContext.Current.Session["__NavigationSession__"];
                if (session == null)
                {
                    session = new NavigationSession();
                    HttpContext.Current.Session["__NavigationSession__"] = session;
                }
                return session;
            }
        }

        //Variable utilizada para indicar si la página actual debe ser cacheada o no
        public bool Cacheable
        {
            get
            {
                //Por defecto el estado de cacheable pasa a false cuando se consulta el estado de la página anterior
                bool res = cacheable;
                cacheable = false;
                return res;
            }
            set { cacheable = value; }
        }

        //Limpiar la sesión de navegación
        public void Clear()
        {
            listaUrls.Clear();
        }

        //Añadir link a la sesión de navegación
        private void AddUrl(String url)
        {
            listaUrls.Add(url);
        }

        //Borrar la última url de la sesión de navegación
        private void DeleteLastPage()
        {
            if (listaUrls.Count == 0)
                return;

            listaUrls.RemoveAt(listaUrls.Count - 1);
        }

        //Añadir la página desde la que se accedió a la actual a la sesión si es necesario
        public void SavePreviuosPage(HttpRequest peticion)
        {
            Linker link = new Linker(false);
            if (link.OriginMustBeCatched())
                this.AddUrl(peticion.UrlReferrer.ToString());
        }

        //Obtener el último link de la sesión de navegación y borrarlo de la caché
        public String PopLastUrl()
        {
            if (listaUrls.Count == 0)
                return null;

            String str = listaUrls[listaUrls.Count - 1];
            DeleteLastPage();
            return str;
        }
    }
}
