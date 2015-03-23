
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AsignaturaAnyoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaEN asignatura;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> sistemas_evaluacion;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> Tutorias {
        get { return tutorias; } set { tutorias = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> Materiales {
        get { return materiales; } set { materiales = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> Grupos_trabajo {
        get { return grupos_trabajo; } set { grupos_trabajo = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN Anyo {
        get { return anyo; } set { anyo = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> Sistemas_evaluacion {
        get { return sistemas_evaluacion; } set { sistemas_evaluacion = value;  }
}





public AsignaturaAnyoEN()
{
        tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
        materiales = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MaterialEN>();
        grupos_trabajo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN>();
        sistemas_evaluacion = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN>();
}



public AsignaturaAnyoEN(int id, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo, DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo, DSSGenNHibernate.EN.Moodle.AsignaturaEN asignatura, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> sistemas_evaluacion)
{
        this.init (id, tutorias, materiales, grupos_trabajo, anyo, asignatura, sistemas_evaluacion);
}


public AsignaturaAnyoEN(AsignaturaAnyoEN asignaturaAnyo)
{
        this.init (asignaturaAnyo.Id, asignaturaAnyo.Tutorias, asignaturaAnyo.Materiales, asignaturaAnyo.Grupos_trabajo, asignaturaAnyo.Anyo, asignaturaAnyo.Asignatura, asignaturaAnyo.Sistemas_evaluacion);
}

private void init (int id, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.GrupoTrabajoEN> grupos_trabajo, DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo, DSSGenNHibernate.EN.Moodle.AsignaturaEN asignatura, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN> sistemas_evaluacion)
{
        this.Id = id;


        this.Tutorias = tutorias;

        this.Materiales = materiales;

        this.Grupos_trabajo = grupos_trabajo;

        this.Anyo = anyo;

        this.Asignatura = asignatura;

        this.Sistemas_evaluacion = sistemas_evaluacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AsignaturaAnyoEN t = obj as AsignaturaAnyoEN;
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
