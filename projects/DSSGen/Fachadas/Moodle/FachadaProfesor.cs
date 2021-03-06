﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ComponentesProceso.Moodle;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.EN.Moodle;
using BindingComponents.Moodle.Commands;
using WebUtilities;

namespace Fachadas.Moodle
{
    public class FachadaProfesor
    {
        //Metodo que registra al profesor en BD
        public bool RegistrarProfesor(string nombre, string apellidos, string pass, DateTime fecha, string dni, string email, int cod)
        {
            try
            {
                ProfesorCP profesor = new ProfesorCP();
                profesor.CrearProfesor(nombre, apellidos, pass, fecha, dni, email, cod);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El profesor no pudo ser creado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El profesor ha sido creado");
            return true;
        }

        //Método para modificar un profesor en la BD sin modificar su password
        public bool ModificarProfesorNoPassword(string email, int codProfesor, string dni,
            string nombre, string apellidos, DateTime? fechaNacimiento)
        {
            try
            {
                ProfesorCP cp = new ProfesorCP();
                cp.ModificarProfesorNoPassword(email, codProfesor, dni, nombre, apellidos, fechaNacimiento);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El profesor no pudo ser modificado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El profesor ha sido modificado");
            return true;
        }

        //Método para eliminar un profesor en la BD
        public bool BorrarProfesor(int codProfesor)
        {
            try
            {
                ProfesorCP cp = new ProfesorCP();
                cp.BorrarProfesor(codProfesor);
            }
            catch (Exception ex)
            {
                Notification.Current.AddNotification("ERROR: El profesor no pudo ser borrado. " + ex.Message);
                return false;
            }

            Notification.Current.AddNotification("El profesor ha sido borrado");
            return true;
        }

        //Vincular a un grid view los profesores con paginación
        public void VincularDameTodos(GridView grid, int first, int size, out long numProfesores)
        {
            //Obtener profesores y enlazar sus datos con el gridview
            ProfesorBinding profesorBind = new ProfesorBinding();
            IDameTodosProfesor consulta = new DameTodosProfesor();
            BinderListaProfesorGrid binder = new BinderListaProfesorGrid(grid);
            profesorBind.VincularDameTodos(consulta, binder, first, size, out numProfesores);
        }

        //Vincular a un DropDownList todos los profesores de ese AsignaturaAnyo
        public void VincularDameTodosPorAsignaturaAnyo(DropDownList drop, int idAsignaturaAnyo)
        {
            ProfesorBinding stmeval = new ProfesorBinding();
            DameTodosProfesorPorAsignaturaAnyo consulta = new DameTodosProfesorPorAsignaturaAnyo(idAsignaturaAnyo);
            BinderListaProfesorDropDownList binder = new BinderListaProfesorDropDownList(drop);
            long total;
            stmeval.VincularDameTodos(consulta, binder, 0, -1, out total);
        }

        //Método para vincular un profesor a partir de su id a textboxes
        public bool VincularProfesorPorId(int id, TextBox TextBox_NomProf,
            TextBox TextBox_ApellProf, DropDownList ddlAno,DropDownList ddlMes,DropDownList ddlDia, TextBox TextBox_DNIProf,
            TextBox TextBox_EmailProf, TextBox TextBox_CodProf)
        {
            try
            {
                ProfesorBinding binding = new ProfesorBinding();
                DameProfesorPorId consulta = new DameProfesorPorId(id);
                BinderProfesorCompleto linker = new BinderProfesorCompleto(TextBox_NomProf,
                    TextBox_ApellProf, ddlAno, ddlMes, ddlDia, TextBox_DNIProf,
                    TextBox_EmailProf, TextBox_CodProf);

                binding.VincularDameProfesor(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
