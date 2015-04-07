﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Alumno
{
    public partial class modificar_alumno : System.Web.UI.Page
    {
        FachadaAlumno fachada;
        private int id;
        String param;
        AlumnoEN alumno;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada = new FachadaAlumno();
            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Procesar parámetros
                this.Procesar_Parametros();
                //Cargar datos
                this.CargarDatos();

                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Comprobar si se plantea operación de modificación
        private void Obtener_Parametros()
        {
            param = Request.QueryString[PageParameters.MainParameter];
            //Lanzar excepción no se ha recibido un parámetro
            if (param == null)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
                id = Int32.Parse(param);
        }

        //Comprobar parámetros
        private void Procesar_Parametros()
        {
            //Recuperar los datos del alumno
            try
            {
                alumno = fachada.DameAlumno(id);
            }
            catch (Exception)
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }


        //Cargar los datos del alumno original
        private void CargarDatos()
        {
            //Cargar todos los datos del alumno
            UsuarioEN usuario = alumno as UsuarioEN;
            TextBox_NomAlu.Text = usuario.Nombre;
            TextBox_ApellAlu.Text = usuario.Apellidos;
            TextBox_NaciAlu.Text = usuario.Fecha_nacimiento.ToString();
            TextBox_DNIAlu.Text = usuario.Dni;
            TextBox_EmailAlu.Text = usuario.Email;
            TextBox_CodAlu.Text = alumno.Cod_alumno.ToString();
            CheckBox_Baneado.Checked = alumno.Baneado;
        }

        //Método que llama al botón modificar
        protected void Button_Modificar_Click(Object sender, EventArgs e)
        {
            //Recojo los datos
            string nombre = TextBox_NomAlu.Text;
            string apellidos = TextBox_ApellAlu.Text;
            DateTime? fecha = DateTime.Parse(TextBox_NaciAlu.Text);
            string dni = TextBox_DNIAlu.Text;
            string email = TextBox_EmailAlu.Text;
            int cod = Int32.Parse(TextBox_CodAlu.Text);
            bool baneado = CheckBox_Baneado.Checked;

            if (fachada.ModificarAlumnoNoPassword(email, cod, baneado, dni, nombre, apellidos, fecha))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
            else
            {
                Response.Write("<script>window.alert('El usuario no ha podido ser modificado');</script>");
            }
        }
     
        //Metodo que comprueba la fecha(Control de validacion)
        protected void ComprobarFecha(object sender,ServerValidateEventArgs e)
        {
            try
            {
                Convert.ToDateTime(e.Value);
                e.IsValid = true;
            }
            catch (Exception)
            {
                e.IsValid = false;
            }
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}