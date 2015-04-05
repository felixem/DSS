using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;
using WebUtilities;
using NHibernate;


namespace BindingComponents.Moodle
{
    //Clase utilizada para vincular datos a vistas sobre bolsas de preguntas
    public class BolsaPreguntasBinding : BasicBinding
    {
        public BolsaPreguntasBinding() : base() { }
        public BolsaPreguntasBinding(ISession sesion) : base(sesion) { }

        //Vincular GridView al resultado de la consulta especificada devolviendo la cantidad de bolsas existentes
        public void VincularDameTodos(IDameTodosBolsaPreguntas consulta, GridView grid, int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                BolsaPreguntasCP bolsa = new BolsaPreguntasCP(session);
                //Ejecutar la consulta recibida 
                lista = bolsa.DameTodosTotal(consulta, first, size, out numBases);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Vincular con el grid view
                grid.DataSource = lista;
                grid.DataBind();
                //Cerrar sesión
                SessionClose();
            }
        }

        //Vincular a una bolsa de sesión el contenido de una bolsa existente
        public BolsaSession VincularBolsaSession(int idBolsa)
        {
            BolsaSession bolsaSesion = BolsaSession.Current;

            //Recuperar los datos de la bolsa original
            try
            {
                SessionInitializeTransaction();

                BolsaPreguntasCAD bolsaCad = new BolsaPreguntasCAD(session);
                BolsaPreguntasCEN bolsaCen = new BolsaPreguntasCEN(bolsaCad);
                BolsaPreguntasEN bolsita = bolsaCen.ReadOID(idBolsa);

                //Comprobar si se ha encontrado la bolsa
                if (bolsita != null)
                {
                    //Actualizar sólo en caso de que no se estuviese modificando previamente la misma bolsa
                    if (!bolsaSesion.ComprobarVinculo(idBolsa))
                    {
                        //Copiar los valores básicos de la bolsa
                        bolsaSesion.ComenzarSincronizacion(bolsita);

                        //Copiar las preguntas originales en la lista de preguntas originales
                        foreach (PreguntaEN pregunta in bolsita.Preguntas)
                        {
                            //Añadir a las estructuras apropiadas las preguntas y sus respuestas
                            IList<RespuestaEN> respuestas = pregunta.Respuestas;

                            //Obtener las respuestas de la pregunta original
                            foreach (RespuestaEN resp in respuestas)
                            {
                                //Obtener la respuesta correcta
                                if (resp.Id.Equals(pregunta.Respuesta_correcta.Id))
                                    pregunta.Respuesta_correcta = resp;
                            }

                            //Almacenar en la estructura de respuestas originales
                            pregunta.Respuestas = respuestas;

                            //Añadir la pregunta provisional a la bolsa provisional
                            bolsaSesion.AddPreguntaOriginal(pregunta);
                        }
                    }
                    SessionCommit();
                }
                //Bolsa no encontrada
                else
                {
                    throw new Exception("Bolsa no encontrada");
                }
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return bolsaSesion;
        }
    }
}
