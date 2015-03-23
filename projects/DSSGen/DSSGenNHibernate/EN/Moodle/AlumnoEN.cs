
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AlumnoEN                   :                           DSSGenNHibernate.EN.Moodle.UsuarioEN


{
/**
 *
 */

private int cod_alumno;

/**
 *
 */

private bool baneado;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> sistemas_evaluacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles;





public virtual int Cod_alumno {
        get { return cod_alumno; } set { cod_alumno = value;  }
}


public virtual bool Baneado {
        get { return baneado; } set { baneado = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> Tutorias {
        get { return tutorias; } set { tutorias = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> Grupos_trabajo {
        get { return grupos_trabajo; } set { grupos_trabajo = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ExpedienteEN Expediente {
        get { return expediente; } set { expediente = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> Entregas {
        get { return entregas; } set { entregas = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> Sistemas_evaluacion {
        get { return sistemas_evaluacion; } set { sistemas_evaluacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> Controles {
        get { return controles; } set { controles = value;  }
}





public AlumnoEN() : base ()
{
        tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
        grupos_trabajo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();
        entregas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
        sistemas_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN>();
        controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
}



public AlumnoEN(int id, int cod_alumno, bool baneado, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo, DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> sistemas_evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles, string dni, string email, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.init (id, cod_alumno, baneado, tutorias, grupos_trabajo, expediente, entregas, sistemas_evaluacion, controles, dni, email, password, nombre, apellidos, fecha_nacimiento, mensajes);
}


public AlumnoEN(AlumnoEN alumno)
{
        this.init (alumno.Id, alumno.Cod_alumno, alumno.Baneado, alumno.Tutorias, alumno.Grupos_trabajo, alumno.Expediente, alumno.Entregas, alumno.Sistemas_evaluacion, alumno.Controles, alumno.Dni, alumno.Email, alumno.Password, alumno.Nombre, alumno.Apellidos, alumno.Fecha_nacimiento, alumno.Mensajes);
}

private void init (int id, int cod_alumno, bool baneado, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo, DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> sistemas_evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles, string dni, string email, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.Id = id;


        this.Cod_alumno = cod_alumno;

        this.Baneado = baneado;

        this.Tutorias = tutorias;

        this.Grupos_trabajo = grupos_trabajo;

        this.Expediente = expediente;

        this.Entregas = entregas;

        this.Sistemas_evaluacion = sistemas_evaluacion;

        this.Controles = controles;

        this.Dni = dni;

        this.Email = email;

        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nacimiento = fecha_nacimiento;

        this.Mensajes = mensajes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AlumnoEN t = obj as AlumnoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
