using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using System.Web.UI.WebControls;

namespace BindingComponents.Moodle.Commands
{
    //Clase utilizada para vincular textboxes para las vistas
    public class BinderEntregaAlumnoLigero : IBinderEntregaAlumno
    {
        //Variables privadas
        private TextBox TextBox_Cod;
        private TextBox TextBox_NomAlu;
        private TextBox TextBox_ApeAlu;
        private TextBox TextBox_Dni;
        private TextBox TextBox_ComentAlu;
        private TextBox TextBox_Nota;
        private TextBox TextBox_ComentProf;

        private CheckBox CheckBox_Corregido;

        //Crear el vinculador a partir de sus textboxes
        public BinderEntregaAlumnoLigero(TextBox TextBox_Cod,
                    TextBox TextBox_NomAlu, TextBox TextBox_ApeAlu, TextBox TextBox_Dni,
                    TextBox TextBox_ComentAlu, TextBox TextBox_Nota,
                    CheckBox CheckBox_Corregido, TextBox TextBox_ComentProf)
        {
            this.TextBox_Cod = TextBox_Cod;
            this.TextBox_NomAlu = TextBox_NomAlu;
            this.TextBox_ApeAlu = TextBox_ApeAlu;
            this.TextBox_Dni = TextBox_Dni;
            this.TextBox_ComentAlu = TextBox_ComentAlu;
            this.TextBox_Nota = TextBox_Nota;
            this.TextBox_ComentProf = TextBox_ComentProf;

            this.CheckBox_Corregido = CheckBox_Corregido;
        }

        //Vincular el control
        public void Vincular(EntregaAlumnoEN en)
        {
            //Vincular con los textboxes
            TextBox_Cod.Text = en.Id.ToString();
            TextBox_NomAlu.Text = en.Evaluacion_alumno.Expediente_evaluacion.Expediente_asignatura.Expediente_anyo.Expediente.Alumno.Nombre;
            TextBox_ApeAlu.Text = en.Evaluacion_alumno.Expediente_evaluacion.Expediente_asignatura.Expediente_anyo.Expediente.Alumno.Apellidos;
            TextBox_Dni.Text = en.Evaluacion_alumno.Expediente_evaluacion.Expediente_asignatura.Expediente_anyo.Expediente.Alumno.Dni;
            TextBox_ComentAlu.Text = en.Comentario_alumno;
            TextBox_Nota.Text = en.Nota.ToString();
            TextBox_ComentProf.Text = en.Comentario_profesor;
            CheckBox_Corregido.Checked = en.Corregido;
        }
    }
}

