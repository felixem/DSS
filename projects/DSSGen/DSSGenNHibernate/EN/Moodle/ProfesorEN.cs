
using System;

namespace DSSGenNHibernate.EN.Moodle
{
public partial class ProfesorEN                 :                           DSSGenNHibernate.EN.Moodle.UsuarioEN


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





public ProfesorEN() : base ()
{
        tutorias = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.TutoriaEN>();
        materiales = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.MaterialEN>();
        entregas_propuestas = new System.Collections.Generic.List<DSSGenNHibernate.EN.Moodle.EntregaEN>();
}



public ProfesorEN(int id, int cod_profesor, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas_propuestas, string dni, string email, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.init (id, cod_profesor, tutorias, materiales, entregas_propuestas, dni, email, password, nombre, apellidos, fecha_nacimiento, mensajes);
}


public ProfesorEN(ProfesorEN profesor)
{
        this.init (profesor.Id, profesor.Cod_profesor, profesor.Tutorias, profesor.Materiales, profesor.Entregas_propuestas, profesor.Dni, profesor.Email, profesor.Password, profesor.Nombre, profesor.Apellidos, profesor.Fecha_nacimiento, profesor.Mensajes);
}

private void init (int id, int cod_profesor, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.TutoriaEN> tutorias, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MaterialEN> materiales, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.EntregaEN> entregas_propuestas, string dni, string email, String password, string nombre, string apellidos, Nullable<DateTime> fecha_nacimiento, System.Collections.Generic.IList<DSSGenNHibernate.EN.Moodle.MensajeEN> mensajes)
{
        this.Id = id;


        this.Cod_profesor = cod_profesor;

        this.Tutorias = tutorias;

        this.Materiales = materiales;

        this.Entregas_propuestas = entregas_propuestas;

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
        ProfesorEN t = obj as ProfesorEN;
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
