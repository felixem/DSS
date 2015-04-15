
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class PreguntaEN
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

private string explicacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas_control;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.RespuestaEN> respuestas;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.RespuestaEN respuesta_correcta;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsa;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}


public virtual string Explicacion {
        get { return explicacion; } set { explicacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> Preguntas_control {
        get { return preguntas_control; } set { preguntas_control = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.RespuestaEN> Respuestas {
        get { return respuestas; } set { respuestas = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.RespuestaEN Respuesta_correcta {
        get { return respuesta_correcta; } set { respuesta_correcta = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN Bolsa {
        get { return bolsa; } set { bolsa = value;  }
}





public PreguntaEN()
{
        preguntas_control = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.PreguntaControlEN>();
        respuestas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.RespuestaEN>();
}



public PreguntaEN(int id, string contenido, string explicacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas_control, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.RespuestaEN> respuestas, DSSGenNHibernate.EN.Moodle.RespuestaEN respuesta_correcta, DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsa)
{
        this.init (id, contenido, explicacion, preguntas_control, respuestas, respuesta_correcta, bolsa);
}


public PreguntaEN(PreguntaEN pregunta)
{
        this.init (pregunta.Id, pregunta.Contenido, pregunta.Explicacion, pregunta.Preguntas_control, pregunta.Respuestas, pregunta.Respuesta_correcta, pregunta.Bolsa);
}

private void init (int id, string contenido, string explicacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas_control, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.RespuestaEN> respuestas, DSSGenNHibernate.EN.Moodle.RespuestaEN respuesta_correcta, DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN bolsa)
{
        this.Id = id;


        this.Contenido = contenido;

        this.Explicacion = explicacion;

        this.Preguntas_control = preguntas_control;

        this.Respuestas = respuestas;

        this.Respuesta_correcta = respuesta_correcta;

        this.Bolsa = bolsa;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PreguntaEN t = obj as PreguntaEN;
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
