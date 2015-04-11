

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
public partial class ExpedienteAsignaturaCEN
{
private IExpedienteAsignaturaCAD _IExpedienteAsignaturaCAD;

public ExpedienteAsignaturaCEN()
{
        this._IExpedienteAsignaturaCAD = new ExpedienteAsignaturaCAD ();
}

public ExpedienteAsignaturaCEN(IExpedienteAsignaturaCAD _IExpedienteAsignaturaCAD)
{
        this._IExpedienteAsignaturaCAD = _IExpedienteAsignaturaCAD;
}

public IExpedienteAsignaturaCAD get_IExpedienteAsignaturaCAD ()
{
        return this._IExpedienteAsignaturaCAD;
}

public int New_ (float p_nota_media, bool p_abierto, int p_expediente_anyo, int p_asignatura)
{
        ExpedienteAsignaturaEN expedienteAsignaturaEN = null;
        int oid;

        //Initialized ExpedienteAsignaturaEN
        expedienteAsignaturaEN = new ExpedienteAsignaturaEN ();
        expedienteAsignaturaEN.Nota_media = p_nota_media;

        expedienteAsignaturaEN.Abierto = p_abierto;


        if (p_expediente_anyo != -1) {
                expedienteAsignaturaEN.Expediente_anyo = new DSSGenNHibernate.EN.Moodle.ExpedienteAnyoEN ();
                expedienteAsignaturaEN.Expediente_anyo.Id = p_expediente_anyo;
        }


        if (p_asignatura != -1) {
                expedienteAsignaturaEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaEN ();
                expedienteAsignaturaEN.Asignatura.Id = p_asignatura;
        }

        //Call to ExpedienteAsignaturaCAD

        oid = _IExpedienteAsignaturaCAD.New_ (expedienteAsignaturaEN);
        return oid;
}

public void Modify (int p_oid, float p_nota_media, bool p_abierto)
{
        ExpedienteAsignaturaEN expedienteAsignaturaEN = null;

        //Initialized ExpedienteAsignaturaEN
        expedienteAsignaturaEN = new ExpedienteAsignaturaEN ();
        expedienteAsignaturaEN.Id = p_oid;
        expedienteAsignaturaEN.Nota_media = p_nota_media;
        expedienteAsignaturaEN.Abierto = p_abierto;
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Modify (expedienteAsignaturaEN);
}

public void Destroy (int id)
{
        _IExpedienteAsignaturaCAD.Destroy (id);
}

public System.Collections.Generic.IList<ExpedienteAsignaturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteAsignaturaEN> list = null;

        list = _IExpedienteAsignaturaCAD.ReadAll (first, size);
        return list;
}
public ExpedienteAsignaturaEN ReadOID (int id)
{
        ExpedienteAsignaturaEN expedienteAsignaturaEN = null;

        expedienteAsignaturaEN = _IExpedienteAsignaturaCAD.ReadOID (id);
        return expedienteAsignaturaEN;
}

public long ReadCantidad ()
{
        return _IExpedienteAsignaturaCAD.ReadCantidad ();
}
public void Relationer_asignatura (int p_expedienteasignatura, int p_asignatura)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Relationer_asignatura (p_expedienteasignatura, p_asignatura);
}
public void Relationer_expediente_anyo (int p_expedienteasignatura, int p_expedienteanyo)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Relationer_expediente_anyo (p_expedienteasignatura, p_expedienteanyo);
}
public void Relationer_expedientes_evaluacion (int p_expedienteasignatura, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Relationer_expedientes_evaluacion (p_expedienteasignatura, p_expedienteevaluacion);
}
public void Relationer_nota (int p_expedienteasignatura, int p_nota)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Relationer_nota (p_expedienteasignatura, p_nota);
}
public void Unrelationer_asignatura (int p_expedienteasignatura, int p_asignatura)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Unrelationer_asignatura (p_expedienteasignatura, p_asignatura);
}
public void Unrelationer_expediente_anyo (int p_expedienteasignatura, int p_expedienteanyo)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Unrelationer_expediente_anyo (p_expedienteasignatura, p_expedienteanyo);
}
public void Unrelationer_expedientes_evaluacion (int p_expedienteasignatura, System.Collections.Generic.IList<int> p_expedienteevaluacion)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Unrelationer_expedientes_evaluacion (p_expedienteasignatura, p_expedienteevaluacion);
}
public void Unrelationer_nota (int p_expedienteasignatura, int p_nota)
{
        //Call to ExpedienteAsignaturaCAD

        _IExpedienteAsignaturaCAD.Unrelationer_nota (p_expedienteasignatura, p_nota);
}
}
}
