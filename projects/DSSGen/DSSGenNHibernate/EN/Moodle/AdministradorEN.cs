
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AdministradorEN
{
/**
 *
 */

private string nick;

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

private string descripcion;





public virtual string Nick {
        get { return nick; } set { nick = value;  }
}


public virtual String Password {
        get { return password; } set { password = value;  }
}


public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}


public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public AdministradorEN()
{
}



public AdministradorEN(string nick, String password, string nombre, string descripcion)
{
        this.init (nick, password, nombre, descripcion);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.Nick, administrador.Password, administrador.Nombre, administrador.Descripcion);
}

private void init (string nick, String password, string nombre, string descripcion)
{
        this.Nick = nick;


        this.Password = password;

        this.Nombre = nombre;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (Nick.Equals (t.Nick))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nick.GetHashCode ();
        return hash;
}
}
}
