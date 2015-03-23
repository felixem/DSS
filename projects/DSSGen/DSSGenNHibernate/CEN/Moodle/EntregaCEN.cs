

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
public partial class EntregaCEN
{
private IEntregaCAD _IEntregaCAD;

public EntregaCEN()
{
        this._IEntregaCAD = new EntregaCAD ();
}

public EntregaCEN(IEntregaCAD _IEntregaCAD)
{
        this._IEntregaCAD = _IEntregaCAD;
}

public IEntregaCAD get_IEntregaCAD ()
{
        return this._IEntregaCAD;
}

public int New_ (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, float p_puntuacion_maxima, int p_profesor, int p_evaluacion)
{
        EntregaEN entregaEN = null;
        int oid;

        //Initialized EntregaEN
        entregaEN = new EntregaEN ();
        entregaEN.Nombre = p_nombre;

        entregaEN.Descripcion = p_descripcion;

        entregaEN.Fecha_apertura = p_fecha_apertura;

        entregaEN.Fecha_cierre = p_fecha_cierre;

        entregaEN.Puntuacion_maxima = p_puntuacion_maxima;


        if (p_profesor != -1) {
                entregaEN.Profesor = new DSSGenNHibernate.EN.Moodle.ProfesorEN ();
                entregaEN.Profesor.Id = p_profesor;
        }


        if (p_evaluacion != -1) {
                entregaEN.Evaluacion = new DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ();
                entregaEN.Evaluacion.Id = p_evaluacion;
        }

        //Call to EntregaCAD

        oid = _IEntregaCAD.New_ (entregaEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, float p_puntuacion_maxima)
{
        EntregaEN entregaEN = null;

        //Initialized EntregaEN
        entregaEN = new EntregaEN ();
        entregaEN.Id = p_oid;
        entregaEN.Nombre = p_nombre;
        entregaEN.Descripcion = p_descripcion;
        entregaEN.Fecha_apertura = p_fecha_apertura;
        entregaEN.Fecha_cierre = p_fecha_cierre;
        entregaEN.Puntuacion_maxima = p_puntuacion_maxima;
        //Call to EntregaCAD

        _IEntregaCAD.Modify (entregaEN);
}

public void Destroy (int id)
{
        _IEntregaCAD.Destroy (id);
}

public System.Collections.Generic.IList<EntregaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EntregaEN> list = null;

        list = _IEntregaCAD.ReadAll (first, size);
        return list;
}
public EntregaEN ReadOID (int id)
{
        EntregaEN entregaEN = null;

        entregaEN = _IEntregaCAD.ReadOID (id);
        return entregaEN;
}

public void Relationer_entregas_alumno (int p_entrega, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to EntregaCAD

        _IEntregaCAD.Relationer_entregas_alumno (p_entrega, p_entregaalumno);
}
public void Relationer_evaluacion (int p_entrega, int p_sistemaevaluacion)
{
        //Call to EntregaCAD

        _IEntregaCAD.Relationer_evaluacion (p_entrega, p_sistemaevaluacion);
}
public void Relationer_profesor (int p_entrega, int p_profesor)
{
        //Call to EntregaCAD

        _IEntregaCAD.Relationer_profesor (p_entrega, p_profesor);
}
public void Unrelationer_entregas_alumno (int p_entrega, System.Collections.Generic.IList<int> p_entregaalumno)
{
        //Call to EntregaCAD

        _IEntregaCAD.Unrelationer_entregas_alumno (p_entrega, p_entregaalumno);
}
public void Unrelationer_evaluacion (int p_entrega, int p_sistemaevaluacion)
{
        //Call to EntregaCAD

        _IEntregaCAD.Unrelationer_evaluacion (p_entrega, p_sistemaevaluacion);
}
public void Unrelationer_profesor (int p_entrega, int p_profesor)
{
        //Call to EntregaCAD

        _IEntregaCAD.Unrelationer_profesor (p_entrega, p_profesor);
}
}
}
