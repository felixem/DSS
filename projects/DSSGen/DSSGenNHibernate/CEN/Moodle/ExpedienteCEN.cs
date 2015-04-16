

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
public partial class ExpedienteCEN
{
private IExpedienteCAD _IExpedienteCAD;

public ExpedienteCEN()
{
        this._IExpedienteCAD = new ExpedienteCAD ();
}

public ExpedienteCEN(IExpedienteCAD _IExpedienteCAD)
{
        this._IExpedienteCAD = _IExpedienteCAD;
}

public IExpedienteCAD get_IExpedienteCAD ()
{
        return this._IExpedienteCAD;
}

public int New_ (string p_cod_expediente, float p_nota_media, bool p_abierto, string p_alumno)
{
        ExpedienteEN expedienteEN = null;
        int oid;

        //Initialized ExpedienteEN
        expedienteEN = new ExpedienteEN ();
        expedienteEN.Cod_expediente = p_cod_expediente;

        expedienteEN.Nota_media = p_nota_media;

        expedienteEN.Abierto = p_abierto;


        if (p_alumno != null) {
                expedienteEN.Alumno = new DSSGenNHibernate.EN.Moodle.AlumnoEN ();
                expedienteEN.Alumno.Email = p_alumno;
        }

        //Call to ExpedienteCAD

        oid = _IExpedienteCAD.New_ (expedienteEN);
        return oid;
}

public void Modify (int p_oid, string p_cod_expediente, float p_nota_media, bool p_abierto)
{
        ExpedienteEN expedienteEN = null;

        //Initialized ExpedienteEN
        expedienteEN = new ExpedienteEN ();
        expedienteEN.Id = p_oid;
        expedienteEN.Cod_expediente = p_cod_expediente;
        expedienteEN.Nota_media = p_nota_media;
        expedienteEN.Abierto = p_abierto;
        //Call to ExpedienteCAD

        _IExpedienteCAD.Modify (expedienteEN);
}

public void Destroy (int id)
{
        _IExpedienteCAD.Destroy (id);
}

public System.Collections.Generic.IList<ExpedienteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ExpedienteEN> list = null;

        list = _IExpedienteCAD.ReadAll (first, size);
        return list;
}
public ExpedienteEN ReadOID (int id)
{
        ExpedienteEN expedienteEN = null;

        expedienteEN = _IExpedienteCAD.ReadOID (id);
        return expedienteEN;
}

public long ReadCantidad ()
{
        return _IExpedienteCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.ExpedienteEN ReadRelation (string p_alu)
{
        return _IExpedienteCAD.ReadRelation (p_alu);
}
public void Relationer_alumno (int p_expediente, string p_alumno)
{
        //Call to ExpedienteCAD

        _IExpedienteCAD.Relationer_alumno (p_expediente, p_alumno);
}
public void Relationer_expedientes_anyo (int p_expediente, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        //Call to ExpedienteCAD

        _IExpedienteCAD.Relationer_expedientes_anyo (p_expediente, p_expedienteanyo);
}
public void Unrelationer_alumno (int p_expediente, string p_alumno)
{
        //Call to ExpedienteCAD

        _IExpedienteCAD.Unrelationer_alumno (p_expediente, p_alumno);
}
public void Unrelationer_expedientes_anyo (int p_expediente, System.Collections.Generic.IList<int> p_expedienteanyo)
{
        //Call to ExpedienteCAD

        _IExpedienteCAD.Unrelationer_expedientes_anyo (p_expediente, p_expedienteanyo);
}
}
}
