using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace Classes
{
    //Clase utilizada para almacenar provisionalmente la construcción de una bolsa de preguntas
    public class BolsaSession
    {
        private BolsaPreguntasEN bolsa;

        //Constructor por defecto
        private BolsaSession()
        {
            bolsa = new BolsaPreguntasEN();
            bolsa.Asignatura = new AsignaturaEN();
            bolsa.Asignatura.Id = -1;
            bolsa.Preguntas = new List<PreguntaEN>();
        }

        //Obtener la bolsa de sesión actual
        public static BolsaSession Current
        {
            get
            {
                BolsaSession session =
                  (BolsaSession)HttpContext.Current.Session["__BolsaSession__"];
                if (session == null)
                {
                    session = new BolsaSession();
                    HttpContext.Current.Session["__BolsaSession__"] = session;
                }
                return session;
            }
        }

        //Propiedades que interesan en la creación provisional de la bolsa de preguntas
        public virtual string Nombre
        {
            get { return bolsa.Nombre; }
            set { bolsa.Nombre = value; }
        }

        //Descripción de la bolsa
        public virtual string Descripcion
        {
            get { return bolsa.Descripcion; }
            set { bolsa.Descripcion = value; }
        }

        //Id de la asignatura a la que pertenece la bolsa
        public virtual int Asignatura
        {
            get { return bolsa.Asignatura.Id; }
            set { bolsa.Asignatura.Id = value; }
        }

        //Devolver lista de preguntas
        public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> Preguntas
        {
            get { return bolsa.Preguntas; }
        }

        //Añadir pregunta a la lista
        public void AddPregunta(String enunciado, List<String> respuestas, int correcta, String explicacion)
        {
            //Construir la pregunta
            int id = bolsa.Preguntas.Count;
            PreguntaEN pregunta = ConstruirPregunta(id, enunciado,respuestas,correcta,explicacion);
            //Añadirla a la bolsa
            bolsa.Preguntas.Add(pregunta);
        }

        //Modificar pregunta de la lista
        public void ModificarPregunta(int id, String enunciado, List<String> respuestas, int correcta, String explicacion)
        {
            //Modificar la pregunta
            bolsa.Preguntas[id] = ConstruirPregunta(id, enunciado, respuestas, correcta, explicacion);
        }

        //Método privado para construir una pregunta
        private PreguntaEN ConstruirPregunta(int id, String enunciado, List<String> respuestas, int correcta, String explicacion)
        {
            //Construir la pregunta
            PreguntaEN pregunta = new PreguntaEN();
            pregunta.Id = id;
            pregunta.Contenido = enunciado;
            pregunta.Explicacion = explicacion;
            pregunta.Respuestas = new List<RespuestaEN>();

            //Generar las respuestas
            foreach (String respuesta in respuestas)
            {
                RespuestaEN resp = new RespuestaEN();
                resp.Contenido = respuesta;
                resp.Id = pregunta.Respuestas.Count;
                pregunta.Respuestas.Add(resp);
            }

            pregunta.Respuesta_correcta = pregunta.Respuestas[correcta];
            return pregunta;
        }

        //Borrar pregunta de la lista según el índice
        public void RemovePregunta(int index)
        {
            bolsa.Preguntas.RemoveAt(index);
        }

        //Borrar la lista de preguntas
        public void ClearPreguntas()
        {
            bolsa.Preguntas.Clear();
        }

        //Obtener enunciado de la pregunta en la posición index
        public String EnunciadoPregunta(int index)
        {
            PreguntaEN pregunta = bolsa.Preguntas[index];
            return pregunta.Contenido;
        }

        //Obtener la explicación de la pregunta en la posición index
        public String ExplicacionPregunta(int index)
        {
            PreguntaEN pregunta = bolsa.Preguntas[index];
            return pregunta.Explicacion;
        }

        //Obtener el contenido de la respuesta a la pregunta en la posición index
        public String ContenidoRespuesta(int pregunta, int index)
        {
            PreguntaEN preg = bolsa.Preguntas[pregunta];
            RespuestaEN respuesta = preg.Respuestas[index];
            return respuesta.Contenido;
        }

        //Obtener el índice de la respuesta correcta a la pregunta en la posición index
        public int RespuestaCorrecta(int index)
        {
            PreguntaEN preg = bolsa.Preguntas[index];
            RespuestaEN respuesta = preg.Respuesta_correcta;
            return respuesta.Id;
        }

        //Obtener un rango de preguntas
        public System.Collections.Generic.IList<PreguntaEN> DamePreguntas(int first, int size, out long numPreguntas)
        {
            System.Collections.Generic.IList<PreguntaEN> lista = new List<PreguntaEN>();
            numPreguntas = Preguntas.Count;

            //Precondiciones
            if(first < 0 || first >=bolsa.Preguntas.Count || size <=0)
                return lista;

            int x = 0;
            int index = first;

            //Construir la lista
            while(index < bolsa.Preguntas.Count && x < size)
            {
                lista.Add(bolsa.Preguntas[index]);
                x++;
                index++;
            }

            return lista;
        }

        //Inyectar dentro del GridView el contenido de las preguntas
        public void VincularDamePreguntas(GridView grid, int first, int size, out long numPreguntas)
        {
            System.Collections.Generic.IList<PreguntaEN> lista = null;
            //Obtener las preguntas
            lista = DamePreguntas(first, size, out numPreguntas);
            //Vincular con el grid view
            grid.DataSource = lista;
            grid.DataBind();
        }
        
    }
}