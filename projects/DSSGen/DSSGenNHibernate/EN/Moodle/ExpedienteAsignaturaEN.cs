
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ExpedienteAsignaturaEN
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

private DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expediente_anyo;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.NotaEN nota;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> expedientes_evaluacion;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual float Nota_media {
        get { return nota_media; } set { nota_media = value;  }
}


public virtual bool Abierto {
        get { return abierto; } set { abierto = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN Expediente_anyo {
        get { return expediente_anyo; } set { expediente_anyo = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.NotaEN Nota {
        get { return nota; } set { nota = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> Expedientes_evaluacion {
        get { return expedientes_evaluacion; } set { expedientes_evaluacion = value;  }
}





public ExpedienteAsignaturaEN()
{
        expedientes_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN>();
}



public ExpedienteAsignaturaEN(int id, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expediente_anyo, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura, DSSGenNHibernate.EN.Moodle.NotaEN nota, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> expedientes_evaluacion)
{
        this.init (id, nota_media, abierto, expediente_anyo, asignatura, nota, expedientes_evaluacion);
}


public ExpedienteAsignaturaEN(ExpedienteAsignaturaEN expedienteAsignatura)
{
        this.init (expedienteAsignatura.Id, expedienteAsignatura.Nota_media, expedienteAsignatura.Abierto, expedienteAsignatura.Expediente_anyo, expedienteAsignatura.Asignatura, expedienteAsignatura.Nota, expedienteAsignatura.Expedientes_evaluacion);
}

private void init (int id, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN expediente_anyo, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura, DSSGenNHibernate.EN.Moodle.NotaEN nota, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> expedientes_evaluacion)
{
        this.Id = id;


        this.Nota_media = nota_media;

        this.Abierto = abierto;

        this.Expediente_anyo = expediente_anyo;

        this.Asignatura = asignatura;

        this.Nota = nota;

        this.Expedientes_evaluacion = expedientes_evaluacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ExpedienteAsignaturaEN t = obj as ExpedienteAsignaturaEN;
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
