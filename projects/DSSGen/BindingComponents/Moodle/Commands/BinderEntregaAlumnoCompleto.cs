using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;
using WebUtilities;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderEntregaAlumnoCompleto : IBinderEntregaAlumno
    {
        //Variables privadas
        private TextBox TextBox_Nom;
        private TextBox TextBox_Desc;
        private TextBox TextBox_Apertu;
        private TextBox TextBox_Cierre;
        private TextBox TextBox_Punt;
        private TextBox TextBox_ComentarioAlumno;
        private TextBox TextBox_NombreArchivo;
        private TextBox TextBox_Nota;
        private TextBox TextBox_ComentarioProfesor;

        private Image Img_Corregido;

        //Crear el vinculador a partir de sus textboxes
        public BinderEntregaAlumnoCompleto(TextBox TextBox_Nom,
            TextBox TextBox_Desc, TextBox TextBox_Apertu, TextBox TextBox_Cierre, TextBox TextBox_Punt,
            TextBox TextBox_ComentarioAlumno, TextBox TextBox_NombreArchivo,
            Image Img_Corregido, TextBox TextBox_Nota, TextBox TextBox_ComentarioProfesor)
        {
            this.TextBox_Nom = TextBox_Nom;
            this.TextBox_Desc = TextBox_Desc;
            this.TextBox_Apertu = TextBox_Apertu;
            this.TextBox_Cierre = TextBox_Cierre;
            this.TextBox_Punt = TextBox_Punt;
            this.TextBox_ComentarioAlumno = TextBox_ComentarioAlumno;
            this.TextBox_NombreArchivo = TextBox_NombreArchivo;
            this.TextBox_Nota = TextBox_Nota;
            this.TextBox_ComentarioProfesor = TextBox_ComentarioProfesor;

            this.Img_Corregido = Img_Corregido;
        }

        //Vincular el control
        public void Vincular(EntregaAlumnoEN en)
        {
            //Vincular con los textboxes
            EntregaEN entrega = en.Entrega;

            this.TextBox_Nom.Text = entrega.Nombre;
            this.TextBox_Desc.Text = entrega.Descripcion;
            this.TextBox_Apertu.Text = entrega.Fecha_apertura.ToString();
            this.TextBox_Cierre.Text = entrega.Fecha_cierre.ToString();
            this.TextBox_Punt.Text = entrega.Puntuacion_maxima.ToString();
            this.TextBox_ComentarioAlumno.Text = en.Comentario_alumno;
            this.TextBox_NombreArchivo.Text = en.Nombre_fichero + en.Extension;
            this.TextBox_Nota.Text = en.Nota.ToString();
            this.TextBox_ComentarioProfesor.Text = en.Comentario_profesor;

            this.Img_Corregido.ImageUrl = ResourceFinder.CheckImg(en.Corregido);
        }
    }
}

