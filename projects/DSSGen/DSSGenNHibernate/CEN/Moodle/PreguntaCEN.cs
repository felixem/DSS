

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
public partial class PreguntaCEN
{
private IPreguntaCAD _IPreguntaCAD;

public PreguntaCEN()
{
        this._IPreguntaCAD = new PreguntaCAD ();
}

public PreguntaCEN(IPreguntaCAD _IPreguntaCAD)
{
        this._IPreguntaCAD = _IPreguntaCAD;
}

public IPreguntaCAD get_IPreguntaCAD ()
{
        return this._IPreguntaCAD;
}

public int New_ (string p_contenido, string p_explicacion, int p_bolsa)
{
        PreguntaEN preguntaEN = null;
        int oid;

        //Initialized PreguntaEN
        preguntaEN = new PreguntaEN ();
        preguntaEN.Contenido = p_contenido;

        preguntaEN.Explicacion = p_explicacion;


        if (p_bolsa != -1) {
                preguntaEN.Bolsa = new DSSGenNHibernate.EN.Moodle.BolsaPreguntasEN ();
                preguntaEN.Bolsa.Id = p_bolsa;
        }

        //Call to PreguntaCAD

        oid = _IPreguntaCAD.New_ (preguntaEN);
        return oid;
}

public void Modify (int p_oid, string p_contenido, string p_explicacion)
{
        PreguntaEN preguntaEN = null;

        //Initialized PreguntaEN
        preguntaEN = new PreguntaEN ();
        preguntaEN.Id = p_oid;
        preguntaEN.Contenido = p_contenido;
        preguntaEN.Explicacion = p_explicacion;
        //Call to PreguntaCAD

        _IPreguntaCAD.Modify (preguntaEN);
}

public void Destroy (int id)
{
        _IPreguntaCAD.Destroy (id);
}

public System.Collections.Generic.IList<PreguntaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PreguntaEN> list = null;

        list = _IPreguntaCAD.ReadAll (first, size);
        return list;
}
public PreguntaEN ReadOID (int id)
{
        PreguntaEN preguntaEN = null;

        preguntaEN = _IPreguntaCAD.ReadOID (id);
        return preguntaEN;
}

public void Relationer_bolsa (int p_pregunta, int p_bolsapreguntas)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Relationer_bolsa (p_pregunta, p_bolsapreguntas);
}
public void Relationer_preguntas_control (int p_pregunta, System.Collections.Generic.IList<int> p_preguntacontrol)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Relationer_preguntas_control (p_pregunta, p_preguntacontrol);
}
public void Relationer_respuesta_correcta (int p_pregunta, int p_respuesta)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Relationer_respuesta_correcta (p_pregunta, p_respuesta);
}
public void Relationer_respuestas (int p_pregunta, System.Collections.Generic.IList<int> p_respuesta)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Relationer_respuestas (p_pregunta, p_respuesta);
}
public void Unrelationer_bolsa (int p_pregunta, int p_bolsapreguntas)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Unrelationer_bolsa (p_pregunta, p_bolsapreguntas);
}
public void Unrelationer_preguntas_control (int p_pregunta, System.Collections.Generic.IList<int> p_preguntacontrol)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Unrelationer_preguntas_control (p_pregunta, p_preguntacontrol);
}
public void Unrelationer_respuesta_correcta (int p_pregunta, int p_respuesta)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Unrelationer_respuesta_correcta (p_pregunta, p_respuesta);
}
public void Unrelationer_respuestas (int p_pregunta, System.Collections.Generic.IList<int> p_respuesta)
{
        //Call to PreguntaCAD

        _IPreguntaCAD.Unrelationer_respuestas (p_pregunta, p_respuesta);
}
}
}
