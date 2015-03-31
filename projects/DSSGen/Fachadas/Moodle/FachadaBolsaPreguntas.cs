using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    //Clase de fachada para la bolsa de preguntas
    public class FachadaBolsaPreguntas
    {
        //Método para la creación de una bolsa de preguntas
        public static int crearBolsa(String p_nombre, String p_descripcion, int asignatura_id)
        {
            BolsaPreguntasCEN bolsaCen = new BolsaPreguntasCEN();
            BolsaPreguntasEN bolsaEn = new BolsaPreguntasEN();

            //Llamar al método de creación
            int id = bolsaCen.New_(p_nombre, p_descripcion,
                DateTime.Now, DateTime.Now, asignatura_id);

            return id;
        }

        //Obtener todas las bases paginadas
        public static System.Collections.Generic.IList<BolsaPreguntasEN> dameTodos(int first, int size, out long numBases)
        {
            ComponentesProceso.Moodle.BolsaPreguntasCP bolsaCP = new ComponentesProceso.Moodle.BolsaPreguntasCP();
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;

            lista = bolsaCP.dameTodosConTotal(first, size, out numBases);

            return lista;
        }

        //Modificar una bolsa de preguntas
        public static void modificarBolsa(int p_oid, string p_nombre, string p_descripcion,
            Nullable<DateTime> p_fecha_creacion)
        {
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN();

            //Modificar la bolsa
            bolsa.Modify(p_oid, p_nombre, p_descripcion, p_fecha_creacion, DateTime.Now);
        }

        //Borrar una bolsa de preguntas
        public static void borrarBolsa(int p_oid)
        {
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN();
            bolsa.Destroy(p_oid);
        }
    }
}
