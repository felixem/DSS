
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AnyoAcademicoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private int anyo;

/**
 *
 */

private Nullable<DateTime> fecha_inicio;

/**
 *
 */

private Nullable<DateTime> fecha_fin;

/**
 *
 */

private bool finalizado;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> evaluaciones;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> expedientes_anyo;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual int Anyo {
        get { return anyo; } set { anyo = value;  }
}


public virtual Nullable<DateTime> Fecha_inicio {
        get { return fecha_inicio; } set { fecha_inicio = value;  }
}


public virtual Nullable<DateTime> Fecha_fin {
        get { return fecha_fin; } set { fecha_fin = value;  }
}


public virtual bool Finalizado {
        get { return finalizado; } set { finalizado = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> Evaluaciones {
        get { return evaluaciones; } set { evaluaciones = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> Expedientes_anyo {
        get { return expedientes_anyo; } set { expedientes_anyo = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> Asignaturas {
        get { return asignaturas; } set { asignaturas = value;  }
}





public AnyoAcademicoEN()
{
        evaluaciones = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EvaluacionEN>();
        expedientes_anyo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN>();
        asignaturas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
}



public AnyoAcademicoEN(int id, int anyo, Nullable<DateTime> fecha_inicio, Nullable<DateTime> fecha_fin, bool finalizado, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> evaluaciones, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> expedientes_anyo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas)
{
        this.init (id, anyo, fecha_inicio, fecha_fin, finalizado, evaluaciones, expedientes_anyo, asignaturas);
}


public AnyoAcademicoEN(AnyoAcademicoEN anyoAcademico)
{
        this.init (anyoAcademico.Id, anyoAcademico.Anyo, anyoAcademico.Fecha_inicio, anyoAcademico.Fecha_fin, anyoAcademico.Finalizado, anyoAcademico.Evaluaciones, anyoAcademico.Expedientes_anyo, anyoAcademico.Asignaturas);
}

private void init (int id, int anyo, Nullable<DateTime> fecha_inicio, Nullable<DateTime> fecha_fin, bool finalizado, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EvaluacionEN> evaluaciones, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> expedientes_anyo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas)
{
        this.Id = id;


        this.Anyo = anyo;

        this.Fecha_inicio = fecha_inicio;

        this.Fecha_fin = fecha_fin;

        this.Finalizado = finalizado;

        this.Evaluaciones = evaluaciones;

        this.Expedientes_anyo = expedientes_anyo;

        this.Asignaturas = asignaturas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AnyoAcademicoEN t = obj as AnyoAcademicoEN;
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
