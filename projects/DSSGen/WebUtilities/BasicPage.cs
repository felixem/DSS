using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace WebUtilities
{
    //Clase que representa la base para las páginas aspx, que deberán heredar de ella
    //y que realiza tareas de todas ellas
    public partial class BasicPage : Page
    {
        //Manejador una vez se han inicializado las variables de la página
        protected void Page_InitComplete(object sender, EventArgs e)
        {
            //Comprobar los permisos de acceso
            GestorPermisos gestor = GestorPermisos.Create;
            gestor.ComprobarPermisos(Response, Request, MySession.Current);
        }
    }
}
