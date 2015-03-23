
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

private DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AlumnoEN alumno;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN Sistema_evaluacion {
        get { return sistema_evaluacion; } set { sistema_evaluacion = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}





public EvaluacionAlumnoEN()
{
}



public EvaluacionAlumnoEN(int id, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno)
{
        this.init (id, sistema_evaluacion, alumno);
}


public EvaluacionAlumnoEN(EvaluacionAlumnoEN evaluacionAlumno)
{
        this.init (evaluacionAlumno.Id, evaluacionAlumno.Sistema_evaluacion, evaluacionAlumno.Alumno);
}

private void init (int id, DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN sistema_evaluacion, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno)
{
        this.Id = id;


        this.Sistema_evaluacion = sistema_evaluacion;

        this.Alumno = alumno;
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
