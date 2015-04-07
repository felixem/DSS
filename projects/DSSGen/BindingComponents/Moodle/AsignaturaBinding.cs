﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI.WebControls;
using ComponentesProceso.Moodle.Commands;
using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle;

namespace BindingComponents.Moodle
{
    //Clase para vincular datos sobre preguntas a alguna estructura de vista
    public class AsignaturaBinding : BasicBinding
    {
        public AsignaturaBinding() : base() { }
        public AsignaturaBinding(ISession sesion) : base(sesion) { }

        //Vincular a un DropDownList el resultado de la consulta
        public void VincularDameTodos(IDameTodosAsignatura consulta, DropDownList drop,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AsignaturaCP asig = new AsignaturaCP(session);
                //Ejecutar la consulta recibida sin paginar
                lista = asig.DameTodosTotal(consulta, first, size, out total);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Vincular con el dropdownlist
                foreach (AsignaturaEN x in lista)
                {
                    drop.Items.Add(new ListItem(x.Nombre+"("+x.Id+")", x.Id.ToString()));
                }

                //Cerrar sesión
                SessionClose();
            }
        }

        //Vincular a un GridView el resultado de la consulta
        public void VincularDameTodos(IDameTodosAsignatura consulta, GridView grid,
            int first, int size, out long total)
        {
            System.Collections.Generic.IList<AsignaturaEN> lista = null;

            try
            {
                SessionInitializeTransaction();
                AsignaturaCP asig = new AsignaturaCP(session);
                //Ejecutar la consulta recibida sin paginar
                lista = asig.DameTodosTotal(consulta, first, size, out total);
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
