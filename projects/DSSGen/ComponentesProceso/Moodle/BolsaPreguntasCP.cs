using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Excepciones;
using ComponentesProceso.Moodle.Commands;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para la base de preguntas
    public class BolsaPreguntasCP : BasicCP
    {
        //Constructor
        public BolsaPreguntasCP() : base() { }

        //Constructor con sesión
        public BolsaPreguntasCP(ISession sesion) : base(sesion) { }

        //Deolver el resultado de la consulta especificada devolviendo la cantidad de bolsas que satisfacen la consulta
        public System.Collections.Generic.IList<BolsaPreguntasEN> DameTodosTotal(IDameTodosBolsaPreguntas consulta, 
            int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session,first, size);
                numBases = consulta.Total(session);

                SessionCommit();
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

            return lista;
        }
    }
}
