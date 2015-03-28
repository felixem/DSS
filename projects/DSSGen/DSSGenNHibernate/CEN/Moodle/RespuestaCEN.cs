

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
public partial class RespuestaCEN
{
private IRespuestaCAD _IRespuestaCAD;

public RespuestaCEN()
{
        this._IRespuestaCAD = new RespuestaCAD ();
}

public RespuestaCEN(IRespuestaCAD _IRespuestaCAD)
{
        this._IRespuestaCAD = _IRespuestaCAD;
}

public IRespuestaCAD get_IRespuestaCAD ()
{
        return this._IRespuestaCAD;
}

public int New_ (string p_contenido, int p_pregunta)
{
        RespuestaEN respuestaEN = null;
        int oid;

        //Initialized RespuestaEN
        respuestaEN = new RespuestaEN ();
        respuestaEN.Contenido = p_contenido;


        if (p_pregunta != -1) {
                respuestaEN.Pregunta = new DSSGenNHibernate.EN.Moodle.PreguntaEN ();
                respuestaEN.Pregunta.Id = p_pregunta;
        }

        //Call to RespuestaCAD

        oid = _IRespuestaCAD.New_ (respuestaEN);
        return oid;
}

public void Modify (int p_oid, string p_contenido)
{
        RespuestaEN respuestaEN = null;

        //Initialized RespuestaEN
        respuestaEN = new RespuestaEN ();
        respuestaEN.Id = p_oid;
        respuestaEN.Contenido = p_contenido;
        //Call to RespuestaCAD

        _IRespuestaCAD.Modify (respuestaEN);
}

public void Destroy (int id)
{
        _IRespuestaCAD.Destroy (id);
}

public System.Collections.Generic.IList<RespuestaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RespuestaEN> list = null;

        list = _IRespuestaCAD.ReadAll (first, size);
        return list;
}
public RespuestaEN ReadOID (int id)
{
        RespuestaEN respuestaEN = null;

        respuestaEN = _IRespuestaCAD.ReadOID (id);
        return respuestaEN;
}

public void Relationer_pregunta (int p_respuesta, int p_pregunta)
{
        //Call to RespuestaCAD

        _IRespuestaCAD.Relationer_pregunta (p_respuesta, p_pregunta);
}
public void Unrelationer_pregunta (int p_respuesta, int p_pregunta)
{
        //Call to RespuestaCAD

        _IRespuestaCAD.Unrelationer_pregunta (p_respuesta, p_pregunta);
}
}
}
