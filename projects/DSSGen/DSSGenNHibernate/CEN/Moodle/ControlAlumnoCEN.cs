

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
public partial class ControlAlumnoCEN
{
private IControlAlumnoCAD _IControlAlumnoCAD;

public ControlAlumnoCEN()
{
        this._IControlAlumnoCAD = new ControlAlumnoCAD ();
}

public ControlAlumnoCEN(IControlAlumnoCAD _IControlAlumnoCAD)
{
        this._IControlAlumnoCAD = _IControlAlumnoCAD;
}

public IControlAlumnoCAD get_IControlAlumnoCAD ()
{
        return this._IControlAlumnoCAD;
}

public int New_ (float p_nota, bool p_terminado, bool p_corregido, int p_evaluacion_alumno, int p_control)
{
        ControlAlumnoEN controlAlumnoEN = null;
        int oid;

        //Initialized ControlAlumnoEN
        controlAlumnoEN = new ControlAlumnoEN ();
        controlAlumnoEN.Nota = p_nota;

        controlAlumnoEN.Terminado = p_terminado;

        controlAlumnoEN.Corregido = p_corregido;


        if (p_evaluacion_alumno != -1) {
                controlAlumnoEN.Evaluacion_alumno = new DSSGenNHibernate.EN.Moodle.EvaluacionAlumnoEN ();
                controlAlumnoEN.Evaluacion_alumno.Id = p_evaluacion_alumno;
        }


        if (p_control != -1) {
                controlAlumnoEN.Control = new DSSGenNHibernate.EN.Moodle.ControlEN ();
                controlAlumnoEN.Control.Id = p_control;
        }

        //Call to ControlAlumnoCAD

        oid = _IControlAlumnoCAD.New_ (controlAlumnoEN);
        return oid;
}

public void Modify (int p_oid, float p_nota, bool p_terminado, bool p_corregido)
{
        ControlAlumnoEN controlAlumnoEN = null;

        //Initialized ControlAlumnoEN
        controlAlumnoEN = new ControlAlumnoEN ();
        controlAlumnoEN.Id = p_oid;
        controlAlumnoEN.Nota = p_nota;
        controlAlumnoEN.Terminado = p_terminado;
        controlAlumnoEN.Corregido = p_corregido;
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Modify (controlAlumnoEN);
}

public void Destroy (int id)
{
        _IControlAlumnoCAD.Destroy (id);
}

public System.Collections.Generic.IList<ControlAlumnoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ControlAlumnoEN> list = null;

        list = _IControlAlumnoCAD.ReadAll (first, size);
        return list;
}
public ControlAlumnoEN ReadOID (int id)
{
        ControlAlumnoEN controlAlumnoEN = null;

        controlAlumnoEN = _IControlAlumnoCAD.ReadOID (id);
        return controlAlumnoEN;
}

public long ReadCantidad ()
{
        return _IControlAlumnoCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.ControlAlumnoEN ReadRelation (int p_evalalumno, int p_control)
{
        return _IControlAlumnoCAD.ReadRelation (p_evalalumno, p_control);
}
public void Relationer_evaluacion_alumno (int p_controlalumno, int p_evaluacionalumno)
{
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Relationer_evaluacion_alumno (p_controlalumno, p_evaluacionalumno);
}
public void Relationer_control (int p_controlalumno, int p_control)
{
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Relationer_control (p_controlalumno, p_control);
}
public void Relationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol)
{
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Relationer_preguntas (p_controlalumno, p_preguntacontrol);
}
public void Unrelationer_evaluacion_alumno (int p_controlalumno, int p_evaluacionalumno)
{
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Unrelationer_evaluacion_alumno (p_controlalumno, p_evaluacionalumno);
}
public void Unrelationer_control (int p_controlalumno, int p_control)
{
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Unrelationer_control (p_controlalumno, p_control);
}
public void Unrelationer_preguntas (int p_controlalumno, System.Collections.Generic.IList<int> p_preguntacontrol)
{
        //Call to ControlAlumnoCAD

        _IControlAlumnoCAD.Unrelationer_preguntas (p_controlalumno, p_preguntacontrol);
}
}
}
