
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class CursoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string cod_curso;

/**
 *
 */

private string nombre;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> asignaturas;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Cod_curso {
        get { return cod_curso; } set { cod_curso = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> Asignaturas {
        get { return asignaturas; } set { asignaturas = value;  }
}





public CursoEN()
{
        asignaturas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaEN>();
}



public CursoEN(int id, string cod_curso, string nombre, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> asignaturas)
{
        this.init (id, cod_curso, nombre, asignaturas);
}


public CursoEN(CursoEN curso)
{
        this.init (curso.Id, curso.Cod_curso, curso.Nombre, curso.Asignaturas);
}

private void init (int id, string cod_curso, string nombre, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaEN> asignaturas)
{
        this.Id = id;


        this.Cod_curso = cod_curso;

        this.Nombre = nombre;

        this.Asignaturas = asignaturas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CursoEN t = obj as CursoEN;
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
