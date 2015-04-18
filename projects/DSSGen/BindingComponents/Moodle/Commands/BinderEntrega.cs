using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderEntrega : IBinderEntrega
    {
        //Variables privadas
        private TextBox TextBox_Nom;
        private TextBox TextBox_Desc;
        private TextBox TextBox_Apertura;
        private TextBox TextBox_Cierre;
        private TextBox TextBox_PuntMax;

        private TextBox TextBox_Anyo;
        private TextBox TextBox_Asignatura;
        private TextBox TextBox_Evaluacion;
        private TextBox TextBox_Profesor;
        private TextBox TextBox_CodEntrega;

        //Crear el vinculador a partir de sus textboxes
        public BinderEntrega(TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertura, TextBox TextBox_Cierre,
            TextBox TextBox_PuntMax,
            TextBox TextBox_Anyo, TextBox TextBox_Asignatura, TextBox TextBox_Evaluacion, TextBox TextBox_Profesor, TextBox TextBox_CodEntrega)
        {
            this.TextBox_Nom = TextBox_Nom;
            this.TextBox_Desc = TextBox_Desc;
            this.TextBox_Apertura = TextBox_Apertura;
            this.TextBox_Cierre = TextBox_Cierre;
            this.TextBox_PuntMax = TextBox_PuntMax;

            this.TextBox_Anyo = TextBox_Anyo;
            this.TextBox_Asignatura = TextBox_Asignatura;
            this.TextBox_Evaluacion = TextBox_Evaluacion;
            this.TextBox_Profesor = TextBox_Profesor;
            this.TextBox_CodEntrega = TextBox_CodEntrega;
        }

        //Vincular el control
        public void Vincular(EntregaEN en)
        {
            //Vincular con los textboxes
            TextBox_Nom.Text = en.Nombre;
            TextBox_Desc.Text = en.Descripcion;
            TextBox_Apertura.Text = en.Fecha_apertura.ToString();
            TextBox_Cierre.Text = en.Fecha_cierre.ToString();
            TextBox_PuntMax.Text = en.Puntuacion_maxima.ToString();


            TextBox_Anyo.Text = en.Evaluacion.Asignatura.Anyo.Anyo.ToString();
            TextBox_Asignatura.Text = en.Evaluacion.Asignatura.Asignatura.Nombre.ToString() + "(" + TextBox_Anyo.Text + ")";
            TextBox_Evaluacion.Text = en.Evaluacion.Evaluacion.Nombre.ToString();
            TextBox_Profesor.Text = en.Profesor.Nombre;
            TextBox_CodEntrega.Text = en.Id.ToString();
        }
    }
}
