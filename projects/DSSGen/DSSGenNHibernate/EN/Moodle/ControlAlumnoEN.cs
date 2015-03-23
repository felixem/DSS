
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ControlAlumnoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private float nota;

/**
 *
 */

private bool terminado;

/**
 *
 */

private bool corregido;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AlumnoEN alumno;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ControlEN control;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual float Nota {
        get { return nota; } set { nota = value;  }
}


public virtual bool Terminado {
        get { return terminado; } set { terminado = value;  }
}


public virtual bool Corregido {
        get { return corregido; } set { corregido = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ControlEN Control {
        get { return control; } set { control = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> Preguntas {
        get { return preguntas; } set { preguntas = value;  }
}





public ControlAlumnoEN()
{
        preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.PreguntaControlEN>();
}



public ControlAlumnoEN(int id, float nota, bool terminado, bool corregido, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno, DSSGenNHibernate.EN.Moodle.ControlEN control, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas)
{
        this.init (id, nota, terminado, corregido, alumno, control, preguntas);
}


public ControlAlumnoEN(ControlAlumnoEN controlAlumno)
{
        this.init (controlAlumno.Id, controlAlumno.Nota, controlAlumno.Terminado, controlAlumno.Corregido, controlAlumno.Alumno, controlAlumno.Control, controlAlumno.Preguntas);
}

private void init (int id, float nota, bool terminado, bool corregido, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno, DSSGenNHibernate.EN.Moodle.ControlEN control, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaControlEN> preguntas)
{
        this.Id = id;


        this.Nota = nota;

        this.Terminado = terminado;

        this.Corregido = corregido;

        this.Alumno = alumno;

        this.Control = control;

        this.Preguntas = preguntas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ControlAlumnoEN t = obj as ControlAlumnoEN;
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
