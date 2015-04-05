using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;

namespace WebUtilities
{
    public partial class BolsaSession
    {
        //Clase privada utilizada para garantizar la sincronización entre la bolsa de sesión y la bolsa
        //que está siendo modificada
        private class BolsaSincronizacion
        {
            //Lista de preguntas originales
            private List<PreguntaEN> preguntasOriginales;
            //Lista de índices de la lista preguntasOriginales con preguntas modificadas
            private List<int> preguntasModificadas;
            //Lista de preguntas eliminadas
            private List<PreguntaEN> preguntasBorradas;

            //Id de la bolsa original en la BD
            private int idBolsaOriginal;
            //Fecha de creación de la bolsa original
            private DateTime? fechaCreacion;
            //Id de la asignatura original en la BD
            private int idAsignatura;

            //Constructor
            public BolsaSincronizacion(int idBolsa, DateTime? creacion, int asignatura)
            {
                preguntasOriginales = new List<PreguntaEN>();
                preguntasModificadas = new List<int>();
                preguntasBorradas = new List<PreguntaEN>();
                idBolsaOriginal = idBolsa;
                fechaCreacion = creacion;
                idAsignatura = asignatura;
            }

            //Propiedades
            //Id de la bolsa original
            public int Id
            {
                get { return idBolsaOriginal; }
            }
            //Fecha de creación de la bolsa original
            public DateTime? FechaCreacion
            {
                get { return fechaCreacion; }
            }
            //Id de la asignatura original
            public int Asignatura
            {
                get { return idAsignatura; }
            }

            //Obtener lista de preguntas modificadas
            public IList<PreguntaEN> PreguntasModificadas
            {
                get 
                {
                    List<PreguntaEN> modificadas = new List<PreguntaEN>();
                    //Construir el array de preguntas modificadas a partir de los índices almacenados
                    foreach (int i in preguntasModificadas)
                    {
                        modificadas.Add(preguntasOriginales[i]);
                    }
                    return modificadas; 
                }
            }

            //Obtener la cantidad de preguntas originales que quedan sin borrar
            public int NumOriginales
            {
                get { return preguntasOriginales.Count; }
            }

            //Obtener una lista de preguntas borradas
            public IList<PreguntaEN> PreguntasBorradas
            {
                get { return preguntasBorradas; }
            }

            //Añadir una pregunta a la lista
            public void AddPregunta(PreguntaEN pregunta)
            {
                preguntasOriginales.Add(pregunta);
            }

            //Borrar una pregunta por índice
            public bool DeletePregunta(int index)
            {
                //Precondición
                if (preguntasOriginales.Count <= index)
                    return false;

                //Recuperar la pregunta
                PreguntaEN pregunta = preguntasOriginales[index];
                //Actualizar las estructuras
                preguntasOriginales.RemoveAt(index);
                preguntasBorradas.Add(pregunta);

                //Limpiar el índice de la pregunta modificada
                preguntasModificadas.Remove(index);
                //Actualizar los índices superiores a index decrementándolos en una unidad
                for (int i = 0; i < preguntasModificadas.Count; i++)
                {
                    int val = preguntasModificadas[i];
                    if (val > index)
                        preguntasModificadas[i] = val - 1;
                }

                return true;
            }

            //Borrar todas las preguntas
            public void DeleteAll()
            {
                //Añadir a la lista de preguntas borradas
                foreach(PreguntaEN preg in preguntasOriginales)
                {
                    preguntasBorradas.Add(preg);
                }
                //Limpiar las otras estructuras
                preguntasModificadas.Clear();
                preguntasOriginales.Clear();
            }

            //Modificar una pregunta por índice
            public bool ModificarPregunta(int index, String enunciado, List<String> respuestas, 
                int correcta, String explicacion)
            {
                //Precondición
                if (preguntasOriginales.Count <= index)
                    return false;

                //Recuperar la pregunta
                PreguntaEN pregunta = preguntasOriginales[index];
                pregunta.Contenido = enunciado;
                pregunta.Explicacion = explicacion;

                //Actualizar los valores de las respuestas
                for (int i = 0; i < respuestas.Count; i++)
                {
                    //Actualizar contenido
                    pregunta.Respuestas[i].Contenido = respuestas[i];
                    //Actualizar respuesta correcta
                    if (i == correcta)
                        pregunta.Respuesta_correcta = pregunta.Respuestas[i];
                }

                //Actualizar las estructuras
                preguntasModificadas.Add(index);
                preguntasOriginales[index] = pregunta;

                return true;
            }
        }
    }
}
