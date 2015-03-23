
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class MaterialEN
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

private string descripcion;

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

private Nullable<DateTime> fecha_subida;

/**
 *
 */

private bool visible;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.ProfesorEN profesor;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual string Ruta {
        get { return ruta; } set { ruta = value;  }
}


public virtual float Tam {
        get { return tam; } set { tam = value;  }
}


public virtual Nullable<DateTime> Fecha_subida {
        get { return fecha_subida; } set { fecha_subida = value;  }
}


public virtual bool Visible {
        get { return visible; } set { visible = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.ProfesorEN Profesor {
        get { return profesor; } set { profesor = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}





public MaterialEN()
{
}



public MaterialEN(int id, string nombre, string descripcion, string ruta, float tam, Nullable<DateTime> fecha_subida, bool visible, DSSGenNHibernate.EN.Moodle.ProfesorEN profesor, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura)
{
        this.init (id, nombre, descripcion, ruta, tam, fecha_subida, visible, profesor, asignatura);
}


public MaterialEN(MaterialEN material)
{
        this.init (material.Id, material.Nombre, material.Descripcion, material.Ruta, material.Tam, material.Fecha_subida, material.Visible, material.Profesor, material.Asignatura);
}

private void init (int id, string nombre, string descripcion, string ruta, float tam, Nullable<DateTime> fecha_subida, bool visible, DSSGenNHibernate.EN.Moodle.ProfesorEN profesor, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Ruta = ruta;

        this.Tam = tam;

        this.Fecha_subida = fecha_subida;

        this.Visible = visible;

        this.Profesor = profesor;

        this.Asignatura = asignatura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MaterialEN t = obj as MaterialEN;
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
