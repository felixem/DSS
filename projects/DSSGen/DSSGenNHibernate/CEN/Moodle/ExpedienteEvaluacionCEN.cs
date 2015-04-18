

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
public partial class ExpedienteEvaluacionCEN
{
private IExpedienteEvaluacionCAD _IExpedienteEvaluacionCAD;

public ExpedienteEvaluacionCEN()
{
        this._IExpedienteEvaluacionCAD = new ExpedienteEvaluacionCAD ();
}

public ExpedienteEvaluacionCEN(IExpedienteEvaluacionCAD _IExpedienteEvaluacionCAD)
{
        this._IExpedienteEvaluacionCAD = _IExpedienteEvaluacionCAD;
}

public IExpedienteEvaluacionCAD get_IExpedienteEvaluacionCAD ()
{
        return this._IExpedienteEvaluacionCAD;
}

public int New_ (float p_nota_media, bool p_abierto, int p_expediente_asignatura, int p_evaluacion)
{
        ExpedienteEvaluacionEN expedienteEvaluacionEN = null;
        int oid;

        //Initialized ExpedienteEvaluacionEN
        expedienteEvaluacionEN = new ExpedienteEvaluacionEN ();
        expedienteEvaluacionEN.Nota_media = p_nota_media;

        expedienteEvaluacionEN.Abierto = p_abierto;


        if (p_expediente_asignatura != -1) {
                expedienteEvaluacionEN.Expediente_asignatura = new DSSGenNHibernate.EN.Moodle.ExpedienteAsignaturaEN ();
                expedienteEvaluacionEN.Expediente_asignatura.Id = p_expediente_asignatura;
        }


        if (p_evaluacion != -1) {
                expedienteEvaluacionEN.Evaluacion = new DSSGenNHibernate.EN.Moodle.EvaluacionEN ();
                expedienteEvaluacionEN.Evaluacion.Id = p_evaluacion;
        }

        //Call to ExpedienteEvaluacionCAD

        oid = _IExpedienteEvaluacionCAD.New_ (expedienteEvaluacionEN);
        return oid;
}

public void Modify (int p_oid, float p_nota_media, bool p_abierto)
{
        ExpedienteEvaluacionEN expedienteEvaluacionEN = null;

        //Initialized ExpedienteEvaluacionEN
        expedienteEvaluacionEN = new ExpedienteEvaluacionEN ();
        expedienteEvaluacionEN.Id = p_oid;
        expedienteEvaluacionEN.Nota_media = p_nota_media;
        expedienteEvaluacionEN.Abierto = p_abierto;
        //Call to ExpedienteEvaluacionCAD

        _IExpedienteEvaluacionCAD.Modify (expedienteEvaluacionEN);
}

public void Destroy (int id)
{
        _IExpedienteEvaluacionCAD.Destroy (id);
}

public System.Collections.Generic.IList<ExpedienteEvaluacionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteEvaluacionEN> list = null;

        list = _IExpedienteEvaluacionCAD.ReadAll (first, size);
        return list;
}
public ExpedienteEvaluacionEN ReadOID (int id)
{
        ExpedienteEvaluacionEN expedienteEvaluacionEN = null;

        expedienteEvaluacionEN = _IExpedienteEvaluacionCAD.ReadOID (id);
        return expedienteEvaluacionEN;
}

public long ReadCantidad ()
{
        return _IExpedienteEvaluacionCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.ExpedienteEvaluacionEN ReadRelation (int p_exp_asig, int p_evaluacion)
{
        return _IExpedienteEvaluacionCAD.ReadRelation (p_exp_asig, p_evaluacion);
}
public void Relationer_evaluacion_alumno (int p_expedienteevaluacion, int p_evaluacionalumno)
{
        //Call to ExpedienteEvaluacionCAD

        _IExpedienteEvaluacionCAD.Relationer_evaluacion_alumno (p_expedienteevaluacion, p_evaluacionalumno);
}
public void Relationer_evaluacion (int p_expedienteevaluacion, int p_evaluacion)
{
        //Call to ExpedienteEvaluacionCAD

        _IExpedienteEvaluacionCAD.Relationer_evaluacion (p_expedienteevaluacion, p_evaluacion);
}
public void Relationer_expediente_asignatura (int p_expedienteevaluacion, int p_expedienteasignatura)
{
        //Call to ExpedienteEvaluacionCAD

        _IExpedienteEvaluacionCAD.Relationer_expediente_asignatura (p_expedienteevaluacion, p_expedienteasignatura);
}
public void Unrelationer_evaluacion (int p_expedienteevaluacion, int p_evaluacion)
{
        //Call to ExpedienteEvaluacionCAD

        _IExpedienteEvaluacionCAD.Unrelationer_evaluacion (p_expedienteevaluacion, p_evaluacion);
}
public void Unrelationer_expediente_asignatura (int p_expedienteevaluacion, int p_expedienteasignatura)
{
        //Call to ExpedienteEvaluacionCAD

        _IExpedienteEvaluacionCAD.Unrelationer_expediente_asignatura (p_expedienteevaluacion, p_expedienteasignatura);
}
}
}
