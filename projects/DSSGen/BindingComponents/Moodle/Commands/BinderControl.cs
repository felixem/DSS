using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderControl : IBinderControl
    {
        //Variables privadas
        private TextBox TextBox_Nom;
        private TextBox TextBox_Desc;
        private TextBox TextBox_Apertura;
        private TextBox TextBox_Cierre;
        private TextBox TextBox_Duracion;
        private TextBox TextBox_PuntMax;
        private TextBox TextBox_Penalizacion;

        //Crear el vinculador a partir de sus textboxes
        public BinderControl(TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertura, TextBox TextBox_Cierre,
            TextBox TextBox_Duracion, TextBox TextBox_PuntMax, TextBox TextBox_Penalizacion)
        {
            this.TextBox_Nom = TextBox_Nom;
            this.TextBox_Desc = TextBox_Desc;
            this.TextBox_Apertura = TextBox_Apertura;
            this.TextBox_Cierre = TextBox_Cierre;
            this.TextBox_Duracion = TextBox_Duracion;
            this.TextBox_PuntMax = TextBox_PuntMax;
            this.TextBox_Penalizacion = TextBox_Penalizacion;
        }

        //Vincular el control
        public void Vincular(ControlEN en)
        {
            //Vincular con los textboxes
            TextBox_Nom.Text = en.Nombre;
            TextBox_Desc.Text = en.Descripcion;
            TextBox_Apertura.Text = en.Fecha_apertura.ToString();
            TextBox_Cierre.Text = en.Fecha_cierre.ToString();
            TextBox_Duracion.Text = en.Duracion_minutos.ToString();
            TextBox_PuntMax.Text = en.Puntuacion_maxima.ToString();
            TextBox_Penalizacion.Text = en.Penalizacion_fallo.ToString();
        }
    }
}
