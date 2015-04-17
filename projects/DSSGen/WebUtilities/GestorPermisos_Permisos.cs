using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.EN.Moodle;

namespace WebUtilities
{
    //Gestor de permisos de acceso para las páginas
    public partial class GestorPermisos
    {
        //Clase que representa un nivel de permiso
        private class Permiso
        {
            //Indica si se necesita nivel de login
            private bool needLogin;
            //Listado de clases permitidas
            private List<Type> rolesPermitidos;

            //Constructor a partir de un booleano para la necesidad de login y las clases de los roles permitidos
            public Permiso(bool login, params Type[] roles)
            {
                needLogin = login;

                //Instanciar los roles permitidos
                if (login.Equals(true))
                {
                    rolesPermitidos = new List<Type>();

                    //Añadir roles
                    foreach (Type t in roles)
                        rolesPermitidos.Add(t);
                }
            }

            //Comprobar permisos
            public bool ComprobarPermisos(MySession sesion)
            {
                //Si no se necesita login se permite el acceso directamente
                if (!needLogin)
                    return true;

                //Comprobar que el usuario de la sesion está logueado
                if (!sesion.IsLoged())
                    return false;

                //Comprobar si alguno de los roles permitidos coincide
                Type tipoUs = sesion.Usuario.GetType();
                foreach (Type rol in rolesPermitidos)
                {
                    if (rol.IsAssignableFrom(tipoUs))
                        return true;
                }

                //Devolver false si ningún rol concuerda
                return false;
            }
        }
    }
}
