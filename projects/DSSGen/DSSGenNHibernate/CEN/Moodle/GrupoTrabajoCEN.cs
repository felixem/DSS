

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
public partial class GrupoTrabajoCEN
{
private IGrupoTrabajoCAD _IGrupoTrabajoCAD;

public GrupoTrabajoCEN()
{
        this._IGrupoTrabajoCAD = new GrupoTrabajoCAD ();
}

public GrupoTrabajoCEN(IGrupoTrabajoCAD _IGrupoTrabajoCAD)
{
        this._IGrupoTrabajoCAD = _IGrupoTrabajoCAD;
}

public IGrupoTrabajoCAD get_IGrupoTrabajoCAD ()
{
        return this._IGrupoTrabajoCAD;
}

public int New_ (int p_cod_grupo, string p_nombre, string p_descripcion, String p_password, int p_capacidad, int p_asignatura)
{
        GrupoTrabajoEN grupoTrabajoEN = null;
        int oid;

        //Initialized GrupoTrabajoEN
        grupoTrabajoEN = new GrupoTrabajoEN ();
        grupoTrabajoEN.Cod_grupo = p_cod_grupo;

        grupoTrabajoEN.Nombre = p_nombre;

        grupoTrabajoEN.Descripcion = p_descripcion;

        grupoTrabajoEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        grupoTrabajoEN.Capacidad = p_capacidad;


        if (p_asignatura != -1) {
                grupoTrabajoEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ();
                grupoTrabajoEN.Asignatura.Id = p_asignatura;
        }

        //Call to GrupoTrabajoCAD

        oid = _IGrupoTrabajoCAD.New_ (grupoTrabajoEN);
        return oid;
}

public void Modify (int p_oid, int p_cod_grupo, string p_nombre, string p_descripcion, String p_password, int p_capacidad)
{
        GrupoTrabajoEN grupoTrabajoEN = null;

        //Initialized GrupoTrabajoEN
        grupoTrabajoEN = new GrupoTrabajoEN ();
        grupoTrabajoEN.Id = p_oid;
        grupoTrabajoEN.Cod_grupo = p_cod_grupo;
        grupoTrabajoEN.Nombre = p_nombre;
        grupoTrabajoEN.Descripcion = p_descripcion;
        grupoTrabajoEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        grupoTrabajoEN.Capacidad = p_capacidad;
        //Call to GrupoTrabajoCAD

        _IGrupoTrabajoCAD.Modify (grupoTrabajoEN);
}

public void Destroy (int id)
{
        _IGrupoTrabajoCAD.Destroy (id);
}

public System.Collections.Generic.IList<GrupoTrabajoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GrupoTrabajoEN> list = null;

        list = _IGrupoTrabajoCAD.ReadAll (first, size);
        return list;
}
public GrupoTrabajoEN ReadOID (int id)
{
        GrupoTrabajoEN grupoTrabajoEN = null;

        grupoTrabajoEN = _IGrupoTrabajoCAD.ReadOID (id);
        return grupoTrabajoEN;
}

public void Relationer_alumnos (int p_grupotrabajo, System.Collections.Generic.IList<int> p_alumno)
{
        //Call to GrupoTrabajoCAD

        _IGrupoTrabajoCAD.Relationer_alumnos (p_grupotrabajo, p_alumno);
}
public void Relationer_asignatura (int p_grupotrabajo, int p_asignaturaanyo)
{
        //Call to GrupoTrabajoCAD

        _IGrupoTrabajoCAD.Relationer_asignatura (p_grupotrabajo, p_asignaturaanyo);
}
public void Unrelationer_alumnos (int p_grupotrabajo, System.Collections.Generic.IList<int> p_alumno)
{
        //Call to GrupoTrabajoCAD

        _IGrupoTrabajoCAD.Unrelationer_alumnos (p_grupotrabajo, p_alumno);
}
public void Unrelationer_asignatura (int p_grupotrabajo, int p_asignaturaanyo)
{
        //Call to GrupoTrabajoCAD

        _IGrupoTrabajoCAD.Unrelationer_asignatura (p_grupotrabajo, p_asignaturaanyo);
}
}
}
