
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class PreguntaControlEN
{
/**
 *
 */

private int id;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ControlAlumnoEN control;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.RespuestaEN respuesta_elegida;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ControlAlumnoEN Control {
        get { return control; } set { control = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.PreguntaEN Pregunta {
        get { return pregunta; } set { pregunta = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.RespuestaEN Respuesta_elegida {
        get { return respuesta_elegida; } set { respuesta_elegida = value;  }
}





public PreguntaControlEN()
{
}



public PreguntaControlEN(int id, DSSGenNHibernate.EN.Moodle.ControlAlumnoEN control, DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta, DSSGenNHibernate.EN.Moodle.RespuestaEN respuesta_elegida)
{
        this.init (id, control, pregunta, respuesta_elegida);
}


public PreguntaControlEN(PreguntaControlEN preguntaControl)
{
        this.init (preguntaControl.Id, preguntaControl.Control, preguntaControl.Pregunta, preguntaControl.Respuesta_elegida);
}

private void init (int id, DSSGenNHibernate.EN.Moodle.ControlAlumnoEN control, DSSGenNHibernate.EN.Moodle.PreguntaEN pregunta, DSSGenNHibernate.EN.Moodle.RespuestaEN respuesta_elegida)
{
        this.Id = id;


        this.Control = control;

        this.Pregunta = pregunta;

        this.Respuesta_elegida = respuesta_elegida;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PreguntaControlEN t = obj as PreguntaControlEN;
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
