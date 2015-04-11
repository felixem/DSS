

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
public partial class TutoriaCEN
{
private ITutoriaCAD _ITutoriaCAD;

public TutoriaCEN()
{
        this._ITutoriaCAD = new TutoriaCAD ();
}

public TutoriaCEN(ITutoriaCAD _ITutoriaCAD)
{
        this._ITutoriaCAD = _ITutoriaCAD;
}

public ITutoriaCAD get_ITutoriaCAD ()
{
        return this._ITutoriaCAD;
}

public int New_ (string p_tema, bool p_abierta, Nullable<DateTime> p_fecha_creacion, Nullable<DateTime> p_fecha_cierre, bool p_por_responder, string p_profesor, string p_alumno, int p_asignatura)
{
        TutoriaEN tutoriaEN = null;
        int oid;

        //Initialized TutoriaEN
        tutoriaEN = new TutoriaEN ();
        tutoriaEN.Tema = p_tema;

        tutoriaEN.Abierta = p_abierta;

        tutoriaEN.Fecha_creacion = p_fecha_creacion;

        tutoriaEN.Fecha_cierre = p_fecha_cierre;

        tutoriaEN.Por_responder = p_por_responder;


        if (p_profesor != null) {
                tutoriaEN.Profesor = new DSSGenNHibernate.EN.Moodle.ProfesorEN ();
                tutoriaEN.Profesor.Email = p_profesor;
        }


        if (p_alumno != null) {
                tutoriaEN.Alumno = new DSSGenNHibernate.EN.Moodle.AlumnoEN ();
                tutoriaEN.Alumno.Email = p_alumno;
        }


        if (p_asignatura != -1) {
                tutoriaEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ();
                tutoriaEN.Asignatura.Id = p_asignatura;
        }

        //Call to TutoriaCAD

        oid = _ITutoriaCAD.New_ (tutoriaEN);
        return oid;
}

public void Modify (int p_oid, string p_tema, bool p_abierta, Nullable<DateTime> p_fecha_creacion, Nullable<DateTime> p_fecha_cierre, bool p_por_responder)
{
        TutoriaEN tutoriaEN = null;

        //Initialized TutoriaEN
        tutoriaEN = new TutoriaEN ();
        tutoriaEN.Id = p_oid;
        tutoriaEN.Tema = p_tema;
        tutoriaEN.Abierta = p_abierta;
        tutoriaEN.Fecha_creacion = p_fecha_creacion;
        tutoriaEN.Fecha_cierre = p_fecha_cierre;
        tutoriaEN.Por_responder = p_por_responder;
        //Call to TutoriaCAD

        _ITutoriaCAD.Modify (tutoriaEN);
}

public void Destroy (int id)
{
        _ITutoriaCAD.Destroy (id);
}

public System.Collections.Generic.IList<TutoriaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TutoriaEN> list = null;

        list = _ITutoriaCAD.ReadAll (first, size);
        return list;
}
public TutoriaEN ReadOID (int id)
{
        TutoriaEN tutoriaEN = null;

        tutoriaEN = _ITutoriaCAD.ReadOID (id);
        return tutoriaEN;
}

public long ReadCantidad ()
{
        return _ITutoriaCAD.ReadCantidad ();
}
public void Relationer_alumno (int p_tutoria, string p_alumno)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Relationer_alumno (p_tutoria, p_alumno);
}
public void Relationer_asignatura (int p_tutoria, int p_asignaturaanyo)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Relationer_asignatura (p_tutoria, p_asignaturaanyo);
}
public void Relationer_mensajes (int p_tutoria, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Relationer_mensajes (p_tutoria, p_mensaje);
}
public void Relationer_profesor (int p_tutoria, string p_profesor)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Relationer_profesor (p_tutoria, p_profesor);
}
public void Unrelationer_alumno (int p_tutoria, string p_alumno)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Unrelationer_alumno (p_tutoria, p_alumno);
}
public void Unrelationer_asignatura (int p_tutoria, int p_asignaturaanyo)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Unrelationer_asignatura (p_tutoria, p_asignaturaanyo);
}
public void Unrelationer_mensajes (int p_tutoria, System.Collections.Generic.IList<int> p_mensaje)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Unrelationer_mensajes (p_tutoria, p_mensaje);
}
public void Unrelationer_profesor (int p_tutoria, string p_profesor)
{
        //Call to TutoriaCAD

        _ITutoriaCAD.Unrelationer_profesor (p_tutoria, p_profesor);
}
}
}
