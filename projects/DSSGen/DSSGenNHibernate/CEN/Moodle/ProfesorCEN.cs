

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace DSSGenNHibernate.CEN.Moodle
{
public partial class ProfesorCEN
{
private IProfesorCAD _IProfesorCAD;

public ProfesorCEN()
{
        this._IProfesorCAD = new ProfesorCAD ();
}

public ProfesorCEN(IProfesorCAD _IProfesorCAD)
{
        this._IProfesorCAD = _IProfesorCAD;
}

public IProfesorCAD get_IProfesorCAD ()
{
        return this._IProfesorCAD;
}

public int New_ (int p_cod_profesor, string p_dni, string p_email, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        ProfesorEN profesorEN = null;
        int oid;

        //Initialized ProfesorEN
        profesorEN = new ProfesorEN ();
        profesorEN.Cod_profesor = p_cod_profesor;

        profesorEN.Dni = p_dni;

        profesorEN.Email = p_email;

        profesorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        profesorEN.Nombre = p_nombre;

        profesorEN.Apellidos = p_apellidos;

        profesorEN.Fecha_nacimiento = p_fecha_nacimiento;

        //Call to ProfesorCAD

        oid = _IProfesorCAD.New_ (profesorEN);
        return oid;
}

public void Modify (int p_oid, int p_cod_profesor, string p_dni, string p_email, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        ProfesorEN profesorEN = null;

        //Initialized ProfesorEN
        profesorEN = new ProfesorEN ();
        profesorEN.Id = p_oid;
        profesorEN.Cod_profesor = p_cod_profesor;
        profesorEN.Dni = p_dni;
        profesorEN.Email = p_email;
        profesorEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        profesorEN.Nombre = p_nombre;
        profesorEN.Apellidos = p_apellidos;
        profesorEN.Fecha_nacimiento = p_fecha_nacimiento;
        //Call to ProfesorCAD

        _IProfesorCAD.Modify (profesorEN);
}

public void Destroy (int id)
{
        _IProfesorCAD.Destroy (id);
}

public System.Collections.Generic.IList<ProfesorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ProfesorEN> list = null;

        list = _IProfesorCAD.ReadAll (first, size);
        return list;
}
public ProfesorEN ReadOID (int id)
{
        ProfesorEN profesorEN = null;

        profesorEN = _IProfesorCAD.ReadOID (id);
        return profesorEN;
}

public void Relationer_entregas_propuestas (int p_profesor, System.Collections.Generic.IList<int> p_entrega)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Relationer_entregas_propuestas (p_profesor, p_entrega);
}
public void Relationer_materiales (int p_profesor, System.Collections.Generic.IList<int> p_material)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Relationer_materiales (p_profesor, p_material);
}
public void Relationer_mensajes (int p_profesor, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Relationer_mensajes (p_profesor, p_mensaje);
}
public void Relationer_tutorias (int p_profesor, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Relationer_tutorias (p_profesor, p_tutoria);
}
public void Unrelationer_entregas_propuestas (int p_profesor, System.Collections.Generic.IList<int> p_entrega)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Unrelationer_entregas_propuestas (p_profesor, p_entrega);
}
public void Unrelationer_materiales (int p_profesor, System.Collections.Generic.IList<int> p_material)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Unrelationer_materiales (p_profesor, p_material);
}
public void Unrelationer_mensajes (int p_profesor, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Unrelationer_mensajes (p_profesor, p_mensaje);
}
public void Unrelationer_tutorias (int p_profesor, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to ProfesorCAD

        _IProfesorCAD.Unrelationer_tutorias (p_profesor, p_tutoria);
}
}
}
