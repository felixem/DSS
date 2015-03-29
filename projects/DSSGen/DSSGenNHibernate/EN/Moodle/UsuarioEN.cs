
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class UsuarioEN
{
/**
 *
 */

private string email;

/**
 *
 */

private string dni;

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





public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual string Dni {
        get { return dni; } set { dni = value;  }
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



public UsuarioEN(string email, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.init (email, dni, password, nombre, apellidos, fecha_nacimiento, mensajes);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.Dni, usuario.Password, usuario.Nombre, usuario.Apellidos, usuario.Fecha_nacimiento, usuario.Mensajes);
}

private void init (string email, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.Email = email;


        this.Dni = dni;

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
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
