

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
public partial class AsignaturaAnyoCEN
{
private IAsignaturaAnyoCAD _IAsignaturaAnyoCAD;

public AsignaturaAnyoCEN()
{
        this._IAsignaturaAnyoCAD = new AsignaturaAnyoCAD ();
}

public AsignaturaAnyoCEN(IAsignaturaAnyoCAD _IAsignaturaAnyoCAD)
{
        this._IAsignaturaAnyoCAD = _IAsignaturaAnyoCAD;
}

public IAsignaturaAnyoCAD get_IAsignaturaAnyoCAD ()
{
        return this._IAsignaturaAnyoCAD;
}

public int New_ (int p_anyo, int p_asignatura)
{
        AsignaturaAnyoEN asignaturaAnyoEN = null;
        int oid;

        //Initialized AsignaturaAnyoEN
        asignaturaAnyoEN = new AsignaturaAnyoEN ();

        if (p_anyo != -1) {
                asignaturaAnyoEN.Anyo = new DSSGenNHibernate.EN.Moodle.AnyoAcademicoEN ();
                asignaturaAnyoEN.Anyo.Id = p_anyo;
        }


        if (p_asignatura != -1) {
                asignaturaAnyoEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaEN ();
                asignaturaAnyoEN.Asignatura.Id = p_asignatura;
        }

        //Call to AsignaturaAnyoCAD

        oid = _IAsignaturaAnyoCAD.New_ (asignaturaAnyoEN);
        return oid;
}

public void Modify (int p_oid)
{
        AsignaturaAnyoEN asignaturaAnyoEN = null;

        //Initialized AsignaturaAnyoEN
        asignaturaAnyoEN = new AsignaturaAnyoEN ();
        asignaturaAnyoEN.Id = p_oid;
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Modify (asignaturaAnyoEN);
}

public void Destroy (int id)
{
        _IAsignaturaAnyoCAD.Destroy (id);
}

public System.Collections.Generic.IList<AsignaturaAnyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AsignaturaAnyoEN> list = null;

        list = _IAsignaturaAnyoCAD.ReadAll (first, size);
        return list;
}
public AsignaturaAnyoEN ReadOID (int id)
{
        AsignaturaAnyoEN asignaturaAnyoEN = null;

        asignaturaAnyoEN = _IAsignaturaAnyoCAD.ReadOID (id);
        return asignaturaAnyoEN;
}

public void Relationer_anyo (int p_asignaturaanyo, int p_anyoacademico)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Relationer_anyo (p_asignaturaanyo, p_anyoacademico);
}
public void Relationer_asignatura (int p_asignaturaanyo, int p_asignatura)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Relationer_asignatura (p_asignaturaanyo, p_asignatura);
}
public void Relationer_grupos_trabajo (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Relationer_grupos_trabajo (p_asignaturaanyo, p_grupotrabajo);
}
public void Relationer_materiales (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_material)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Relationer_materiales (p_asignaturaanyo, p_material);
}
public void Relationer_sistemas_evaluacion (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Relationer_sistemas_evaluacion (p_asignaturaanyo, p_sistemaevaluacion);
}
public void Relationer_tutorias (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Relationer_tutorias (p_asignaturaanyo, p_tutoria);
}
public void Unrelationer_anyo (int p_asignaturaanyo, int p_anyoacademico)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Unrelationer_anyo (p_asignaturaanyo, p_anyoacademico);
}
public void Unrelationer_asignatura (int p_asignaturaanyo, int p_asignatura)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Unrelationer_asignatura (p_asignaturaanyo, p_asignatura);
}
public void Unrelationer_grupos_trabajo (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_grupotrabajo)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Unrelationer_grupos_trabajo (p_asignaturaanyo, p_grupotrabajo);
}
public void Unrelationer_materiales (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_material)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Unrelationer_materiales (p_asignaturaanyo, p_material);
}
public void Unrelationer_sistemas_evaluacion (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_sistemaevaluacion)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Unrelationer_sistemas_evaluacion (p_asignaturaanyo, p_sistemaevaluacion);
}
public void Unrelationer_tutorias (int p_asignaturaanyo, System.Collections.Generic.IList<int> p_tutoria)
{
        //Call to AsignaturaAnyoCAD

        _IAsignaturaAnyoCAD.Unrelationer_tutorias (p_asignaturaanyo, p_tutoria);
}
}
}