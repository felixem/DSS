using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace WebUtilities
{
    //Clase utilizada para almacenar provisionalmente la construcción de una bolsa de preguntas
    public partial class BolsaSession
    {
        private BolsaPreguntasEN bolsa;
        private BolsaSincronizacion sincronizacion;

        //Constructor por defecto
        private BolsaSession()
        {
            InicializarValores();
        }

        //Inicializar valores
        private void InicializarValores()
        {
            bolsa = new BolsaPreguntasEN();
            bolsa.Id = -1;
            bolsa.Asignatura = new AsignaturaEN();
            bolsa.Asignatura.Id = -1;
            bolsa.Preguntas = new List<PreguntaEN>();
            sincronizacion = null;
        }

        //Obtener la bolsa de sesión actual
        public static BolsaSession Current
        {
            get
            {
                BolsaSession session =
                  (BolsaSession)HttpContext.Current.Session["__BolsaSessionCreacion__"];
                if (session == null)
                {
                    session = new BolsaSession();
                    HttpContext.Current.Session["__BolsaSessionCreacion__"] = session;
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

        //Id de la bolsa original
        public virtual int Id
        {
            get
            {
                if (!IsCargada())
                    throw new Exception("Esta bolsa no tiene id asignado");
                else
                    return sincronizacion.Id;
            }
        }

        //Fecha de creación de la bolsa original
        public virtual DateTime? Fecha_creacion
        {
            get
            {
                if (!IsCargada())
                    return null;
                else
                    return sincronizacion.FechaCreacion;
            }
        }

        //Asignatura de la bolsa original
        public virtual int AsignaturaOriginal
        {
            get
            {
                if (!IsCargada())
                    throw new Exception("Esta bolsa no tiene bolsa original asignada");
                else
                    return sincronizacion.Asignatura;
            }
        }

        //Devolver lista de preguntas
        public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> Preguntas
        {
            get { return bolsa.Preguntas; }
        }

        //Devolver la lista de preguntas nuevas creadas
        public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> PreguntasCreadas
        {
            get
            {
                //Todas las preguntas son nuevas
                if (!IsCargada() || sincronizacion.NumOriginales == 0)
                    return Preguntas;
                else
                {
                    List<PreguntaEN> creadas = new List<PreguntaEN>();
                    IList<PreguntaEN> preguntas = Preguntas;
                    int max = preguntas.Count;

                    //Generar la sublista obviando los elementos que no deben ser creados de nuevo
                    for (int i = sincronizacion.NumOriginales; i < max; i++)
                        creadas.Add(preguntas[i]);

                    return creadas;
                }
            }
        }

        //Devolver la lista de preguntas originales modificadas
        public IList<PreguntaEN> PreguntasModificadas
        {
            get
            {
                if (!IsCargada())
                    return new List<PreguntaEN>();
                else
                    return sincronizacion.PreguntasModificadas;
            }
        }

        //Devolver la lista de preguntas originales borradas
        public IList<PreguntaEN> PreguntasBorradas
        {
            get
            {
                if (!IsCargada())
                    return new List<PreguntaEN>();
                else
                    return sincronizacion.PreguntasBorradas;
            }
        }

        //Saber si la bolsa ha sido cargada
        private bool IsCargada()
        {
            return sincronizacion != null;
        }

        //Comprobar si la bolsa de sesión está ya vinculada a una bolsa determinada
        public bool ComprobarVinculo(int idBolsa)
        {
            if (sincronizacion == null)
                return false;
            else
                return sincronizacion.Id.Equals(idBolsa);
        }

        //Comenzar la sincronización con una bolsa de la BD
        public void ComenzarSincronizacion(BolsaPreguntasEN bolsita)
        {
            this.Clear();
            sincronizacion = new BolsaSincronizacion(bolsita.Id, bolsita.Fecha_creacion, bolsita.Asignatura.Id);
            bolsa.Asignatura.Id = bolsita.Asignatura.Id;
            bolsa.Descripcion = bolsita.Descripcion;
            bolsa.Fecha_creacion = bolsita.Fecha_creacion;
            bolsa.Id = bolsita.Id;
            bolsa.Nombre = bolsita.Nombre;
        }

        //Añadir pregunta original durante la sincronización
        public void AddPreguntaOriginal(PreguntaEN pregunta)
        {
            if (!IsCargada())
                throw new Exception("Error. No está en modo sincronización");

            //Añadir a la estructura de sincronización
            sincronizacion.AddPregunta(pregunta);

            //Crear la pregunta en la bolsa temporal
            List<String> respuestas = new List<String>();
            int correcta = -1;
            //Obtener el contenido de las respuestas
            for (int i = 0; i < pregunta.Respuestas.Count; i++)
            {
                RespuestaEN resp = pregunta.Respuestas[i];
                respuestas.Add(resp.Contenido);
                if (pregunta.Respuesta_correcta.Equals(resp))
                    correcta = i;
            }

            this.AddPregunta(pregunta.Contenido, respuestas, correcta, pregunta.Explicacion);
        }

        //Limpiar bolsa
        public void Clear()
        {
            InicializarValores();
        }

        //Añadir pregunta a la lista
        public bool AddPregunta(String enunciado, List<String> respuestas, int correcta, String explicacion)
        {
            try
            {
                //Construir la pregunta
                int id = bolsa.Preguntas.Count;
                PreguntaEN pregunta = ConstruirPregunta(id, enunciado, respuestas, correcta, explicacion);
                //Añadirla a la bolsa
                bolsa.Preguntas.Add(pregunta);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Modificar pregunta de la lista
        public bool ModificarPregunta(int id, String enunciado, List<String> respuestas, int correcta, String explicacion)
        {
            try
            {
                //Actualizar cambios en la estructura de sincronización
                if (IsCargada())
                    sincronizacion.ModificarPregunta(id, enunciado, respuestas, correcta, explicacion);

                //Modificar la pregunta
                bolsa.Preguntas[id] = ConstruirPregunta(id, enunciado, respuestas, correcta, explicacion);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
        public bool RemovePregunta(int index)
        {
            try
            {
                //Actualizar cambios en la estructura de sincronización si es necesario
                if (IsCargada())
                    sincronizacion.DeletePregunta(index);

                bolsa.Preguntas.RemoveAt(index);
                //Actualizar el índice de las preguntas restantes
                for (int i = index; i < bolsa.Preguntas.Count; i++)
                {
                    bolsa.Preguntas[i].Id = i;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Borrar la lista de preguntas
        public void ClearPreguntas()
        {
            //Actualizar la estructura de sincronización si es necesario
            if (IsCargada())
                sincronizacion.DeleteAll();

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
            if (first < 0 || first >= bolsa.Preguntas.Count || size <= 0)
                return lista;

            int x = 0;
            int index = first;

            //Construir la lista
            while (index < bolsa.Preguntas.Count && x < size)
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