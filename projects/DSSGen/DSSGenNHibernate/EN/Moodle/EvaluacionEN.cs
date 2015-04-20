
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class EvaluacionEN
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

private Nullable<DateTime> fecha_inicio;

/**
 *
 */

private Nullable<DateTime> fecha_fin;

/**
 *
 */

private bool abierta;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo_academico;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> sistemas_evaluacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> expedientes;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual Nullable<DateTime> Fecha_inicio {
        get { return fecha_inicio; } set { fecha_inicio = value;  }
}


public virtual Nullable<DateTime> Fecha_fin {
        get { return fecha_fin; } set { fecha_fin = value;  }
}


public virtual bool Abierta {
        get { return abierta; } set { abierta = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN Anyo_academico {
        get { return anyo_academico; } set { anyo_academico = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> Sistemas_evaluacion {
        get { return sistemas_evaluacion; } set { sistemas_evaluacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> Expedientes {
        get { return expedientes; } set { expedientes = value;  }
}





public EvaluacionEN()
{
        sistemas_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN>();
        expedientes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN>();
}



public EvaluacionEN(int id, string nombre, Nullable<DateTime> fecha_inicio, Nullable<DateTime> fecha_fin, bool abierta, DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo_academico, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> sistemas_evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> expedientes)
{
        this.init (id, nombre, fecha_inicio, fecha_fin, abierta, anyo_academico, sistemas_evaluacion, expedientes);
}


public EvaluacionEN(EvaluacionEN evaluacion)
{
        this.init (evaluacion.Id, evaluacion.Nombre, evaluacion.Fecha_inicio, evaluacion.Fecha_fin, evaluacion.Abierta, evaluacion.Anyo_academico, evaluacion.Sistemas_evaluacion, evaluacion.Expedientes);
}

private void init (int id, string nombre, Nullable<DateTime> fecha_inicio, Nullable<DateTime> fecha_fin, bool abierta, DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo_academico, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> sistemas_evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN> expedientes)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Fecha_inicio = fecha_inicio;

        this.Fecha_fin = fecha_fin;

        this.Abierta = abierta;

        this.Anyo_academico = anyo_academico;

        this.Sistemas_evaluacion = sistemas_evaluacion;

        this.Expedientes = expedientes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EvaluacionEN t = obj as EvaluacionEN;
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
