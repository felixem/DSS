
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
public partial class AlumnoCEN
{
public void ModifyNoPassword (string p_oid, int p_cod_alumno, bool p_baneado, string p_dni, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Alumno_modifyNoPassword_customized) START*/

        AlumnoEN alumnoEN = null;

        //Initialized AlumnoEN
        alumnoEN = new AlumnoEN ();
        alumnoEN.Email = p_oid;
        alumnoEN.Cod_alumno = p_cod_alumno;
        alumnoEN.Baneado = p_baneado;
        alumnoEN.Dni = p_dni;
        alumnoEN.Nombre = p_nombre;
        alumnoEN.Apellidos = p_apellidos;
        alumnoEN.Fecha_nacimiento = p_fecha_nacimiento;
        //Call to AlumnoCAD

        _IAlumnoCAD.ModifyNoPassword (alumnoEN);

        /*PROTECTED REGION END*/
}
}
}
