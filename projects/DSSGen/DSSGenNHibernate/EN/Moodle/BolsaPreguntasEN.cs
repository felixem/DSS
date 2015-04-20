
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class BolsaPreguntasEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string nombre;

/**
 *
 */

private string descripcion;

/**
 *
 */

private Nullable<DateTime> fecha_creacion;

/**
 *
 */

private Nullable<DateTime> fecha_modificacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> controles;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> preguntas;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaEN asignatura;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual Nullable<DateTime> Fecha_creacion {
        get { return fecha_creacion; } set { fecha_creacion = value;  }
}


public virtual Nullable<DateTime> Fecha_modificacion {
        get { return fecha_modificacion; } set { fecha_modificacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> Controles {
        get { return controles; } set { controles = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> Preguntas {
        get { return preguntas; } set { preguntas = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}





public BolsaPreguntasEN()
{
        controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlEN>();
        preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.PreguntaEN>();
}



public BolsaPreguntasEN(int id, string nombre, string descripcion, Nullable<DateTime> fecha_creacion, Nullable<DateTime> fecha_modificacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> controles, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> preguntas, DSSGenNHibernate.EN.Moodle.AsignaturaEN asignatura)
{
        this.init (id, nombre, descripcion, fecha_creacion, fecha_modificacion, controles, preguntas, asignatura);
}


public BolsaPreguntasEN(BolsaPreguntasEN bolsaPreguntas)
{
        this.init (bolsaPreguntas.Id, bolsaPreguntas.Nombre, bolsaPreguntas.Descripcion, bolsaPreguntas.Fecha_creacion, bolsaPreguntas.Fecha_modificacion, bolsaPreguntas.Controles, bolsaPreguntas.Preguntas, bolsaPreguntas.Asignatura);
}

private void init (int id, string nombre, string descripcion, Nullable<DateTime> fecha_creacion, Nullable<DateTime> fecha_modificacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> controles, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.PreguntaEN> preguntas, DSSGenNHibernate.EN.Moodle.AsignaturaEN asignatura)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Fecha_creacion = fecha_creacion;

        this.Fecha_modificacion = fecha_modificacion;

        this.Controles = controles;

        this.Preguntas = preguntas;

        this.Asignatura = asignatura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        BolsaPreguntasEN t = obj as BolsaPreguntasEN;
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
