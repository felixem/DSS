
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AlumnoEN                   :                           DSSGenNHibernate.EN.Moodle.UsuarioComunEN


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





public AlumnoEN() : base ()
{
        tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
        grupos_trabajo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();
}



public AlumnoEN(string email, int cod_alumno, bool baneado, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo, DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.init (email, cod_alumno, baneado, tutorias, grupos_trabajo, expediente, mensajes, dni, password, nombre, apellidos, fecha_nacimiento);
}


public AlumnoEN(AlumnoEN alumno)
{
        this.init (alumno.Email, alumno.Cod_alumno, alumno.Baneado, alumno.Tutorias, alumno.Grupos_trabajo, alumno.Expediente, alumno.Mensajes, alumno.Dni, alumno.Password, alumno.Nombre, alumno.Apellidos, alumno.Fecha_nacimiento);
}

private void init (string email, int cod_alumno, bool baneado, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo, DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.Email = email;


        this.Cod_alumno = cod_alumno;

        this.Baneado = baneado;

        this.Tutorias = tutorias;

        this.Grupos_trabajo = grupos_trabajo;

        this.Expediente = expediente;

        this.Mensajes = mensajes;

        this.Dni = dni;

        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nacimiento = fecha_nacimiento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AlumnoEN t = obj as AlumnoEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
