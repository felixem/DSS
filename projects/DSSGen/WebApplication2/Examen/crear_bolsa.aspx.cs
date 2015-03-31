using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using Classes;

namespace DSSGenNHibernate.Examen
{
    public partial class crear_bolsa : System.Web.UI.Page
    {
        //Recuperar la sesión de la bolsa de preguntas
        BolsaSession bolsa;

        //Manejador al cargar la página
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recuperar el estado de la bolsa
            bolsa = BolsaSession.Current;

            if (!IsPostBack)
            {
                //Inicializar los datos de los textbox
                TextBox_Nombre.Text = bolsa.Nombre;
                TextBox_Descripcion.Text = bolsa.Descripcion;
                this.ObtenerPreguntasPaginadas(1);
            }
        }

        //Manejador al cambiar el tamaño de página
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            this.ObtenerPreguntasPaginadas(1);
        }

        //Manejador para obtener la lista provisional de preguntas de la bolsa con el índice requerido
        private void ObtenerPreguntasPaginadas(int pageIndex)
        {
            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            long numObjetos = 0;

            //Vincular el grid con la lista de preguntas provisional
            bolsa.VincularDamePreguntas(GridViewPreguntas, (pageIndex - 1) * pageSize, pageSize, out numObjetos);

            int recordCount = (int)numObjetos;
            this.ListarPaginas(recordCount, pageIndex);
        }

        //Manejador para el cambio de página
        protected void Page_Changed(object sender, EventArgs e)
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            this.ObtenerPreguntasPaginadas(pageIndex);
        }

        //Listar las páginas para navegar sobre ellas
        private void ListarPaginas(int recordCount, int currentPage)
        {
            double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            List<ListItem> pages = new List<ListItem>();
            if (pageCount > 0)
            {
                pages.Add(new ListItem("First", "1", currentPage > 1));
                for (int i = 1; i <= pageCount; i++)
                {
                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                }
                pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
            }
            rptPager.DataSource = pages;
            rptPager.DataBind();
        }

        //Manejador del evento para modificar una pregunta
        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            string contenido = grdrow.Cells[0].Text;
            Response.Write("<script>window.alert('" + contenido + " " + DateTime.Now + "');</script>");
        }

        //Añadir pregunta a la lista
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            bolsa.Nombre = TextBox_Nombre.Text;
            bolsa.Descripcion = TextBox_Descripcion.Text;
            Response.Redirect(Linker.CrearPregunta());
        }
    }
}