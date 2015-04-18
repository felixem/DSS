
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class EvaluacionAlumnoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expediente_evaluacion;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> Entregas {
        get { return entregas; } set { entregas = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN Sistema_evaluacion {
        get { return sistema_evaluacion; } set { sistema_evaluacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> Controles {
        get { return controles; } set { controles = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN Expediente_evaluacion {
        get { return expediente_evaluacion; } set { expediente_evaluacion = value;  }
}





public EvaluacionAlumnoEN()
{
        entregas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN>();
        controles = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN>();
}



public EvaluacionAlumnoEN(int id, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles, DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expediente_evaluacion)
{
        this.init (id, entregas, sistema_evaluacion, controles, expediente_evaluacion);
}


public EvaluacionAlumnoEN(EvaluacionAlumnoEN evaluacionAlumno)
{
        this.init (evaluacionAlumno.Id, evaluacionAlumno.Entregas, evaluacionAlumno.Sistema_evaluacion, evaluacionAlumno.Controles, evaluacionAlumno.Expediente_evaluacion);
}

private void init (int id, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN> entregas, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ControlAlumnoEN> controles, DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN expediente_evaluacion)
{
        this.Id = id;


        this.Entregas = entregas;

        this.Sistema_evaluacion = sistema_evaluacion;

        this.Controles = controles;

        this.Expediente_evaluacion = expediente_evaluacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EvaluacionAlumnoEN t = obj as EvaluacionAlumnoEN;
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
