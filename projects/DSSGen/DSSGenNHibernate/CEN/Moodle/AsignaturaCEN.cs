

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
public partial class AsignaturaCEN
{
private IAsignaturaCAD _IAsignaturaCAD;

public AsignaturaCEN()
{
        this._IAsignaturaCAD = new AsignaturaCAD ();
}

public AsignaturaCEN(IAsignaturaCAD _IAsignaturaCAD)
{
        this._IAsignaturaCAD = _IAsignaturaCAD;
}

public IAsignaturaCAD get_IAsignaturaCAD ()
{
        return this._IAsignaturaCAD;
}

public int New_ (string p_cod_asignatura, string p_nombre, string p_descripcion, bool p_optativa, bool p_vigente, int p_curso)
{
        AsignaturaEN asignaturaEN = null;
        int oid;

        //Initialized AsignaturaEN
        asignaturaEN = new AsignaturaEN ();
        asignaturaEN.Cod_asignatura = p_cod_asignatura;

        asignaturaEN.Nombre = p_nombre;

        asignaturaEN.Descripcion = p_descripcion;

        asignaturaEN.Optativa = p_optativa;

        asignaturaEN.Vigente = p_vigente;


        if (p_curso != -1) {
                asignaturaEN.Curso = new DSSGenNHibernate.EN.Moodle.CursoEN ();
                asignaturaEN.Curso.Id = p_curso;
        }

        //Call to AsignaturaCAD

        oid = _IAsignaturaCAD.New_ (asignaturaEN);
        return oid;
}

public void Modify (int p_oid, string p_cod_asignatura, string p_nombre, string p_descripcion, bool p_optativa, bool p_vigente)
{
        AsignaturaEN asignaturaEN = null;

        //Initialized AsignaturaEN
        asignaturaEN = new AsignaturaEN ();
        asignaturaEN.Id = p_oid;
        asignaturaEN.Cod_asignatura = p_cod_asignatura;
        asignaturaEN.Nombre = p_nombre;
        asignaturaEN.Descripcion = p_descripcion;
        asignaturaEN.Optativa = p_optativa;
        asignaturaEN.Vigente = p_vigente;
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Modify (asignaturaEN);
}

public void Destroy (int id)
{
        _IAsignaturaCAD.Destroy (id);
}

public System.Collections.Generic.IList<AsignaturaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AsignaturaEN> list = null;

        list = _IAsignaturaCAD.ReadAll (first, size);
        return list;
}
public AsignaturaEN ReadOID (int id)
{
        AsignaturaEN asignaturaEN = null;

        asignaturaEN = _IAsignaturaCAD.ReadOID (id);
        return asignaturaEN;
}

public long ReadCantidad ()
{
        return _IAsignaturaCAD.ReadCantidad ();
}
public DSSGenNHibernate.EN.Moodle.AsignaturaEN ReadCod (string cod)
{
        return _IAsignaturaCAD.ReadCod (cod);
}
public long ReadCantidadVinculablesAAnyo (int id)
{
        return _IAsignaturaCAD.ReadCantidadVinculablesAAnyo (id);
}
public void Relationer_asignaturas_anyo (int p_asignatura, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Relationer_asignaturas_anyo (p_asignatura, p_asignaturaanyo);
}
public void Relationer_bolsas_preguntas (int p_asignatura, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Relationer_bolsas_preguntas (p_asignatura, p_bolsapreguntas);
}
public void Relationer_curso (int p_asignatura, int p_curso)
{
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Relationer_curso (p_asignatura, p_curso);
}
public void Unrelationer_asignaturas_anyo (int p_asignatura, System.Collections.Generic.IList<int> p_asignaturaanyo)
{
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Unrelationer_asignaturas_anyo (p_asignatura, p_asignaturaanyo);
}
public void Unrelationer_bolsas_preguntas (int p_asignatura, System.Collections.Generic.IList<int> p_bolsapreguntas)
{
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Unrelationer_bolsas_preguntas (p_asignatura, p_bolsapreguntas);
}
public void Unrelationer_curso (int p_asignatura, int p_curso)
{
        //Call to AsignaturaCAD

        _IAsignaturaCAD.Unrelationer_curso (p_asignatura, p_curso);
}
}
}
