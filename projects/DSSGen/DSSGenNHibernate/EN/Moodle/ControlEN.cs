
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ControlEN
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

private Nullable<DateTime> fecha_apertura;

/**
 *
 */

private Nullable<DateTime> fecha_cierre;

/**
 *
 */

private int duracion_minutos;

/**
 *
 */

private float puntuacion_maxima;

/**
 *
 */

private float penalizacion_fallo;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles_alumno;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> bolsas_preguntas;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual Nullable<DateTime> Fecha_apertura {
        get { return fecha_apertura; } set { fecha_apertura = value;  }
}


public virtual Nullable<DateTime> Fecha_cierre {
        get { return fecha_cierre; } set { fecha_cierre = value;  }
}


public virtual int Duracion_minutos {
        get { return duracion_minutos; } set { duracion_minutos = value;  }
}


public virtual float Puntuacion_maxima {
        get { return puntuacion_maxima; } set { puntuacion_maxima = value;  }
}


public virtual float Penalizacion_fallo {
        get { return penalizacion_fallo; } set { penalizacion_fallo = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> Controles_alumno {
        get { return controles_alumno; } set { controles_alumno = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> Bolsas_preguntas {
        get { return bolsas_preguntas; } set { bolsas_preguntas = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN Sistema_evaluacion {
        get { return sistema_evaluacion; } set { sistema_evaluacion = value;  }
}





public ControlEN()
{
        controles_alumno = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
        bolsas_preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN>();
}



public ControlEN(int id, string nombre, string descripcion, Nullable<DateTime> fecha_apertura, Nullable<DateTime> fecha_cierre, int duracion_minutos, float puntuacion_maxima, float penalizacion_fallo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles_alumno, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> bolsas_preguntas, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion)
{
        this.init (id, nombre, descripcion, fecha_apertura, fecha_cierre, duracion_minutos, puntuacion_maxima, penalizacion_fallo, controles_alumno, bolsas_preguntas, sistema_evaluacion);
}


public ControlEN(ControlEN control)
{
        this.init (control.Id, control.Nombre, control.Descripcion, control.Fecha_apertura, control.Fecha_cierre, control.Duracion_minutos, control.Puntuacion_maxima, control.Penalizacion_fallo, control.Controles_alumno, control.Bolsas_preguntas, control.Sistema_evaluacion);
}

private void init (int id, string nombre, string descripcion, Nullable<DateTime> fecha_apertura, Nullable<DateTime> fecha_cierre, int duracion_minutos, float puntuacion_maxima, float penalizacion_fallo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles_alumno, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> bolsas_preguntas, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Fecha_apertura = fecha_apertura;

        this.Fecha_cierre = fecha_cierre;

        this.Duracion_minutos = duracion_minutos;

        this.Puntuacion_maxima = puntuacion_maxima;

        this.Penalizacion_fallo = penalizacion_fallo;

        this.Controles_alumno = controles_alumno;

        this.Bolsas_preguntas = bolsas_preguntas;

        this.Sistema_evaluacion = sistema_evaluacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ControlEN t = obj as ControlEN;
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
