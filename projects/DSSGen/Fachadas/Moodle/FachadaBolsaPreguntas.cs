﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;

using System.Web.UI.WebControls;
using WebUtilities;
using ComponentesProceso.Moodle;

namespace Fachadas.Moodle
{
    //Clase de fachada para la bolsa de preguntas
    public class FachadaBolsaPreguntas
    {
        //Método para la creación de una bolsa de preguntas a partir de una sesión de bolsa
        public int CrearBolsa(BolsaSession bolsa)
        {
            int asignatura = bolsa.Asignatura;
            String descripcion = bolsa.Descripcion;
            String nombre = bolsa.Nombre;
            IList<PreguntaEN> preguntas = bolsa.Preguntas;

            BolsaPreguntasCP bolsaCP = new BolsaPreguntasCP();
            return bolsaCP.CrearBolsa(nombre, descripcion, DateTime.Now, DateTime.Now, asignatura, preguntas);
        }

        //Vincular a un grid view las bolsas de preguntas con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numBases)
        {
            //Obtener bolsa de preguntas y enlazar sus datos con el gridview
            BindingComponents.Moodle.BolsaPreguntasBinding bolsaBind = new BindingComponents.Moodle.BolsaPreguntasBinding();
            IDameTodosBolsaPreguntas consulta = new DameTodosBolsaPreguntas();
            bolsaBind.VincularDameTodos(consulta,grid,first, size, out numBases);
        }

        //Obtener una bolsa a partir de su id
        public BolsaPreguntasEN DameBolsa(int id)
        {
            BolsaPreguntasCEN bolsaCen = new BolsaPreguntasCEN();
            return bolsaCen.ReadOID(id);
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

        //Obtener una BolsaSession de preguntas para modificar una bolsa existente en la BD
        public BolsaSession DameBolsaSession(int idBolsa)
        {
            BindingComponents.Moodle.BolsaPreguntasBinding binding= new BindingComponents.Moodle.BolsaPreguntasBinding();
            return binding.VincularBolsaSession(idBolsa);
        }
    }
}
