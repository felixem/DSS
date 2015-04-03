using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;
using NHibernate;

namespace Fachadas.Moodle
{
    //Clase utilizada para abstraer el proceso de login sobre distintos roles
    public class FachadaLogin
    {
        //Método login que devuelve una referencia a un objeto que contendrá un profesor, alumno o admin
        public Object Login(String user, String pass)
        {
            LoginCP loginCP = new LoginCP();
            return loginCP.login(user, pass);
        }

    }
}
