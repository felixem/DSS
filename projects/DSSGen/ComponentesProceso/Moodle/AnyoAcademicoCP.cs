using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using DSSGenNHibernate.EN.Moodle;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para el año académico
    public class AnyoAcademicoCP : BasicCP
    {
        //Constructor
        public AnyoAcademicoCP() : base() { }

        //Constructor con sesión
        public AnyoAcademicoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de años académicos que satisfacen la consulta
        public System.Collections.Generic.IList<AnyoAcademicoEN> DameTodosTotal(IDameTodosAnyoAcademico consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<AnyoAcademicoEN> lista = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                lista = consulta.Execute(session, first, size);
                numElementos = consulta.Total(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return lista;
        }

        //Crear un año académico y devolver su id de creación
        public int CrearAnyoAcademico(string anyo, DateTime fecha_inicio,
            DateTime fecha_fin, bool finalizado)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();

                //Comparar las fechas de inicio y de fin
                if(DateTime.Compare(fecha_inicio,fecha_fin) >= 0)
                    throw new Exception("La fecha de inicio debe ser anterior a la fecha de fin");

                //Crear el año académico
                AnyoAcademicoCAD cad = new AnyoAcademicoCAD(session);
                AnyoAcademicoCEN cen = new AnyoAcademicoCEN(cad);

                AnyoAcademicoEN anyoEn = cen.ReadCod(anyo);
                if (anyoEn != null)
                    throw new Exception("El año académico ya está registrado");

                id = cen.New_(anyo, fecha_inicio, fecha_fin, finalizado);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return id;
        }

        //Devolver el resultado de una consulta individual sobre un año académico
        public AnyoAcademicoEN DameAnyoAcademico(IDameAnyoAcademico consulta)
        {
            AnyoAcademicoEN anyo = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                anyo = consulta.Execute(session);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }

            return anyo;
        }

        //Modificar año académico
        public void ModificarAnyoAcademico(int oid, string anyo, DateTime fecha_inicio,
            DateTime fecha_fin, bool finalizado)
        {
            try
            {
                SessionInitializeTransaction();

                //Comparar las fechas de inicio y de fin
                if (DateTime.Compare(fecha_inicio, fecha_fin) >= 0)
                    throw new Exception("La fecha de inicio debe ser anterior a la fecha de fin");

                AnyoAcademicoCAD cad = new AnyoAcademicoCAD(session);
                AnyoAcademicoCEN cen = new AnyoAcademicoCEN(cad);

                AnyoAcademicoEN anyoEn = cen.ReadOID(oid);
                if (anyoEn == null)
                    throw new Exception("El año académico no existe");

                if (anyo != anyoEn.Anyo && cen.ReadCod(anyo) != null)
                    throw new Exception("El nombre del año académico ya existe");

                //Ejecutar la modificación
                cen.Modify(oid,anyo,fecha_inicio,fecha_fin,finalizado);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }

        //Borrar año académico a partir de su id
        public void BorrarAnyoAcademico(int id)
        {
            try
            {
                SessionInitializeTransaction();

                AnyoAcademicoCAD cad = new AnyoAcademicoCAD(session);
                AnyoAcademicoCEN cen = new AnyoAcademicoCEN(cad);

                if (cen.ReadOID(id) == null)
                    throw new Exception("El año académico no existe");

                //Ejecutar la modificación
                cen.Destroy(id);

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                //Cerrar sesión
                SessionClose();
            }
        }
    }
}
