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
        private int id_asignatura;
        private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> preguntas;

        //Constructor por defecto
        private BolsaSession()
        {
            bolsa = new BolsaPreguntasEN();
            id_asignatura = -1;
            preguntas = new List<PreguntaEN>();
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
            get { return id_asignatura; }
            set { id_asignatura = value; }
        }

        //Devolver lista de preguntas
        public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> Preguntas
        {
            get { return preguntas; }
        }

        //Añadir pregunta a la lista
        public virtual void AddPregunta(PreguntaEN pregunta)
        {
            preguntas.Add(pregunta);
        }

        //Borrar pregunta de la lista según el índice
        public virtual void RemovePregunta(int index)
        {
            preguntas.RemoveAt(index);
        }

        //Borrar la lista de preguntas
        public virtual void ClearPreguntas()
        {
            preguntas.Clear();
        }

        //Inyectar dentro del GridView el contenido de las preguntas
        public void VincularDamePreguntas(GridView grid, int first, int size, out long numPreguntas)
        {
            System.Collections.Generic.IList<PreguntaEN> lista = null;
            //Obtener las preguntas
            lista = Preguntas;
            numPreguntas = lista.Count();
            //Vincular con el grid view
            grid.DataSource = lista;
            grid.DataBind();
        }
    }
}