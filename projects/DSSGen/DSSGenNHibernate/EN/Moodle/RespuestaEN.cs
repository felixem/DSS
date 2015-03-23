
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class RespuestaEN
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

private DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.PreguntaEN Pregunta {
        get { return pregunta; } set { pregunta = value;  }
}





public RespuestaEN()
{
}



public RespuestaEN(int id, string contenido, DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta)
{
        this.init (id, contenido, pregunta);
}


public RespuestaEN(RespuestaEN respuesta)
{
        this.init (respuesta.Id, respuesta.Contenido, respuesta.Pregunta);
}

private void init (int id, string contenido, DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Pregunta = pregunta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RespuestaEN t = obj as RespuestaEN;
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
