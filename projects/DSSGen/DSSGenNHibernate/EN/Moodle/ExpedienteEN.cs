
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ExpedienteEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string cod_expediente;

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

private DSSGenNHibernate.EN.Moodle.AlumnoEN alumno;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> expedientes_anyo;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Cod_expediente {
        get { return cod_expediente; } set { cod_expediente = value;  }
}


public virtual float Nota_media {
        get { return nota_media; } set { nota_media = value;  }
}


public virtual bool Abierto {
        get { return abierto; } set { abierto = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AlumnoEN Alumno {
        get { return alumno; } set { alumno = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> Expedientes_anyo {
        get { return expedientes_anyo; } set { expedientes_anyo = value;  }
}





public ExpedienteEN()
{
        expedientes_anyo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN>();
}



public ExpedienteEN(int id, string cod_expediente, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> expedientes_anyo)
{
        this.init (id, cod_expediente, nota_media, abierto, alumno, expedientes_anyo);
}


public ExpedienteEN(ExpedienteEN expediente)
{
        this.init (expediente.Id, expediente.Cod_expediente, expediente.Nota_media, expediente.Abierto, expediente.Alumno, expediente.Expedientes_anyo);
}

private void init (int id, string cod_expediente, float nota_media, bool abierto, DSSGenNHibernate.EN.Moodle.AlumnoEN alumno, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN> expedientes_anyo)
{
        this.Id = id;


        this.Cod_expediente = cod_expediente;

        this.Nota_media = nota_media;

        this.Abierto = abierto;

        this.Alumno = alumno;

        this.Expedientes_anyo = expedientes_anyo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ExpedienteEN t = obj as ExpedienteEN;
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
