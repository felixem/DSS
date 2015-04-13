using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DSSGenNHibernate.EN.Moodle;

using WebUtilities;

namespace WebApplication2
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        MySession sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion = MySession.Current;
            if (!IsPostBack)
            {
                VisibilidadControles();
            }
        }

        //Visibilidad de los controles
        private void VisibilidadControles()
        {
            if (sesion.IsLoged())
            {
                UsuarioEN usuario = sesion.Usuario;

                user_image.Visible = true;
                user_image.ImageUrl = ResourceFinder.FotoSession(sesion);
                user_label.Visible = true;
                user_label.Text = usuario.Nombre + " " + usuario.Apellidos;
                Button_Desloguear.Visible = true;
                //MultiView de la barra de herramientas
                if(sesion.IsAlumno())
                    mv_barra.ActiveViewIndex = 1;
                else if(sesion.IsProfesor())
                    mv_barra.ActiveViewIndex = 2;
                else if (sesion.IsAdministrador())
                    mv_barra.ActiveViewIndex = 3;
            }
            else
            {
                user_image.Visible = false;
                user_label.Visible = false;
                Button_Desloguear.Visible = false;
                mv_barra.ActiveViewIndex = 0;
            }
        }

        //Manejador para efectuar el deslogueo
        protected void Button_Desloguear_Click(object sender, EventArgs args)
        {

            Fachadas.Moodle.FachadaLogin fachada= new Fachadas.Moodle.FachadaLogin();
            fachada.Exit();

            Linker link = new Linker(false);
            link.Redirect(Response, link.Default());
        }

        //Evento para ir a la pagina de inicio
        protected void btn_inicio_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Default());
        }

        //Evento que redireciona a la pagina del login
        protected void btn_login_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Login());
        }

        //Evento que redirecciona a la página de gestión de alumnos
        protected void btn_alumnos_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Alumnos());
        }

        //Evento que redirecciona a la página de gestión de profesores
        protected void btn_profesores_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Profesores());
        }

        //Evento que redirecciona a la página de gestión de asignaturas
        protected void btn_asignaturas_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Asignaturas());
        }

        //Evento que redirecciona a la página de gestión de examenes
        protected void btn_examenes_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ListadoBolsaPreguntas());
        }

        //Evento que redirecciona a la página de gestión de grupos de trabajo
        protected void btn_grupos_trabajo_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.GruposTrabajo());
        }
    }
}
