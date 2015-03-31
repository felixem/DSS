

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
public partial class BolsaPreguntasCEN
{
private IBolsaPreguntasCAD _IBolsaPreguntasCAD;

public BolsaPreguntasCEN()
{
        this._IBolsaPreguntasCAD = new BolsaPreguntasCAD ();
}

public BolsaPreguntasCEN(IBolsaPreguntasCAD _IBolsaPreguntasCAD)
{
        this._IBolsaPreguntasCAD = _IBolsaPreguntasCAD;
}

public IBolsaPreguntasCAD get_IBolsaPreguntasCAD ()
{
        return this._IBolsaPreguntasCAD;
}

public int New_ (string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_creacion, Nullable<DateTime> p_fecha_modificacion, int p_asignatura)
{
        BolsaPreguntasEN bolsaPreguntasEN = null;
        int oid;

        //Initialized BolsaPreguntasEN
        bolsaPreguntasEN = new BolsaPreguntasEN ();
        bolsaPreguntasEN.Nombre = p_nombre;

        bolsaPreguntasEN.Descripcion = p_descripcion;

        bolsaPreguntasEN.Fecha_creacion = p_fecha_creacion;

        bolsaPreguntasEN.Fecha_modificacion = p_fecha_modificacion;


        if (p_asignatura != -1) {
                bolsaPreguntasEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaEN ();
                bolsaPreguntasEN.Asignatura.Id = p_asignatura;
        }

        //Call to BolsaPreguntasCAD

        oid = _IBolsaPreguntasCAD.New_ (bolsaPreguntasEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre, string p_descripcion, Nullable<DateTime> p_fecha_creacion, Nullable<DateTime> p_fecha_modificacion)
{
        BolsaPreguntasEN bolsaPreguntasEN = null;

        //Initialized BolsaPreguntasEN
        bolsaPreguntasEN = new BolsaPreguntasEN ();
        bolsaPreguntasEN.Id = p_oid;
        bolsaPreguntasEN.Nombre = p_nombre;
        bolsaPreguntasEN.Descripcion = p_descripcion;
        bolsaPreguntasEN.Fecha_creacion = p_fecha_creacion;
        bolsaPreguntasEN.Fecha_modificacion = p_fecha_modificacion;
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Modify (bolsaPreguntasEN);
}

public void Destroy (int id)
{
        _IBolsaPreguntasCAD.Destroy (id);
}

public System.Collections.Generic.IList<BolsaPreguntasEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BolsaPreguntasEN> list = null;

        list = _IBolsaPreguntasCAD.ReadAll (first, size);
        return list;
}
public BolsaPreguntasEN ReadOID (int id)
{
        BolsaPreguntasEN bolsaPreguntasEN = null;

        bolsaPreguntasEN = _IBolsaPreguntasCAD.ReadOID (id);
        return bolsaPreguntasEN;
}

public long ReadCantidad ()
{
        return _IBolsaPreguntasCAD.ReadCantidad ();
}
public void Relationer_asignatura (int p_bolsapreguntas, int p_asignatura)
{
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Relationer_asignatura (p_bolsapreguntas, p_asignatura);
}
public void Relationer_controles (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_control)
{
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Relationer_controles (p_bolsapreguntas, p_control);
}
public void Relationer_preguntas (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_pregunta)
{
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Relationer_preguntas (p_bolsapreguntas, p_pregunta);
}
public void Unrelationer_asignatura (int p_bolsapreguntas, int p_asignatura)
{
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Unrelationer_asignatura (p_bolsapreguntas, p_asignatura);
}
public void Unrelationer_controles (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_control)
{
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Unrelationer_controles (p_bolsapreguntas, p_control);
}
public void Unrelationer_preguntas (int p_bolsapreguntas, System.Collections.Generic.IList<int> p_pregunta)
{
        //Call to BolsaPreguntasCAD

        _IBolsaPreguntasCAD.Unrelationer_preguntas (p_bolsapreguntas, p_pregunta);
}
}
}
