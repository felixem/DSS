
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class UsuarioEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string dni;

/**
 *
 */

private string email;

/**
 *
 */

private String password;

/**
 *
 */

private string nombre;

/**
 *
 */

private string apellidos;

/**
 *
 */

private Nullable<DateTime> fecha_nacimiento;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Dni {
        get { return dni; } set { dni = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual String Password {
        get { return password; } set { password = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}


public virtual Nullable<DateTime> Fecha_nacimiento {
        get { return fecha_nacimiento; } set { fecha_nacimiento = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> Mensajes {
        get { return mensajes; } set { mensajes = value;  }
}





public UsuarioEN()
{
        mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
}



public UsuarioEN(int id, string dni, string email, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.init (id, dni, email, password, nombre, apellidos, fecha_nacimiento, mensajes);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Id, usuario.Dni, usuario.Email, usuario.Password, usuario.Nombre, usuario.Apellidos, usuario.Fecha_nacimiento, usuario.Mensajes);
}

private void init (int id, string dni, string email, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.Id = id;


        this.Dni = dni;

        this.Email = email;

        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nacimiento = fecha_nacimiento;

        this.Mensajes = mensajes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
