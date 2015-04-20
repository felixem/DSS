

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
public partial class PreguntaControlCEN
{
private IPreguntaControlCAD _IPreguntaControlCAD;

public PreguntaControlCEN()
{
        this._IPreguntaControlCAD = new PreguntaControlCAD ();
}

public PreguntaControlCEN(IPreguntaControlCAD _IPreguntaControlCAD)
{
        this._IPreguntaControlCAD = _IPreguntaControlCAD;
}

public IPreguntaControlCAD get_IPreguntaControlCAD ()
{
        return this._IPreguntaControlCAD;
}

public int New_ (int p_control, int p_pregunta)
{
        PreguntaControlEN preguntaControlEN = null;
        int oid;

        //Initialized PreguntaControlEN
        preguntaControlEN = new PreguntaControlEN ();

        if (p_control != -1) {
                preguntaControlEN.Control = new DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ();
                preguntaControlEN.Control.Id = p_control;
        }


        if (p_pregunta != -1) {
                preguntaControlEN.Pregunta = new DSSGenNHibernate.EN.Moodle.PreguntaEN ();
                preguntaControlEN.Pregunta.Id = p_pregunta;
        }

        //Call to PreguntaControlCAD

        oid = _IPreguntaControlCAD.New_ (preguntaControlEN);
        return oid;
}

public void Modify (int p_oid)
{
        PreguntaControlEN preguntaControlEN = null;

        //Initialized PreguntaControlEN
        preguntaControlEN = new PreguntaControlEN ();
        preguntaControlEN.Id = p_oid;
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Modify (preguntaControlEN);
}

public void Destroy (int id)
{
        _IPreguntaControlCAD.Destroy (id);
}

public System.Collections.Generic.IList<PreguntaControlEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PreguntaControlEN> list = null;

        list = _IPreguntaControlCAD.ReadAll (first, size);
        return list;
}
public PreguntaControlEN ReadOID (int id)
{
        PreguntaControlEN preguntaControlEN = null;

        preguntaControlEN = _IPreguntaControlCAD.ReadOID (id);
        return preguntaControlEN;
}

public long ReadCantidad ()
{
        return _IPreguntaControlCAD.ReadCantidad ();
}
public void Relationer_control (int p_preguntacontrol, int p_controlalumno)
{
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Relationer_control (p_preguntacontrol, p_controlalumno);
}
public void Relationer_pregunta (int p_preguntacontrol, int p_pregunta)
{
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Relationer_pregunta (p_preguntacontrol, p_pregunta);
}
public void Relationer_respuesta_elegida (int p_preguntacontrol, int p_respuesta)
{
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Relationer_respuesta_elegida (p_preguntacontrol, p_respuesta);
}
public void Unrelationer_control (int p_preguntacontrol, int p_controlalumno)
{
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Unrelationer_control (p_preguntacontrol, p_controlalumno);
}
public void Unrelationer_pregunta (int p_preguntacontrol, int p_pregunta)
{
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Unrelationer_pregunta (p_preguntacontrol, p_pregunta);
}
public void Unrelationer_respuesta_elegida (int p_preguntacontrol, int p_respuesta)
{
        //Call to PreguntaControlCAD

        _IPreguntaControlCAD.Unrelationer_respuesta_elegida (p_preguntacontrol, p_respuesta);
}
}
}
