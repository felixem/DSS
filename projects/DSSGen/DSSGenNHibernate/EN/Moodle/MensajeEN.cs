
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class MensajeEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string contenido;

/**
 *
 */

private Nullable<DateTime> fecha;

/**
 *
 */

private bool respondido;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.TutoriaEN tutoria;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.UsuarioComunEN usuario;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}


public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}


public virtual bool Respondido {
        get { return respondido; } set { respondido = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.TutoriaEN Tutoria {
        get { return tutoria; } set { tutoria = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.UsuarioComunEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public MensajeEN()
{
}



public MensajeEN(int id, string contenido, Nullable<DateTime> fecha, bool respondido, DSSGenNHibernate.EN.Moodle.TutoriaEN tutoria, DSSGenNHibernate.EN.Moodle.UsuarioComunEN usuario)
{
        this.init (id, contenido, fecha, respondido, tutoria, usuario);
}


public MensajeEN(MensajeEN mensaje)
{
        this.init (mensaje.Id, mensaje.Contenido, mensaje.Fecha, mensaje.Respondido, mensaje.Tutoria, mensaje.Usuario);
}

private void init (int id, string contenido, Nullable<DateTime> fecha, bool respondido, DSSGenNHibernate.EN.Moodle.TutoriaEN tutoria, DSSGenNHibernate.EN.Moodle.UsuarioComunEN usuario)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Fecha = fecha;

        this.Respondido = respondido;

        this.Tutoria = tutoria;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MensajeEN t = obj as MensajeEN;
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
