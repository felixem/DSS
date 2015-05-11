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
    public partial class realizar_entrega : BasicPage
    {
        FachadaEntrega fachadaEntrega;
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

            fachadaEntrega = new FachadaEntrega();
            fachadaEntregaAlumno = new FachadaEntregaAlumno();
            Obtener_Parametros();

            if (!IsPostBack)
            {
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
            if (!fachadaEntrega.VincularEntregaPorIdLigero(id, TextBox_Nom,
            TextBox_Desc, TextBox_Apertu, TextBox_Cierre, TextBox_Punt))
            {
                //Redirigir a la página que le llamó
                Linker link = new Linker(false);
                link.Redirect(Response, link.PreviousPage());
            }
        }

        //Realizar Entrega
        protected void Button_Entregar_Click(object sender, EventArgs e)
        {
            int entregaAlumnoGenerada = -1;

            //Entregar la práctica
            if (fachadaEntregaAlumno.EntregarPractica
                (id, MySession.Current, Server, FileUploadControl, StatusLabel,
                TextBox_Comentario, out entregaAlumnoGenerada))
            {
                //Llevar a la página de detalles de entrega
                Linker linker = new Linker(false);
                linker.Redirect(Response,linker.DetallesMiEntregaAlumno(entregaAlumnoGenerada));
            }
            else
            {
                Notification.Current.NotifyLastNotification(Response);
                StatusLabel.Text = "Estado de Subida: No ha podido ser realizada";
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