
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class UsuarioComunEN                     :                           DSSGenNHibernate.EN.Moodle.UsuarioEN


{
/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes;





public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> Mensajes {
        get { return mensajes; } set { mensajes = value;  }
}





public UsuarioComunEN() : base ()
{
        mensajes = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MensajeEN>();
}



public UsuarioComunEN(string email, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.init (email, mensajes, dni, password, nombre, apellidos, fecha_nacimiento);
}


public UsuarioComunEN(UsuarioComunEN usuarioComun)
{
        this.init (usuarioComun.Email, usuarioComun.Mensajes, usuarioComun.Dni, usuarioComun.Password, usuarioComun.Nombre, usuarioComun.Apellidos, usuarioComun.Fecha_nacimiento);
}

private void init (string email, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.Email = email;


        this.Mensajes = mensajes;

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
        UsuarioComunEN t = obj as UsuarioComunEN;
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
