using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderEntregaAlumnoMuyLigero : IBinderEntregaAlumno
    {
        //Variables privadas
        private TextBox TextBox_Nom;
        private TextBox TextBox_Desc;
        private TextBox TextBox_Apertu;
        private TextBox TextBox_Cierre;
        private TextBox TextBox_Punt;
        private TextBox TextBox_Comentario;

        //Crear el vinculador a partir de sus textboxes
        public BinderEntregaAlumnoMuyLigero(TextBox TextBox_Nom,
                    TextBox TextBox_Desc, TextBox TextBox_Apertu, TextBox TextBox_Cierre,
                    TextBox TextBox_Punt, TextBox TextBox_Comentario)
        {
            this.TextBox_Nom = TextBox_Nom;
            this.TextBox_Desc = TextBox_Desc;
            this.TextBox_Apertu = TextBox_Apertu;
            this.TextBox_Cierre = TextBox_Cierre;
            this.TextBox_Punt = TextBox_Punt;
            this.TextBox_Comentario = TextBox_Comentario;
        }

        //Vincular el control
        public void Vincular(EntregaAlumnoEN en)
        {
            //Vincular con los textboxes
            this.TextBox_Nom.Text = en.Entrega.Nombre;
            this.TextBox_Desc.Text = en.Entrega.Descripcion;
            this.TextBox_Apertu.Text = en.Entrega.Fecha_apertura.ToString();
            this.TextBox_Cierre.Text = en.Entrega.Fecha_cierre.ToString();
            this.TextBox_Punt.Text = en.Entrega.Puntuacion_maxima.ToString();
            this.TextBox_Comentario.Text = en.Comentario_alumno;
        }
    }
}

