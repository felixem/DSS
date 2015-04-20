
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class AdministradorEN                    :                           DSSGenNHibernate.EN.Moodle.UsuarioEN


{
/**
 *
 */

private int cod_administrador;

/**
 *
 */

private string ocupacion;





public virtual int Cod_administrador {
        get { return cod_administrador; } set { cod_administrador = value;  }
}


public virtual string Ocupacion {
        get { return ocupacion; } set { ocupacion = value;  }
}





public AdministradorEN() : base ()
{
}



public AdministradorEN(string email, int cod_administrador, string ocupacion, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.init (email, cod_administrador, ocupacion, dni, password, nombre, apellidos, fecha_nacimiento);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.Email, administrador.Cod_administrador, administrador.Ocupacion, administrador.Dni, administrador.Password, administrador.Nombre, administrador.Apellidos, administrador.Fecha_nacimiento);
}

private void init (string email, int cod_administrador, string ocupacion, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.Email = email;


        this.Cod_administrador = cod_administrador;

        this.Ocupacion = ocupacion;

        this.Dni = dni;

        this.Password = password;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Fecha_nacimiento = fecha_nacimiento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
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
