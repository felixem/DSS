
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class EntregaAlumnoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string nombre_fichero;

/**
 *
 */

private string extension;

/**
 *
 */

private string ruta;

/**
 *
 */

private float tam;

/**
 *
 */

private Nullable<DateTime> fecha_entrega;

/**
 *
 */

private float nota;

/**
 *
 */

private bool corregido;

/**
 *
 */

private string comentario_alumno;

/**
 *
 */

private string comentario_profesor;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.EntregaEN entrega;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacion_alumno;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre_fichero {
        get { return nombre_fichero; } set { nombre_fichero = value;  }
}


public virtual string Extension {
        get { return extension; } set { extension = value;  }
}


public virtual string Ruta {
        get { return ruta; } set { ruta = value;  }
}


public virtual float Tam {
        get { return tam; } set { tam = value;  }
}


public virtual Nullable<DateTime> Fecha_entrega {
        get { return fecha_entrega; } set { fecha_entrega = value;  }
}


public virtual float Nota {
        get { return nota; } set { nota = value;  }
}


public virtual bool Corregido {
        get { return corregido; } set { corregido = value;  }
}


public virtual string Comentario_alumno {
        get { return comentario_alumno; } set { comentario_alumno = value;  }
}


public virtual string Comentario_profesor {
        get { return comentario_profesor; } set { comentario_profesor = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.EntregaEN Entrega {
        get { return entrega; } set { entrega = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN Evaluacion_alumno {
        get { return evaluacion_alumno; } set { evaluacion_alumno = value;  }
}





public EntregaAlumnoEN()
{
}



public EntregaAlumnoEN(int id, string nombre_fichero, string extension, string ruta, float tam, Nullable<DateTime> fecha_entrega, float nota, bool corregido, string comentario_alumno, string comentario_profesor, DSSGenNHibernate.EN.Moodle.EntregaEN entrega, DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacion_alumno)
{
        this.init (id, nombre_fichero, extension, ruta, tam, fecha_entrega, nota, corregido, comentario_alumno, comentario_profesor, entrega, evaluacion_alumno);
}


public EntregaAlumnoEN(EntregaAlumnoEN entregaAlumno)
{
        this.init (entregaAlumno.Id, entregaAlumno.Nombre_fichero, entregaAlumno.Extension, entregaAlumno.Ruta, entregaAlumno.Tam, entregaAlumno.Fecha_entrega, entregaAlumno.Nota, entregaAlumno.Corregido, entregaAlumno.Comentario_alumno, entregaAlumno.Comentario_profesor, entregaAlumno.Entrega, entregaAlumno.Evaluacion_alumno);
}

private void init (int id, string nombre_fichero, string extension, string ruta, float tam, Nullable<DateTime> fecha_entrega, float nota, bool corregido, string comentario_alumno, string comentario_profesor, DSSGenNHibernate.EN.Moodle.EntregaEN entrega, DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN evaluacion_alumno)
{
        this.Id = id;


        this.Nombre_fichero = nombre_fichero;

        this.Extension = extension;

        this.Ruta = ruta;

        this.Tam = tam;

        this.Fecha_entrega = fecha_entrega;

        this.Nota = nota;

        this.Corregido = corregido;

        this.Comentario_alumno = comentario_alumno;

        this.Comentario_profesor = comentario_profesor;

        this.Entrega = entrega;

        this.Evaluacion_alumno = evaluacion_alumno;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EntregaAlumnoEN t = obj as EntregaAlumnoEN;
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
