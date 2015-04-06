

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
public partial class AlumnoCEN
{
private IAlumnoCAD _IAlumnoCAD;

public AlumnoCEN()
{
        this._IAlumnoCAD = new AlumnoCAD ();
}

public AlumnoCEN(IAlumnoCAD _IAlumnoCAD)
{
        this._IAlumnoCAD = _IAlumnoCAD;
}

public IAlumnoCAD get_IAlumnoCAD ()
{
        return this._IAlumnoCAD;
}

public string New_ (int p_cod_alumno, bool p_baneado, string p_email, string p_dni, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, DSSGenNHibernate.EN.Moodle.ExpedienteEN p_expediente)
{
        AlumnoEN alumnoEN = null;
        string oid;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Cod_alumno = p_cod_alumno;

        alumnoEN.Baneado = p_baneado;

        alumnoEN.Email = p_email;

        alumnoEN.Dni = p_dni;

        alumnoEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        alumnoEN.Nombre = p_nombre;

        alumnoEN.Apellidos = p_apellidos;

        alumnoEN.Fecha_nacimiento = p_fecha_nacimiento;

        alumnoEN.Expediente = p_expediente;

        //Call to AlumnoCAD

        oid = _IAlumnoCAD.New_ (alumnoEN);
        return oid;
}

public void Modify (string p_oid, int p_cod_alumno, bool p_baneado, string p_dni, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        AlumnoEN alumnoEN = null;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Email = p_oid;
        alumnoEN.Cod_alumno = p_cod_alumno;
        alumnoEN.Baneado = p_baneado;
        alumnoEN.Dni = p_dni;
        alumnoEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        alumnoEN.Nombre = p_nombre;
        alumnoEN.Apellidos = p_apellidos;
        alumnoEN.Fecha_nacimiento = p_fecha_nacimiento;
        //Call to AlumnoCAD

        _IAlumnoCAD.Modify (alumnoEN);
}

public void Destroy (string email)
{
        _IAlumnoCAD.Destroy (email);
}

public System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlumnoEN> list = null;

        list = _IAlumnoCAD.ReadAll (first, size);
        return list;
}
public AlumnoEN ReadOID (string email)
{
        AlumnoEN alumnoEN = null;

        alumnoEN = _IAlumnoCAD.ReadOID (email);
        return alumnoEN;
}

public long ReadCantidad ()
{
        return _IAlumnoCAD.ReadCantidad ();
}
public void Relationer_controles (string p_alumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_controles (p_alumno, p_controlalumno);
}
public void Relationer_entregas (string p_alumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_entregas (p_alumno, p_entregaalumno);
}
public void Relationer_expediente (string p_alumno, int p_expediente)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_expediente (p_alumno, p_expediente);
}
public void Relationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_grupos_trabajo (p_alumno, p_grupotrabajo);
}
public void Relationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_mensajes (p_alumno, p_mensaje);
}
public void Relationer_sistemas_evaluacion (string p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_sistemas_evaluacion (p_alumno, p_evaluacionalumno);
}
public void Relationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_tutorias (p_alumno, p_tutoria);
}
public void Unrelationer_controles (string p_alumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_controles (p_alumno, p_controlalumno);
}
public void Unrelationer_entregas (string p_alumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_entregas (p_alumno, p_entregaalumno);
}
public void Unrelationer_expediente (string p_alumno, int p_expediente)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_expediente (p_alumno, p_expediente);
}
public void Unrelationer_grupos_trabajo (string p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_grupos_trabajo (p_alumno, p_grupotrabajo);
}
public void Unrelationer_mensajes (string p_alumno, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_mensajes (p_alumno, p_mensaje);
}
public void Unrelationer_sistemas_evaluacion (string p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_sistemas_evaluacion (p_alumno, p_evaluacionalumno);
}
public void Unrelationer_tutorias (string p_alumno, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_tutorias (p_alumno, p_tutoria);
}
}
}
