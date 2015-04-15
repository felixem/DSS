
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

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas_control;

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


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> Preguntas_control {
        get { return preguntas_control; } set { preguntas_control = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.PreguntaEN Pregunta {
        get { return pregunta; } set { pregunta = value;  }
}





public RespuestaEN()
{
        preguntas_control = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.PreguntaControlEN>();
}



public RespuestaEN(int id, string contenido, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas_control, DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta)
{
        this.init (id, contenido, preguntas_control, pregunta);
}


public RespuestaEN(RespuestaEN respuesta)
{
        this.init (respuesta.Id, respuesta.Contenido, respuesta.Preguntas_control, respuesta.Pregunta);
}

private void init (int id, string contenido, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas_control, DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Preguntas_control = preguntas_control;

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
