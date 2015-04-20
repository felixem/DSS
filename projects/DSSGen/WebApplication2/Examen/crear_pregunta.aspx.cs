using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUtilities;

using DSSGenNHibernate.EN.Moodle;

namespace DSSGenNHibernate.Examen
{
    public partial class crear_pregunta : BasicPage
    {
        //Carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);
            }
        }

        //Confirmar la creación o modificación de la pregunta
        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            List<String> respuestas = new List<String>();

            //Crear un array de string con las preguntas
            for (int i = 1; i <= 4; i++)
            {
                TextBox box = Panel1.FindControl("TextBox_Opcion" + i) as TextBox;
                respuestas.Add(box.Text);
            }

            int idCorrecta = RadioButtonListOpciones.SelectedIndex;
            String enunciado = TextBox_Enunciado.Text;
            String explicacion = TextBox_Explicacion.Text;

            //Recuperar la bolsa
            BolsaSession bolsa = BolsaSession.Current;

            //Añadir a la bolsa de preguntas provisional
            if (bolsa.AddPregunta(enunciado, respuestas, idCorrecta, explicacion))
            {
                this.Clear();
                Notification.Notify(Response, "La pregunta ha sido creada");
            }

            else
                Notification.Notify(Response, "La pregunta no ha podido ser creada");
        }

        //Limpiar contenido
        private void Clear()
        {
            //Limpiar textboxes
            for (int i = 1; i <= 4; i++)
            {
                TextBox box = Panel1.FindControl("TextBox_Opcion" + i) as TextBox;
                box.Text = "";
            }

            //Limpiar opciones
            RadioButtonListOpciones.ClearSelection();
            //Limpiar campos restantes
            TextBox_Enunciado.Text = "";
            TextBox_Explicacion.Text = "";
        }


        //Limpiar campos
        protected void Button_Limpiar_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        //Cancelar la creación de la respuesta
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response, link.PreviousPage());
        }
    }
}