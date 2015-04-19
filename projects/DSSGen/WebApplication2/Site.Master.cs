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
                lnk_desloguear.Visible = true;
                lnk_cambiar_pass.Visible = true;
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
                lnk_desloguear.Visible = false;
                lnk_cambiar_pass.Visible = false;
                mv_barra.ActiveViewIndex = 0;
            }
        }

        //Manejador para efectuar el deslogueo
        protected void lnk_desloguear_Click(object sender, EventArgs args)
        {

            Fachadas.Moodle.FachadaLogin fachada= new Fachadas.Moodle.FachadaLogin();
            fachada.Exit();

            Linker link = new Linker(false);
            link.Redirect(Response, link.Default());
        }

        //Evento para ir a la página para cambiar contraseña
        protected void lnk_cambiar_pass_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ChangePassword());
        }

        //Evento para ir a la pagina de inicio
        protected void lnk_inicio_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Default());
        }

        //Evento que redireciona a la pagina del login
        protected void lnk_login_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Login());
        }

        //Evento que redirecciona a la página de gestión de alumnos
        protected void lnk_alumnos_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Alumnos());
        }

        //Evento que redirecciona a la página de gestión de profesores
        protected void lnk_profesores_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Profesores());
        }

        //Evento que redirecciona a la página de gestión de asignaturas
        protected void lnk_asignaturas_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.Asignaturas());
        }

        //Evento que redirecciona a la página de gestión de examenes
        protected void lnk_examenes_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ListadoBolsaPreguntas());
        }

        //Evento que redirecciona a la página de gestión de grupos de trabajo
        protected void lnk_grupos_trabajo_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.GruposTrabajo());
        }

        //Evento que redirecciona a la página de lista de asignaturas en el contexto del alumno
        protected void lnk_asignaturas_alumno_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ListarAsignaturasAnyoDeAlumno());
        }

        //Evento que redirecciona a la página con la lista de los controles
        protected void lnk_controles_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ListarControles());
        }

        //Evento que redirecciona a la lista de entregas
        protected void lnk_entregas_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ListarEntregas());
        }

        //Evento que redirecciona a la lista de asignaturas impartidas
        protected void lnk_plan_estudio_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.AsignaturasImpartidas());
        }

        protected void lnk_asignaturas_impartidas_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.MisAsignaturasImpartidas());
        }

        protected void lnk_evaluacion_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.ListarEvaluaciones());
        }
    }
}
