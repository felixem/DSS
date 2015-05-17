using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;
using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.EntregaAlumno
{
    public partial class detalles_entrega_alumno : BasicPage
    {
        FachadaEntregaAlumno fachadaEntregaAlumno;
        private int id;
        String param;

        //Manejador para la carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }

            fachadaEntregaAlumno = new FachadaEntregaAlumno();
            Obtener_Parametros();

            if (!IsPostBack)
            {
                //Mostrar notificaciones recibidas
                Notification.Current.NotifyLastNotification(Response);
                //Cargar datos
                this.CargarDatos();
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

        //Comprobar parámetros y cargar datos
        private void CargarDatos()
        {
            //Recuperar los datos de la entrega
            if (!fachadaEntregaAlumno.VincularEntregaAlumnoPorId(id, TextBox_Nom,
            TextBox_Desc, TextBox_Apertu, TextBox_Cierre, TextBox_Punt,TextBox_ComentarioAlumno,
            TextBox_NombreArchivo,Img_Corregido,TextBox_Nota, TextBox_ComentarioProfesor))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Descargar_Click(object sender, EventArgs e)
        {
            //Intentar descargar el fichero
            Linker link = new Linker(false);
            link.Redirect(Response, link.DescargaEntregaPracticas(id));
        }

        //Botón uttilizado para ir a la interfaz editar
        protected void Button_Editar_Click(object sender, EventArgs e)
        {
            Linker link = new Linker(false);
            link.Redirect(Response, link.EditarEntregaAlumno(id));
        }
    }
}