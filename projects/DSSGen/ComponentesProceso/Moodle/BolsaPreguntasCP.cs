using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DSSGenNHibernate.CAD.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Excepciones;
using System.Web.UI.WebControls;
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

        //Vincular GridView al resultado de la consulta especificada
        public void VincularDameTodos(IDameTodosBolsaPreguntas consulta, GridView grid, int first, int size, out long numBases)
        {
            System.Collections.Generic.IList<BolsaPreguntasEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session,first, size, out numBases);

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
    }
}
