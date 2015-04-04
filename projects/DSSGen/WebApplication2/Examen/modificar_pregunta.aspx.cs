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
    public partial class modificar_pregunta : System.Web.UI.Page
    {
        private BolsaSession bolsa;
        private int id;
        private Boolean modificar;
        String param;

        //Comprobar si se plantea operación de modificación
        protected void Comprobar_Modo()
        {
            param = Request.QueryString[PageParameters.MainParameter];
            //No hacer nada más si no se ha recibido un parámetro
            if (param == null)
                modificar = false;
            else
            {
                id = Int32.Parse(param);
                modificar = true;
            }
        }

        //Comprobar parámetros
        protected void Procesar_Parametros()
        {
            //No hacer nada más si no se ha recibido un parámetro
            if (!modificar)
                return;
            //Comprobar que la id es correcta y recuperar los datos
            if (id >= 0 && id < bolsa.Preguntas.Count)
                Inicializar_Datos();
            //Redireccionar a la propia página sin parámetros en caso de fallo
            else
                throw new Exception("Página no encontrada");
        }

        //Inicializar los datos de los textboxes
        protected void Inicializar_Datos()
        {
            TextBox_Enunciado.Text = bolsa.EnunciadoPregunta(id);
            TextBox_Explicacion.Text = bolsa.ExplicacionPregunta(id);
            TextBox_Opcion1.Text = bolsa.ContenidoRespuesta(id, 0);
            TextBox_Opcion2.Text = bolsa.ContenidoRespuesta(id, 1);
            TextBox_Opcion3.Text = bolsa.ContenidoRespuesta(id, 2);
            TextBox_Opcion4.Text = bolsa.ContenidoRespuesta(id, 3);
            RadioButtonListOpciones.SelectedIndex = bolsa.RespuestaCorrecta(id);
        }

        //Carga de la página
        protected void Page_Load(object sender, EventArgs e)
        {
            bolsa = BolsaSession.Current;
            Comprobar_Modo();

            //Actualizar los formularios sólo si no es postback
            if (!IsPostBack)
            {
                //Capturar la página que realizó la petición
                NavigationSession navegacion = NavigationSession.Current;
                navegacion.SavePreviuosPage(Request);

                if(modificar)
                    Procesar_Parametros();
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

            if (modificar)
                //Modificar la pregunta de la bolsa
                bolsa.ModificarPregunta(id, enunciado, respuestas, idCorrecta, explicacion);
            else
                //Añadir a la bolsa de preguntas provisional
                bolsa.AddPregunta(enunciado, respuestas, idCorrecta, explicacion);

            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response,link.PreviousPage());
        }

        //Cancelar la creación de la respuesta
        protected void Button_Cancelar_Click(object sender, EventArgs e)
        {
            //Redirigir a la página que le llamó
            Linker link = new Linker(false);
            link.Redirect(Response,link.PreviousPage());
        }
    }
}