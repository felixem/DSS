

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

public int New_ (int p_cod_alumno, bool p_baneado, string p_dni, string p_email, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, DSSGenNHibernate.EN.Moodle.ExpedienteEN p_expediente)
{
        AlumnoEN alumnoEN = null;
        int oid;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Cod_alumno = p_cod_alumno;

        alumnoEN.Baneado = p_baneado;

        alumnoEN.Dni = p_dni;

        alumnoEN.Email = p_email;

        alumnoEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        alumnoEN.Nombre = p_nombre;

        alumnoEN.Apellidos = p_apellidos;

        alumnoEN.Fecha_nacimiento = p_fecha_nacimiento;

        alumnoEN.Expediente = p_expediente;

        //Call to AlumnoCAD

        oid = _IAlumnoCAD.New_ (alumnoEN);
        return oid;
}

public void Modify (int p_oid, int p_cod_alumno, bool p_baneado, string p_dni, string p_email, String p_password, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        AlumnoEN alumnoEN = null;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Id = p_oid;
        alumnoEN.Cod_alumno = p_cod_alumno;
        alumnoEN.Baneado = p_baneado;
        alumnoEN.Dni = p_dni;
        alumnoEN.Email = p_email;
        alumnoEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        alumnoEN.Nombre = p_nombre;
        alumnoEN.Apellidos = p_apellidos;
        alumnoEN.Fecha_nacimiento = p_fecha_nacimiento;
        //Call to AlumnoCAD

        _IAlumnoCAD.Modify (alumnoEN);
}

public void Destroy (int id)
{
        _IAlumnoCAD.Destroy (id);
}

public System.Collections.Generic.IList<AlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AlumnoEN> list = null;

        list = _IAlumnoCAD.ReadAll (first, size);
        return list;
}
public AlumnoEN ReadOID (int id)
{
        AlumnoEN alumnoEN = null;

        alumnoEN = _IAlumnoCAD.ReadOID (id);
        return alumnoEN;
}

public void Relationer_controles (int p_alumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_controles (p_alumno, p_controlalumno);
}
public void Relationer_entregas (int p_alumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_entregas (p_alumno, p_entregaalumno);
}
public void Relationer_expediente (int p_alumno, int p_expediente)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_expediente (p_alumno, p_expediente);
}
public void Relationer_grupos_trabajo (int p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_grupos_trabajo (p_alumno, p_grupotrabajo);
}
public void Relationer_mensajes (int p_alumno, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_mensajes (p_alumno, p_mensaje);
}
public void Relationer_sistemas_evaluacion (int p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_sistemas_evaluacion (p_alumno, p_evaluacionalumno);
}
public void Relationer_tutorias (int p_alumno, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Relationer_tutorias (p_alumno, p_tutoria);
}
public void Unrelationer_controles (int p_alumno, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_controles (p_alumno, p_controlalumno);
}
public void Unrelationer_entregas (int p_alumno, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_entregas (p_alumno, p_entregaalumno);
}
public void Unrelationer_expediente (int p_alumno, int p_expediente)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_expediente (p_alumno, p_expediente);
}
public void Unrelationer_grupos_trabajo (int p_alumno, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_grupos_trabajo (p_alumno, p_grupotrabajo);
}
public void Unrelationer_mensajes (int p_alumno, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_mensajes (p_alumno, p_mensaje);
}
public void Unrelationer_sistemas_evaluacion (int p_alumno, System.Collections.Generic.IList<int> p_evaluacionalumno)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_sistemas_evaluacion (p_alumno, p_evaluacionalumno);
}
public void Unrelationer_tutorias (int p_alumno, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to AlumnoCAD

        _IAlumnoCAD.Unrelationer_tutorias (p_alumno, p_tutoria);
}
}
}
