
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
public partial class ProfesorCEN
{
public void ModifyNoPassword (string p_Profesor_OID, string p_dni, string p_nombre, string p_apellidos, Nullable<DateTime> p_fecha_nacimiento, int p_cod_profesor)
{
        /*PROTECTED REGION ID(DSSGenNHibernate.CEN.Moodle_Profesor_modifyNoPassword_customized) START*/

        ProfesorEN profesorEN = null;

        //Initialized ProfesorEN
        profesorEN = new ProfesorEN ();
        profesorEN.Email = p_Profesor_OID;
        profesorEN.Dni = p_dni;
        profesorEN.Nombre = p_nombre;
        profesorEN.Apellidos = p_apellidos;
        profesorEN.Fecha_nacimiento = p_fecha_nacimiento;
        profesorEN.Cod_profesor = p_cod_profesor;
        //Call to ProfesorCAD

        _IProfesorCAD.ModifyNoPassword (profesorEN);

        /*PROTECTED REGION END*/
}
}
}
