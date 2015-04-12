using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;

using System.Web.UI.WebControls;
using WebUtilities;
using ComponentesProceso.Moodle;
using BindingComponents.Moodle.Commands;

namespace Fachadas.Moodle
{
    //Clase de fachada para la bolsa de preguntas
    public class FachadaBolsaPreguntas
    {
        //Método para la creación de una bolsa de preguntas a partir de una sesión de bolsa
        public bool CrearBolsa(BolsaSession bolsa)
        {
            int asignatura = bolsa.Asignatura;
            String descripcion = bolsa.Descripcion;
            String nombre = bolsa.Nombre;
            IList<PreguntaEN> preguntas = bolsa.Preguntas;

            try
            {
                BolsaPreguntasCP bolsaCP = new BolsaPreguntasCP();
                bolsaCP.CrearBolsa(nombre, descripcion, DateTime.Now, DateTime.Now, asignatura, preguntas);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para la modificación de una bolsa de preguntas a partir de una sesión de bolsa
        public bool ModificarBolsa(BolsaSession bolsa)
        {
            int idBolsa = bolsa.Id;
            int asignaturaOriginal = bolsa.AsignaturaOriginal;
            int asignaturaNueva = bolsa.Asignatura;
            String descripcion = bolsa.Descripcion;
            String nombre = bolsa.Nombre;
            DateTime? fecha_creacion = bolsa.Fecha_creacion;
            DateTime? fecha_modificacion = DateTime.Now;
            IList<PreguntaEN> preguntasCreadas = bolsa.PreguntasCreadas;
            IList<PreguntaEN> preguntasModificadas = bolsa.PreguntasModificadas;
            IList<PreguntaEN> preguntasBorradas = bolsa.PreguntasBorradas;

            try
            {
                BolsaPreguntasCP bolsaCP = new BolsaPreguntasCP();
                bolsaCP.ModificarBolsa(idBolsa, nombre, descripcion, fecha_creacion, fecha_modificacion,
                    asignaturaOriginal, asignaturaNueva, preguntasCreadas, preguntasModificadas, preguntasBorradas);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Vincular a un grid view las bolsas de preguntas con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numBases)
        {
            //Obtener bolsa de preguntas y enlazar sus datos con el gridview
            BindingComponents.Moodle.BolsaPreguntasBinding bolsaBind = new BindingComponents.Moodle.BolsaPreguntasBinding();
            IDameTodosBolsaPreguntas consulta = new DameTodosBolsaPreguntas();
            BinderListaBolsaPreguntasGrid binder = new BinderListaBolsaPreguntasGrid(grid);

            bolsaBind.VincularDameTodos(consulta,binder,first, size, out numBases);
        }

        //Borrar una bolsa de preguntas
        public bool BorrarBolsa(int p_oid)
        {
            try
            {
                BolsaPreguntasCP bolsa = new BolsaPreguntasCP();
                bolsa.BorrarBolsa(p_oid);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Obtener una BolsaSession de preguntas para modificar una bolsa existente en la BD
        public bool CargarBolsaSession(int idBolsa, BolsaSession bolsa)
        {
            try
            {
                bolsa = BolsaSession.Current;
                BindingComponents.Moodle.BolsaPreguntasBinding binding = new BindingComponents.Moodle.BolsaPreguntasBinding();
                binding.VincularBolsaSession(bolsa, idBolsa);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
