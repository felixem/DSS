using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using NHibernate;

using System.Web.UI.WebControls;

namespace Fachadas.Moodle
{
    //Clase de fachada para la bolsa de preguntas
    public class FachadaBolsaPreguntas : BasicFachada
    {
        //Constructor
        public FachadaBolsaPreguntas() : base() { }

        //Constructor con sesión
        public FachadaBolsaPreguntas(ISession sesion) : base(sesion) { }

        //Método para la creación de una bolsa de preguntas
        public int CrearBolsa(String p_nombre, String p_descripcion, int asignatura_id)
        {
            BolsaPreguntasCEN bolsaCen = new BolsaPreguntasCEN();
            BolsaPreguntasEN bolsaEn = new BolsaPreguntasEN();

            //Llamar al método de creación
            int id = bolsaCen.New_(p_nombre, p_descripcion,
                DateTime.Now, DateTime.Now, asignatura_id);

            return id;
        }

        //Vincular a un grid view las bolsas de preguntas con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                //Obtener bolsa de preguntas
                ComponentesProceso.Moodle.BolsaPreguntasCP bolsaCP = new ComponentesProceso.Moodle.BolsaPreguntasCP(session);
                lista = bolsaCP.dameTodosConTotal(first, size, out numBases);
                //Vincular con el grid view
                grid.DataSource = lista;
                grid.DataBind();

                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
        }

        //Modificar una bolsa de preguntas
        public void ModificarBolsa(int p_oid, string p_nombre, string p_descripcion,
            Nullable<DateTime> p_fecha_creacion)
        {
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN();

            //Modificar la bolsa
            bolsa.Modify(p_oid, p_nombre, p_descripcion, p_fecha_creacion, DateTime.Now);
        }

        //Borrar una bolsa de preguntas
        public void BorrarBolsa(int p_oid)
        {
            BolsaPreguntasCEN bolsa = new BolsaPreguntasCEN();
            bolsa.Destroy(p_oid);
        }
    }
}
