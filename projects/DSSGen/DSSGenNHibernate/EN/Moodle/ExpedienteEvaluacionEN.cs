
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ExpedienteEvaluacionEN
{
/**
 *
 */

private int id;

/**
 *
 */

private float nota_media;

/**
 *
 */

private bool abierto;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expediente_asignatura;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacion;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual float Nota_media {
        get { return nota_media; } set { nota_media = value;  }
}


public virtual bool Abierto {
        get { return abierto; } set { abierto = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN Expediente_asignatura {
        get { return expediente_asignatura; } set { expediente_asignatura = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.EvaluacionEN Evaluacion {
        get { return evaluacion; } set { evaluacion = value;  }
}





public ExpedienteEvaluacionEN()
{
}



public ExpedienteEvaluacionEN(int id, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expediente_asignatura, DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacion)
{
        this.init (id, nota_media, abierto, expediente_asignatura, evaluacion);
}


public ExpedienteEvaluacionEN(ExpedienteEvaluacionEN expedienteEvaluacion)
{
        this.init (expedienteEvaluacion.Id, expedienteEvaluacion.Nota_media, expedienteEvaluacion.Abierto, expedienteEvaluacion.Expediente_asignatura, expedienteEvaluacion.Evaluacion);
}

private void init (int id, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN expediente_asignatura, DSSGenNHibernate.EN.Moodle.EvaluacionEN evaluacion)
{
        this.Id = id;


        this.Nota_media = nota_media;

        this.Abierto = abierto;

        this.Expediente_asignatura = expediente_asignatura;

        this.Evaluacion = evaluacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ExpedienteEvaluacionEN t = obj as ExpedienteEvaluacionEN;
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
