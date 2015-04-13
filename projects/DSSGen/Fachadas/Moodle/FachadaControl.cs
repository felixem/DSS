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

namespace Fachadas.Moodle
{
    public class FachadaControl
    {
        //Metodo que registra el control en BD
        public bool RegistrarControl(string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura,
            Nullable<DateTime> p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima,
            float p_penalizacion_fallo, int p_sistema_evaluacion)
        {
            try
            {
                ControlCP control = new ControlCP();
                control.CrearControl(p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo, p_sistema_evaluacion);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    
        //Metodo que modifica el control en BD
        public bool ModificarControl(int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura,
            Nullable<DateTime> p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima, float p_penalizacion_fallo)
        {
            try
            {
                ControlCP cp = new ControlCP();
                cp.ModificarControl(p_oid, p_nombre, p_descripcion, p_fecha_apertura, p_fecha_cierre, p_duracion_minutos, p_puntuacion_maxima, p_penalizacion_fallo);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Método para vincular un control a partir de su id a textboxes
        public bool VincularControlPorId(int id, TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertura, TextBox TextBox_Cierre,
            TextBox TextBox_Duracion, TextBox TextBox_PuntMax, TextBox TextBox_Penalizacion)
        {
            try
            {
                ControlBinding binding = new ControlBinding();
                DameControlPorId consulta = new DameControlPorId(id);
                BinderControl linker = new BinderControl(TextBox_Nom,
                    TextBox_Desc, TextBox_Apertura, TextBox_Cierre,
                    TextBox_Duracion, TextBox_PuntMax, TextBox_Penalizacion);

                binding.VincularDameControl(consulta, linker);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
