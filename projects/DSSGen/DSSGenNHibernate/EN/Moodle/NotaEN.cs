
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class NotaEN
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

private string abreviatura;

/**
 *
 */

private int ponderacion;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> expedientes;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Abreviatura {
        get { return abreviatura; } set { abreviatura = value;  }
}


public virtual int Ponderacion {
        get { return ponderacion; } set { ponderacion = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> Expedientes {
        get { return expedientes; } set { expedientes = value;  }
}





public NotaEN()
{
        expedientes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN>();
}



public NotaEN(int id, string nombre, string abreviatura, int ponderacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> expedientes)
{
        this.init (id, nombre, abreviatura, ponderacion, expedientes);
}


public NotaEN(NotaEN nota)
{
        this.init (nota.Id, nota.Nombre, nota.Abreviatura, nota.Ponderacion, nota.Expedientes);
}

private void init (int id, string nombre, string abreviatura, int ponderacion, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN> expedientes)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Abreviatura = abreviatura;

        this.Ponderacion = ponderacion;

        this.Expedientes = expedientes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotaEN t = obj as NotaEN;
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
