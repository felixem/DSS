
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class TutoriaEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string tema;

/**
 *
 */

private bool abierta;

/**
 *
 */

private Nullable<DateTime> fecha_creacion;

/**
 *
 */

private Nullable<DateTime> fecha_cierre;

/**
 *
 */

private bool por_responder;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ProfesorEN profesor;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AlumnoEN alumno;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Tema {
        get { return tema; } set { tema = value;  }
}


public virtual bool Abierta {
        get { return abierta; } set { abierta = value;  }
}


public virtual Nullable<DateTime> Fecha_creacion {
        get { return fecha_creacion; } set { fecha_creacion = value;  }
}


public virtual Nullable<DateTime> Fecha_cierre {
        get { return fecha_cierre; } set { fecha_cierre = value;  }
}


public virtual bool Por_responder {
        get { return por_responder; } set { por_responder = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> Mensajes {
        get { return mensajes; } set { mensajes = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ProfesorEN Profesor {
        get { return profesor; } set { profesor = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}





public TutoriaEN()
{
        mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
}



public TutoriaEN(int id, string tema, bool abierta, Nullable<DateTime> fecha_creacion, Nullable<DateTime> fecha_cierre, bool por_responder, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, DSSGenNHibernate.EN.Moodle.ProfesorEN profesor, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura)
{
        this.init (id, tema, abierta, fecha_creacion, fecha_cierre, por_responder, mensajes, profesor, alumno, asignatura);
}


public TutoriaEN(TutoriaEN tutoria)
{
        this.init (tutoria.Id, tutoria.Tema, tutoria.Abierta, tutoria.Fecha_creacion, tutoria.Fecha_cierre, tutoria.Por_responder, tutoria.Mensajes, tutoria.Profesor, tutoria.Alumno, tutoria.Asignatura);
}

private void init (int id, string tema, bool abierta, Nullable<DateTime> fecha_creacion, Nullable<DateTime> fecha_cierre, bool por_responder, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, DSSGenNHibernate.EN.Moodle.ProfesorEN profesor, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura)
{
        this.Id = id;


        this.Tema = tema;

        this.Abierta = abierta;

        this.Fecha_creacion = fecha_creacion;

        this.Fecha_cierre = fecha_cierre;

        this.Por_responder = por_responder;

        this.Mensajes = mensajes;

        this.Profesor = profesor;

        this.Alumno = alumno;

        this.Asignatura = asignatura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TutoriaEN t = obj as TutoriaEN;
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
