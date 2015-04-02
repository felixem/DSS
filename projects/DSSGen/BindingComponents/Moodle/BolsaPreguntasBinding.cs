using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;


namespace BindingComponents.Moodle
{
    //Clase utilizada para vincular datos a vistas sobre bolsas de preguntas
    public class BolsaPreguntasBinding : BasicBinding
    {
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
    }
}
