using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para la pregunta
    public class AsignaturaCP : BasicCP
    {
        //Constructor
        public AsignaturaCP() : base() { }

        //Constructor con sesión
        public AsignaturaCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de bolsas que satisfacen la consulta
        public System.Collections.Generic.IList<AsignaturaEN> DameTodosTotal(IDameTodosAsignatura consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numElementos = consulta.Total(session);

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

        //Crear una asignatura y devolver su id de creación
        public int CrearAsignatura(string codigo, string nombre, string descripcion,
            bool optativa, bool vigente)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();
                //Crear la asignatura
                AsignaturaCEN asig = new AsignaturaCEN();
                id = asig.New_(codigo, nombre, descripcion, optativa, vigente);

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

            return id;
        }
    }
}
