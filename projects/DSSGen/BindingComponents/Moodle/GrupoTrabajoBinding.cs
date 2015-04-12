﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;

namespace BindingComponents.Moodle
{
    //Clase para vincular datos sobre grupos de trabajo a alguna estructura de vista
    public class GrupoTrabajoBinding : BasicBinding
    {
        //Vincular a un GridView el resultado de la consulta
        public void VincularDameTodos(IDameTodosGrupoTrabajo consulta, GridView grid,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<GrupoTrabajoEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                GrupoTrabajoCP grupo = new GrupoTrabajoCP(session);
                //Ejecutar la consulta recibida sin paginar
                lista = grupo.DameTodosTotal(consulta, first, size, out total);
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

        //Vincular a TextBoxes el contenido de una consulta individual sobre un grupo de trabajo
        public void VincularDameGrupoTrabajo(IDameGrupoTrabajo consulta, IVinculadorGrupoTrabajo linker)
        {
            GrupoTrabajoEN grupo = null;

            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCP cp = new GrupoTrabajoCP(session);
                //Ejecutar la consulta recibida
                grupo = cp.DameGrupoTrabajo(consulta);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Comprobar que se ha encontrado grupo de trabajo
                if (grupo == null)
                    throw new Exception("Grupo de trabajo no encontrado");

                //Vincular con la vista
                linker.Vincular(grupo);

                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
