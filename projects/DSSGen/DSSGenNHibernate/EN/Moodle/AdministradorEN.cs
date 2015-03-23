
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AdministradorEN
{
/**
 *
 */

private int id;

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





public virtual int Id {
        get { return id; } set { id = value;  }
}


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



public AdministradorEN(int id, string nick, String password, string nombre, string descripcion)
{
        this.init (id, nick, password, nombre, descripcion);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.Id, administrador.Nick, administrador.Password, administrador.Nombre, administrador.Descripcion);
}

private void init (int id, string nick, String password, string nombre, string descripcion)
{
        this.Id = id;


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
