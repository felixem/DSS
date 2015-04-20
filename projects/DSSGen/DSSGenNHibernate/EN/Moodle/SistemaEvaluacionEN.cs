
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class SistemaEvaluacionEN
{
/**
 *
 */

private int id;

/**
 *
 */

private float puntuacion_maxima;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> evaluaciones_alumno;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> controles;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual float Puntuacion_maxima {
        get { return puntuacion_maxima; } set { puntuacion_maxima = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> Entregas {
        get { return entregas; } set { entregas = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.EvaluacionEN Evaluacion {
        get { return evaluacion; } set { evaluacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> Evaluaciones_alumno {
        get { return evaluaciones_alumno; } set { evaluaciones_alumno = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> Controles {
        get { return controles; } set { controles = value;  }
}





public SistemaEvaluacionEN()
{
        entregas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaEN>();
        evaluaciones_alumno = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN>();
        controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlEN>();
}



public SistemaEvaluacionEN(int id, float puntuacion_maxima, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura, DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> evaluaciones_alumno, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> controles)
{
        this.init (id, puntuacion_maxima, entregas, asignatura, evaluacion, evaluaciones_alumno, controles);
}


public SistemaEvaluacionEN(SistemaEvaluacionEN sistemaEvaluacion)
{
        this.init (sistemaEvaluacion.Id, sistemaEvaluacion.Puntuacion_maxima, sistemaEvaluacion.Entregas, sistemaEvaluacion.Asignatura, sistemaEvaluacion.Evaluacion, sistemaEvaluacion.Evaluaciones_alumno, sistemaEvaluacion.Controles);
}

private void init (int id, float puntuacion_maxima, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura, DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN> evaluaciones_alumno, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlEN> controles)
{
        this.Id = id;


        this.Puntuacion_maxima = puntuacion_maxima;

        this.Entregas = entregas;

        this.Asignatura = asignatura;

        this.Evaluacion = evaluacion;

        this.Evaluaciones_alumno = evaluaciones_alumno;

        this.Controles = controles;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SistemaEvaluacionEN t = obj as SistemaEvaluacionEN;
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
