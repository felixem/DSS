﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso de curso
    public class SistemaEvaluacionCP : BasicCP
    {
        //Constructor
        public SistemaEvaluacionCP() : base() { }

        //Constructor con sesión
        public SistemaEvaluacionCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de sistemas evaluacion que satisfacen la consulta
        public System.Collections.Generic.IList<SistemaEvaluacionEN> DameTodosTotal(IDameTodosSistemaEvaluacion consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<SistemaEvaluacionEN> lista = null;
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
    }
}