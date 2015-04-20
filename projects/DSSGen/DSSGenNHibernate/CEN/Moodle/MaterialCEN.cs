

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
public partial class MaterialCEN
{
private IMaterialCAD _IMaterialCAD;

public MaterialCEN()
{
        this._IMaterialCAD = new MaterialCAD ();
}

public MaterialCEN(IMaterialCAD _IMaterialCAD)
{
        this._IMaterialCAD = _IMaterialCAD;
}

public IMaterialCAD get_IMaterialCAD ()
{
        return this._IMaterialCAD;
}

public int New_ (string p_nombre, string p_descripcion, string p_ruta, float p_tam, Nullable<DateTime> p_fecha_subida, bool p_visible, string p_profesor, int p_asignatura)
{
        MaterialEN materialEN = null;
        int oid;

        //Initialized MaterialEN
        materialEN = new MaterialEN ();
        materialEN.Nombre = p_nombre;

        materialEN.Descripcion = p_descripcion;

        materialEN.Ruta = p_ruta;

        materialEN.Tam = p_tam;

        materialEN.Fecha_subida = p_fecha_subida;

        materialEN.Visible = p_visible;


        if (p_profesor != null) {
                materialEN.Profesor = new DSSGenNHibernate.EN.Moodle.ProfesorEN ();
                materialEN.Profesor.Email = p_profesor;
        }


        if (p_asignatura != -1) {
                materialEN.Asignatura = new DSSGenNHibernate.EN.Moodle.AsignaturaAnyoEN ();
                materialEN.Asignatura.Id = p_asignatura;
        }

        //Call to MaterialCAD

        oid = _IMaterialCAD.New_ (materialEN);
        return oid;
}

public void Modify (int p_oid, string p_nombre, string p_descripcion, string p_ruta, float p_tam, Nullable<DateTime> p_fecha_subida, bool p_visible)
{
        MaterialEN materialEN = null;

        //Initialized MaterialEN
        materialEN = new MaterialEN ();
        materialEN.Id = p_oid;
        materialEN.Nombre = p_nombre;
        materialEN.Descripcion = p_descripcion;
        materialEN.Ruta = p_ruta;
        materialEN.Tam = p_tam;
        materialEN.Fecha_subida = p_fecha_subida;
        materialEN.Visible = p_visible;
        //Call to MaterialCAD

        _IMaterialCAD.Modify (materialEN);
}

public void Destroy (int id)
{
        _IMaterialCAD.Destroy (id);
}

public System.Collections.Generic.IList<MaterialEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> list = null;

        list = _IMaterialCAD.ReadAll (first, size);
        return list;
}
public MaterialEN ReadOID (int id)
{
        MaterialEN materialEN = null;

        materialEN = _IMaterialCAD.ReadOID (id);
        return materialEN;
}

public long ReadCantidad ()
{
        return _IMaterialCAD.ReadCantidad ();
}
public void Relationer_asignatura (int p_material, int p_asignaturaanyo)
{
        //Call to MaterialCAD

        _IMaterialCAD.Relationer_asignatura (p_material, p_asignaturaanyo);
}
public void Relationer_profesor (int p_material, string p_profesor)
{
        //Call to MaterialCAD

        _IMaterialCAD.Relationer_profesor (p_material, p_profesor);
}
public void Unrelationer_asignatura (int p_material, int p_asignaturaanyo)
{
        //Call to MaterialCAD

        _IMaterialCAD.Unrelationer_asignatura (p_material, p_asignaturaanyo);
}
public void Unrelationer_profesor (int p_material, string p_profesor)
{
        //Call to MaterialCAD

        _IMaterialCAD.Unrelationer_profesor (p_material, p_profesor);
}
}
}
