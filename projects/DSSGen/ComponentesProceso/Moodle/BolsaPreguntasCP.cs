using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Excepciones;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para la base de preguntas
    public class BolsaPreguntasCP : BasicCP
    {
        //Constructor
        public BolsaPreguntasCP() : base() { }

        //Constructor con sesión
        public BolsaPreguntasCP(ISession sesion) : base(sesion) { }

        //Devolver una consulta paginada de dameTodos junto con la cantidad total de bolsas contenidas
        public System.Collections.Generic.IList<BolsaPreguntasEN> dameTodosConTotal(int first, int size, out long total)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;

            try
            {
                SessionInitializeTransaction();

                BolsaPreguntasCAD cad= new BolsaPreguntasCAD(session);
                BolsaPreguntasCEN bolsa= new BolsaPreguntasCEN(cad);

                lista = bolsa.ReadAll(first, size);
                total = bolsa.ReadCantidad();

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

            //Devolver lista
            return lista;
        }
    }
}
