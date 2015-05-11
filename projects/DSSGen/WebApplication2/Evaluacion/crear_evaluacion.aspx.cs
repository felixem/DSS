using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fachadas.Moodle;
using WebUtilities;

namespace DSSGenNHibernate.Evaluacion
{
    public partial class crear_evaluacion : BasicPage
    {
        //Creo la fachada de la evaluación.
        FachadaEvaluacion fachada;
        FachadaAnyoAcademico fachadaAnyo;
        FachadaFecha fachadaFecha;
        protected void Page_Load(object sender, EventArgs e)
        {
            fachada= new FachadaEvaluacion();
            fachadaAnyo=new FachadaAnyoAcademico();
            fachadaFecha = new FachadaFecha();
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
                //Obtener los sistemas evaluacion
                this.ObtenerAnyosAcademicos();
                this.ObtenerAnyos();
                this.ObtenerMeses();
                this.ObtenerDias();
            }
        }
        protected void Button_Evaluacion_Click(Object sender, EventArgs e)
        {
                //Recogo los datos
                string nombre = TextBox_Nombre.Text;
                DateTime inicio = DateTime.Parse("" + ddlDia.Text + "/" + ddlMes.Text + "/" + ddlAno.Text);
                DateTime fin = DateTime.Parse("" + ddlDiaC.Text + "/" + ddlMesC.Text + "/" + ddlAnoC.Text);
                bool abierto= CheckBox_Abierta.Checked;
                int anyo= Int32.Parse(DropDownList_Anyos.SelectedValue);
                fachada.RegistrarEvaluacion(nombre,inicio,fin,abierto,anyo);

            //Registrar evaluación
            if (fachada.RegistrarEvaluacion(nombre,inicio,fin,abierto,anyo))
            {
                Notification.Current.NotifyLastNotification(Response);
                this.Clean();
            }
            else
            {
                Notification.Current.NotifyLastNotification(Response);
            }
        }        
        //Botón utilizado para cancelar la creación y volver atrás
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }

        //Método que llama el botón limpiar campos
        protected void Button_Clean_Click(Object sender, EventArgs e)
        {
            this.Clean();
        }
        //Método para limpiar campos
          private void Clean()
        {
            TextBox_Nombre.Text="";
            CheckBox_Abierta.Checked = false;
        }
       
        //Obtener los años académicos
        protected void ObtenerAnyosAcademicos()
        {
            fachadaAnyo.VincularDameTodos(DropDownList_Anyos);
        }
        
        protected void ObtenerAnyos() 
        {
            fachadaFecha.VincularDameAnyos(ddlAno,10,10);
            fachadaFecha.VincularDameAnyos(ddlAnoC,10,10);
        }
        protected void ObtenerMeses()
        {
            
                fachadaFecha.VincularDameMeses(Int32.Parse(ddlAno.SelectedValue), ddlMes);
                fachadaFecha.VincularDameMeses(Int32.Parse(ddlAnoC.SelectedValue),ddlMesC);
            
        }
        protected void ObtenerDias() {

            fachadaFecha.VincularDameDias(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMesC.SelectedValue), Int32.Parse(ddlAnoC.SelectedValue), ddlDiaC);
            
        }

        //Evento ocurrido al seleccionar un año
        protected void ddlAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMes.Items.Clear();
            ddlDia.Items.Clear();

            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAno.SelectedValue),ddlMes);
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);
        }

        //Evento ocurrido al seleccionar un mes
        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDia.Items.Clear();
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMes.SelectedValue), Int32.Parse(ddlAno.SelectedValue), ddlDia);

        }
        //Evento ocurrido al seleccionar un año
        protected void ddlAnoC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMesC.Items.Clear();
            ddlDiaC.Items.Clear();
            fachadaFecha.VincularDameMeses(Int32.Parse(ddlAnoC.SelectedValue), ddlMesC);
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMesC.SelectedValue), Int32.Parse(ddlAnoC.SelectedValue), ddlDiaC);
        }

        //Evento ocurrido al seleccionar un mes
        protected void ddlMesC_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDiaC.Items.Clear();
            fachadaFecha.VincularDameDias(Int32.Parse(ddlMesC.SelectedValue), Int32.Parse(ddlAnoC.SelectedValue), ddlDiaC);

        }

    }
}
