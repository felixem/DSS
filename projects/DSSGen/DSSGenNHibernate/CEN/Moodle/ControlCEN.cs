

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
public partial class ControlCEN
{
private IControlCAD _IControlCAD;

public ControlCEN()
{
        this._IControlCAD = new ControlCAD ();
}

public ControlCEN(IControlCAD _IControlCAD)
{
        this._IControlCAD = _IControlCAD;
}

public IControlCAD get_IControlCAD ()
{
        return this._IControlCAD;
}

public int New_ (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima, float p_penalizacion_fallo, int p_sistema_evaluacion)
{
        ControlEN controlEN = null;
        int oid;

        //Initialized ControlEN
        controlEN = new ControlEN ();
        controlEN.Nombre = p_nombre;

        controlEN.Descripcion = p_descripcion;

        controlEN.Fecha_apertura = p_fecha_apertura;

        controlEN.Fecha_cierre = p_fecha_cierre;

        controlEN.Duracion_minutos = p_duracion_minutos;

        controlEN.Puntuacion_maxima = p_puntuacion_maxima;

        controlEN.Penalizacion_fallo = p_penalizacion_fallo;


        if (p_sistema_evaluacion != -1) {
                controlEN.Sistema_evaluacion = new DSSGenNHibernate.EN.Moodle.SistemaEvaluacionEN ();
                controlEN.Sistema_evaluacion.Id = p_sistema_evaluacion;
        }

        //Call to ControlCAD

        oid = _IControlCAD.New_ (controlEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_apertura, Nullable<DateTime> p_fecha_cierre, int p_duracion_minutos, float p_puntuacion_maxima, float p_penalizacion_fallo)
{
        ControlEN controlEN = null;

        //Initialized ControlEN
        controlEN = new ControlEN ();
        controlEN.Id = p_oid;
        controlEN.Nombre = p_nombre;
        controlEN.Descripcion = p_descripcion;
        controlEN.Fecha_apertura = p_fecha_apertura;
        controlEN.Fecha_cierre = p_fecha_cierre;
        controlEN.Duracion_minutos = p_duracion_minutos;
        controlEN.Puntuacion_maxima = p_puntuacion_maxima;
        controlEN.Penalizacion_fallo = p_penalizacion_fallo;
        //Call to ControlCAD

        _IControlCAD.Modify (controlEN);
}

public void Destroy (int id)
{
        _IControlCAD.Destroy (id);
}

public System.Collections.Generic.IList<ControlEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ControlEN> list = null;

        list = _IControlCAD.ReadAll (first, size);
        return list;
}
public ControlEN ReadOID (int id)
{
        ControlEN controlEN = null;

        controlEN = _IControlCAD.ReadOID (id);
        return controlEN;
}

public long ReadCantidad ()
{
        return _IControlCAD.ReadCantidad ();
}
public void Relationer_bolsas_preguntas (int p_control, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        //Call to ControlCAD

        _IControlCAD.Relationer_bolsas_preguntas (p_control, p_bolsapreguntas);
}
public void Relationer_controles_alumno (int p_control, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to ControlCAD

        _IControlCAD.Relationer_controles_alumno (p_control, p_controlalumno);
}
public void Relationer_sistema_evaluacion (int p_control, int p_sistemaevaluacion)
{
        //Call to ControlCAD

        _IControlCAD.Relationer_sistema_evaluacion (p_control, p_sistemaevaluacion);
}
public void Unrelationer_bolsas_preguntas (int p_control, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        //Call to ControlCAD

        _IControlCAD.Unrelationer_bolsas_preguntas (p_control, p_bolsapreguntas);
}
public void Unrelationer_controles_alumno (int p_control, System.Collections.Generic.IList<int> p_controlalumno)
{
        //Call to ControlCAD

        _IControlCAD.Unrelationer_controles_alumno (p_control, p_controlalumno);
}
public void Unrelationer_sistema_evaluacion (int p_control, int p_sistemaevaluacion)
{
        //Call to ControlCAD

        _IControlCAD.Unrelationer_sistema_evaluacion (p_control, p_sistemaevaluacion);
}
}
}
