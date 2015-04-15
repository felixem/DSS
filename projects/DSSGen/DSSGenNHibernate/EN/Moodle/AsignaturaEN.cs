
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AsignaturaEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string cod_asignatura;

/**
 *
 */

private string nombre;

/**
 *
 */

private string descripcion;

/**
 *
 */

private bool optativa;

/**
 *
 */

private bool vigente;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.CursoEN curso;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas_anyo;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> bolsas_preguntas;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Cod_asignatura {
        get { return cod_asignatura; } set { cod_asignatura = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual bool Optativa {
        get { return optativa; } set { optativa = value;  }
}


public virtual bool Vigente {
        get { return vigente; } set { vigente = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.CursoEN Curso {
        get { return curso; } set { curso = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> Asignaturas_anyo {
        get { return asignaturas_anyo; } set { asignaturas_anyo = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> Bolsas_preguntas {
        get { return bolsas_preguntas; } set { bolsas_preguntas = value;  }
}





public AsignaturaEN()
{
        asignaturas_anyo = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
        bolsas_preguntas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN>();
}



public AsignaturaEN(int id, string cod_asignatura, string nombre, string descripcion, bool optativa, bool vigente, DSSGenNHibernate.EN.Moodle.CursoEN curso, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas_anyo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> bolsas_preguntas)
{
        this.init (id, cod_asignatura, nombre, descripcion, optativa, vigente, curso, asignaturas_anyo, bolsas_preguntas);
}


public AsignaturaEN(AsignaturaEN asignatura)
{
        this.init (asignatura.Id, asignatura.Cod_asignatura, asignatura.Nombre, asignatura.Descripcion, asignatura.Optativa, asignatura.Vigente, asignatura.Curso, asignatura.Asignaturas_anyo, asignatura.Bolsas_preguntas);
}

private void init (int id, string cod_asignatura, string nombre, string descripcion, bool optativa, bool vigente, DSSGenNHibernate.EN.Moodle.CursoEN curso, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas_anyo, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN> bolsas_preguntas)
{
        this.Id = id;


        this.Cod_asignatura = cod_asignatura;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Optativa = optativa;

        this.Vigente = vigente;

        this.Curso = curso;

        this.Asignaturas_anyo = asignaturas_anyo;

        this.Bolsas_preguntas = bolsas_preguntas;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AsignaturaEN t = obj as AsignaturaEN;
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
