
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class EntregaEN
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

private float puntuacion_maxima;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ProfesorEN profesor;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN evaluacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas_alumno;





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


public virtual float Puntuacion_maxima {
        get { return puntuacion_maxima; } set { puntuacion_maxima = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ProfesorEN Profesor {
        get { return profesor; } set { profesor = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN Evaluacion {
        get { return evaluacion; } set { evaluacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> Entregas_alumno {
        get { return entregas_alumno; } set { entregas_alumno = value;  }
}





public EntregaEN()
{
        entregas_alumno = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
}



public EntregaEN(int id, string nombre, string descripcion, Nullable<DateTime> fecha_apertura, Nullable<DateTime> fecha_cierre, float puntuacion_maxima, DSSGenNHibernate.EN.Moodle.ProfesorEN profesor, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas_alumno)
{
        this.init (id, nombre, descripcion, fecha_apertura, fecha_cierre, puntuacion_maxima, profesor, evaluacion, entregas_alumno);
}


public EntregaEN(EntregaEN entrega)
{
        this.init (entrega.Id, entrega.Nombre, entrega.Descripcion, entrega.Fecha_apertura, entrega.Fecha_cierre, entrega.Puntuacion_maxima, entrega.Profesor, entrega.Evaluacion, entrega.Entregas_alumno);
}

private void init (int id, string nombre, string descripcion, Nullable<DateTime> fecha_apertura, Nullable<DateTime> fecha_cierre, float puntuacion_maxima, DSSGenNHibernate.EN.Moodle.ProfesorEN profesor, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas_alumno)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Fecha_apertura = fecha_apertura;

        this.Fecha_cierre = fecha_cierre;

        this.Puntuacion_maxima = puntuacion_maxima;

        this.Profesor = profesor;

        this.Evaluacion = evaluacion;

        this.Entregas_alumno = entregas_alumno;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EntregaEN t = obj as EntregaEN;
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
