

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
public partial class ExpedienteAnyoCEN
{
private IExpedienteAnyoCAD _IExpedienteAnyoCAD;

public ExpedienteAnyoCEN()
{
        this._IExpedienteAnyoCAD = new ExpedienteAnyoCAD ();
}

public ExpedienteAnyoCEN(IExpedienteAnyoCAD _IExpedienteAnyoCAD)
{
        this._IExpedienteAnyoCAD = _IExpedienteAnyoCAD;
}

public IExpedienteAnyoCAD get_IExpedienteAnyoCAD ()
{
        return this._IExpedienteAnyoCAD;
}

public int New_ (float p_nota_media, bool p_abierto, int p_expediente, int p_anyo)
{
        ExpedienteAnyoEN expedienteAnyoEN = null;
        int oid;

        //Initialized ExpedienteAnyoEN
        expedienteAnyoEN = new ExpedienteAnyoEN ();
        expedienteAnyoEN.Nota_media = p_nota_media;

        expedienteAnyoEN.Abierto = p_abierto;


        if (p_expediente != -1) {
                expedienteAnyoEN.Expediente = new DSSGenNHibernate.EN.Moodle.ExpedienteEN ();
                expedienteAnyoEN.Expediente.Id = p_expediente;
        }


        if (p_anyo != -1) {
                expedienteAnyoEN.Anyo = new DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN ();
                expedienteAnyoEN.Anyo.Id = p_anyo;
        }

        //Call to ExpedienteAnyoCAD

        oid = _IExpedienteAnyoCAD.New_ (expedienteAnyoEN);
        return oid;
}

public void Modify (int p_oid, float p_nota_media, bool p_abierto)
{
        ExpedienteAnyoEN expedienteAnyoEN = null;

        //Initialized ExpedienteAnyoEN
        expedienteAnyoEN = new ExpedienteAnyoEN ();
        expedienteAnyoEN.Id = p_oid;
        expedienteAnyoEN.Nota_media = p_nota_media;
        expedienteAnyoEN.Abierto = p_abierto;
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Modify (expedienteAnyoEN);
}

public void Destroy (int id)
{
        _IExpedienteAnyoCAD.Destroy (id);
}

public System.Collections.Generic.IList<ExpedienteAnyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteAnyoEN> list = null;

        list = _IExpedienteAnyoCAD.ReadAll (first, size);
        return list;
}
public ExpedienteAnyoEN ReadOID (int id)
{
        ExpedienteAnyoEN expedienteAnyoEN = null;

        expedienteAnyoEN = _IExpedienteAnyoCAD.ReadOID (id);
        return expedienteAnyoEN;
}

public long ReadCantidad ()
{
        return _IExpedienteAnyoCAD.ReadCantidad ();
}
public void Relationer_anyo (int p_expedienteanyo, int p_anyoacademico)
{
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Relationer_anyo (p_expedienteanyo, p_anyoacademico);
}
public void Relationer_expediente (int p_expedienteanyo, int p_expediente)
{
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Relationer_expediente (p_expedienteanyo, p_expediente);
}
public void Relationer_expedientes_asignatura (int p_expedienteanyo, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Relationer_expedientes_asignatura (p_expedienteanyo, p_expedienteasignatura);
}
public void Unrelationer_anyo (int p_expedienteanyo, int p_anyoacademico)
{
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Unrelationer_anyo (p_expedienteanyo, p_anyoacademico);
}
public void Unrelationer_expediente (int p_expedienteanyo, int p_expediente)
{
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Unrelationer_expediente (p_expedienteanyo, p_expediente);
}
public void Unrelationer_expedientes_asignatura (int p_expedienteanyo, System.Collections.Generic.IList<int> p_expedienteasignatura)
{
        //Call to ExpedienteAnyoCAD

        _IExpedienteAnyoCAD.Unrelationer_expedientes_asignatura (p_expedienteanyo, p_expedienteasignatura);
}
}
}
