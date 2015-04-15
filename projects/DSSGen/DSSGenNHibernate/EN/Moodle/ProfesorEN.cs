
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ProfesorEN                 :                           DSSGenNHibernate.EN.Moodle.UsuarioComunEN


{
/**
 *
 */

private int cod_profesor;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas_propuestas;

/**
 *
 */

private System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas;





public virtual int Cod_profesor {
        get { return cod_profesor; } set { cod_profesor = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> Tutorias {
        get { return tutorias; } set { tutorias = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> Materiales {
        get { return materiales; } set { materiales = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> Entregas_propuestas {
        get { return entregas_propuestas; } set { entregas_propuestas = value;  }
}


public virtual System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> Asignaturas {
        get { return asignaturas; } set { asignaturas = value;  }
}





public ProfesorEN() : base ()
{
        tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
        materiales = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MaterialEN>();
        entregas_propuestas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaEN>();
        asignaturas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN>();
}



public ProfesorEN(string email, int cod_profesor, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas_propuestas, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.init (email, cod_profesor, tutorias, materiales, entregas_propuestas, asignaturas, mensajes, dni, password, nombre, apellidos, fecha_nacimiento);
}


public ProfesorEN(ProfesorEN profesor)
{
        this.init (profesor.Email, profesor.Cod_profesor, profesor.Tutorias, profesor.Materiales, profesor.Entregas_propuestas, profesor.Asignaturas, profesor.Mensajes, profesor.Dni, profesor.Password, profesor.Nombre, profesor.Apellidos, profesor.Fecha_nacimiento);
}

private void init (string email, int cod_profesor, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas_propuestas, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN> asignaturas, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes, string dni, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento)
{
        this.Email = email;


        this.Cod_profesor = cod_profesor;

        this.Tutorias = tutorias;

        this.Materiales = materiales;

        this.Entregas_propuestas = entregas_propuestas;

        this.Asignaturas = asignaturas;

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
        ProfesorEN t = obj as ProfesorEN;
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
