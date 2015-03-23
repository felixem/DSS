
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class GrupoTrabajoEN
{
/**
 *
 */

private int id;

/**
 *
 */

private int cod_grupo;

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

private String password;

/**
 *
 */

private int capacidad;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> alumnos;

/**
 *
 */

private DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual int Cod_grupo {
        get { return cod_grupo; } set { cod_grupo = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}


public virtual String Password {
        get { return password; } set { password = value;  }
}


public virtual int Capacidad {
        get { return capacidad; } set { capacidad = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> Alumnos {
        get { return alumnos; } set { alumnos = value;  }
}


public virtual DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN Asignatura {
        get { return asignatura; } set { asignatura = value;  }
}





public GrupoTrabajoEN()
{
        alumnos = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AlumnoEN>();
}



public GrupoTrabajoEN(int id, int cod_grupo, string nombre, string descripcion, String password, int capacidad, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> alumnos, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura)
{
        this.init (id, cod_grupo, nombre, descripcion, password, capacidad, alumnos, asignatura);
}


public GrupoTrabajoEN(GrupoTrabajoEN grupoTrabajo)
{
        this.init (grupoTrabajo.Id, grupoTrabajo.Cod_grupo, grupoTrabajo.Nombre, grupoTrabajo.Descripcion, grupoTrabajo.Password, grupoTrabajo.Capacidad, grupoTrabajo.Alumnos, grupoTrabajo.Asignatura);
}

private void init (int id, int cod_grupo, string nombre, string descripcion, String password, int capacidad, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AlumnoEN> alumnos, DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN asignatura)
{
        this.Id = id;


        this.Cod_grupo = cod_grupo;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Password = password;

        this.Capacidad = capacidad;

        this.Alumnos = alumnos;

        this.Asignatura = asignatura;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GrupoTrabajoEN t = obj as GrupoTrabajoEN;
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
