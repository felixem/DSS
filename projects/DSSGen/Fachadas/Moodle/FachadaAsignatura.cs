﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BindingComponents.Moodle;
using ComponentesProceso.Moodle.Commands;
using ComponentesProceso.Moodle;
using DSSGenNHibernate.EN.Moodle;

namespace Fachadas.Moodle
{
    //Fachada para la clase pregunta
    public class FachadaAsignatura
    {
        //Vincular a un DropDownList todas las asignaturas
        public void VincularDameTodos(DropDownList drop)
        {
            AsignaturaBinding asig = new AsignaturaBinding();
            DameTodosAsignatura consulta = new DameTodosAsignatura();
            long total;
            asig.VincularDameTodos(consulta, drop, 0, -1, out total);
        }

        //Vincular a un GridView todas las asignaturas
        public void VincularDameTodos(GridView grid, int first, int size, out long numElements)
        {
            AsignaturaBinding asig = new AsignaturaBinding();
            DameTodosAsignatura consulta = new DameTodosAsignatura();
            asig.VincularDameTodos(consulta, grid, first, size, out numElements);
        }

        //Método para crear una asignatura en la BD
        public bool CrearAsignatura(string codigo, string nombre, string descripcion,
            bool optativa, bool vigente)
        {
            try
            {
                AsignaturaCP cp = new AsignaturaCP();
                cp.CrearAsignatura(codigo, nombre, descripcion, optativa, vigente);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular una asignatura a partir de su id a textboxes
        public bool VincularAsignaturaPorId(int id, TextBox TextBox_IdAsig,
            TextBox TextBox_CodAsig, TextBox TextBox_NomAsig, TextBox TextBox_DescAsig,
            CheckBox CheckBox_OptativaAsig, CheckBox CheckBox_VigenteAsig)
        {
            try
            {
                AsignaturaBinding binding = new AsignaturaBinding();
                DameAsignaturaPorId consulta = new DameAsignaturaPorId(id);

                binding.VincularDameAsignatura(consulta, TextBox_IdAsig,
                    TextBox_CodAsig, TextBox_NomAsig, TextBox_DescAsig,
                    CheckBox_OptativaAsig, CheckBox_VigenteAsig);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Método para modificar una asignatura en la BD
        public bool ModificarAsignatura(int oid, string codAsignatura, string nombre,
            string descripcion, bool optativa, bool vigente)
        {
            try
            {
                AsignaturaCP cp = new AsignaturaCP();
                cp.ModificarAsignatura(oid, codAsignatura, nombre, descripcion, optativa, vigente);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para eliminar una asignatura de la BD
        public bool BorrarAsignatura(int id)
        {
            try
            {
                AsignaturaCP cp = new AsignaturaCP();
                cp.BorrarAsignatura(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
