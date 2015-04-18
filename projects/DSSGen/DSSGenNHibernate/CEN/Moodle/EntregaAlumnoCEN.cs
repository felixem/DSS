

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
public partial class EntregaAlumnoCEN
{
private IEntregaAlumnoCAD _IEntregaAlumnoCAD;

public EntregaAlumnoCEN()
{
        this._IEntregaAlumnoCAD = new EntregaAlumnoCAD ();
}

public EntregaAlumnoCEN(IEntregaAlumnoCAD _IEntregaAlumnoCAD)
{
        this._IEntregaAlumnoCAD = _IEntregaAlumnoCAD;
}

public IEntregaAlumnoCAD get_IEntregaAlumnoCAD ()
{
        return this._IEntregaAlumnoCAD;
}

public int New_ (string p_nombre_fichero, string p_extension, string p_ruta, float p_tam, Nullable<DateTime> p_fecha_entrega, float p_nota, bool p_corregido, string p_comentario_alumno, string p_comentario_profesor, int p_entrega, int p_evaluacion_alumno)
{
        EntregaAlumnoEN entregaAlumnoEN = null;
        int oid;

        //Initialized EntregaAlumnoEN
        entregaAlumnoEN = new EntregaAlumnoEN ();
        entregaAlumnoEN.Nombre_fichero = p_nombre_fichero;

        entregaAlumnoEN.Extension = p_extension;

        entregaAlumnoEN.Ruta = p_ruta;

        entregaAlumnoEN.Tam = p_tam;

        entregaAlumnoEN.Fecha_entrega = p_fecha_entrega;

        entregaAlumnoEN.Nota = p_nota;

        entregaAlumnoEN.Corregido = p_corregido;

        entregaAlumnoEN.Comentario_alumno = p_comentario_alumno;

        entregaAlumnoEN.Comentario_profesor = p_comentario_profesor;


        if (p_entrega != -1) {
                entregaAlumnoEN.Entrega = new DSSGenNHibernate.EN.Moodle.EntregaEN ();
                entregaAlumnoEN.Entrega.Id = p_entrega;
        }


        if (p_evaluacion_alumno != -1) {
                entregaAlumnoEN.Evaluacion_alumno = new DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN ();
                entregaAlumnoEN.Evaluacion_alumno.Id = p_evaluacion_alumno;
        }

        //Call to EntregaAlumnoCAD

        oid = _IEntregaAlumnoCAD.New_ (entregaAlumnoEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre_fichero, string p_extension, string p_ruta, float p_tam, Nullable<DateTime> p_fecha_entrega, float p_nota, bool p_corregido, string p_comentario_alumno, string p_comentario_profesor)
{
        EntregaAlumnoEN entregaAlumnoEN = null;

        //Initialized EntregaAlumnoEN
        entregaAlumnoEN = new EntregaAlumnoEN ();
        entregaAlumnoEN.Id = p_oid;
        entregaAlumnoEN.Nombre_fichero = p_nombre_fichero;
        entregaAlumnoEN.Extension = p_extension;
        entregaAlumnoEN.Ruta = p_ruta;
        entregaAlumnoEN.Tam = p_tam;
        entregaAlumnoEN.Fecha_entrega = p_fecha_entrega;
        entregaAlumnoEN.Nota = p_nota;
        entregaAlumnoEN.Corregido = p_corregido;
        entregaAlumnoEN.Comentario_alumno = p_comentario_alumno;
        entregaAlumnoEN.Comentario_profesor = p_comentario_profesor;
        //Call to EntregaAlumnoCAD

        _IEntregaAlumnoCAD.Modify (entregaAlumnoEN);
}

public void Destroy (int id)
{
        _IEntregaAlumnoCAD.Destroy (id);
}

public System.Collections.Generic.IList<EntregaAlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntregaAlumnoEN> list = null;

        list = _IEntregaAlumnoCAD.ReadAll (first, size);
        return list;
}
public EntregaAlumnoEN ReadOID (int id)
{
        EntregaAlumnoEN entregaAlumnoEN = null;

        entregaAlumnoEN = _IEntregaAlumnoCAD.ReadOID (id);
        return entregaAlumnoEN;
}

public long ReadCantidad ()
{
        return _IEntregaAlumnoCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.EntregaAlumnoEN ReadRelation (int p_evalalumno, int p_entrega)
{
        return _IEntregaAlumnoCAD.ReadRelation (p_evalalumno, p_entrega);
}
public void Relationer_evaluacion_alumno (int p_entregaalumno, int p_evaluacionalumno)
{
        //Call to EntregaAlumnoCAD

        _IEntregaAlumnoCAD.Relationer_evaluacion_alumno (p_entregaalumno, p_evaluacionalumno);
}
public void Relationer_entrega (int p_entregaalumno, int p_entrega)
{
        //Call to EntregaAlumnoCAD

        _IEntregaAlumnoCAD.Relationer_entrega (p_entregaalumno, p_entrega);
}
public void Unrelationer_evaluacion_alumno (int p_entregaalumno, int p_evaluacionalumno)
{
        //Call to EntregaAlumnoCAD

        _IEntregaAlumnoCAD.Unrelationer_evaluacion_alumno (p_entregaalumno, p_evaluacionalumno);
}
public void Unrelationer_entrega (int p_entregaalumno, int p_entrega)
{
        //Call to EntregaAlumnoCAD

        _IEntregaAlumnoCAD.Unrelationer_entrega (p_entregaalumno, p_entrega);
}
}
}
