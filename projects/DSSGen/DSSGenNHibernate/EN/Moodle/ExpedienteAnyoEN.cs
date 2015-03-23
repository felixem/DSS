
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ExpedienteAnyoEN
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

private DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> expedientes_asignatura;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual float Nota_media {
        get { return nota_media; } set { nota_media = value;  }
}


public virtual bool Abierto {
        get { return abierto; } set { abierto = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ExpedienteEN Expediente {
        get { return expediente; } set { expediente = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN Anyo {
        get { return anyo; } set { anyo = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> Expedientes_asignatura {
        get { return expedientes_asignatura; } set { expedientes_asignatura = value;  }
}





public ExpedienteAnyoEN()
{
        expedientes_asignatura = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN>();
}



public ExpedienteAnyoEN(int id, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente, DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> expedientes_asignatura)
{
        this.init (id, nota_media, abierto, expediente, anyo, expedientes_asignatura);
}


public ExpedienteAnyoEN(ExpedienteAnyoEN expedienteAnyo)
{
        this.init (expedienteAnyo.Id, expedienteAnyo.Nota_media, expedienteAnyo.Abierto, expedienteAnyo.Expediente, expedienteAnyo.Anyo, expedienteAnyo.Expedientes_asignatura);
}

private void init (int id, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.ExpedienteEN expediente, DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN anyo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> expedientes_asignatura)
{
        this.Id = id;


        this.Nota_media = nota_media;

        this.Abierto = abierto;

        this.Expediente = expediente;

        this.Anyo = anyo;

        this.Expedientes_asignatura = expedientes_asignatura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ExpedienteAnyoEN t = obj as ExpedienteAnyoEN;
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
