using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DSSGenNHibernate.EN.Moodle;
using NHibernate;
using ComponentesProceso.Moodle.Commands;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

namespace ComponentesProceso.Moodle
{
    //Componente de proceso para los grupos de trabajo
    public class GrupoTrabajoCP : BasicCP
    {
        //Constructor
        public GrupoTrabajoCP() : base() { }

        //Constructor con sesión
        public GrupoTrabajoCP(ISession sesion) : base(sesion) { }

        //Devolver el resultado de la consulta especificada devolviendo la cantidad de grupos de trabajo que satisfacen la consulta
        public System.Collections.Generic.IList<GrupoTrabajoEN> DameTodosTotal(IDameTodosGrupoTrabajo consulta,
            int first, int size, out long numElementos)
        {
            System.Collections.Generic.IList<GrupoTrabajoEN> lista = null;
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

        //Crear un grupo de trabajo y devolver su id de creación
        public int CrearGrupoTrabajo(string cod, string nombre, string descripcion,
            string password, int capacidad, int asignatura_anyo)
        {
            int id = -1;
            try
            {
                SessionInitializeTransaction();

                //Comprobar que la capacidad no sea negativa
                if (capacidad < 0)
                    throw new Exception("La capacidad no puede ser un número negativo");

                //Crear la asignatura
                GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
                GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);

                //Comprobar que el código sea único
                if (cen.ReadCod(cod) != null)
                    throw new Exception("El código ya está registrado");

                //Comprobar que existe la asignatura
                AsignaturaAnyoCAD asigCad = new AsignaturaAnyoCAD(session);
                AsignaturaAnyoCEN asigCen = new AsignaturaAnyoCEN(asigCad);
                if (asigCen.ReadOID(asignatura_anyo) == null)
                    throw new Exception("La asignatura no existe");

                id = cen.New_(cod,nombre,descripcion,password,capacidad,asignatura_anyo);

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

        //Devolver el resultado de una consulta individual sobre un grupo de trabajo
        public GrupoTrabajoEN DameGrupoTrabajo(IDameGrupoTrabajo consulta)
        {
            GrupoTrabajoEN grupo = null;
            try
            {
                SessionInitializeTransaction();
                //Ejecutar la consulta recibida 
                grupo = consulta.Execute(session);

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

            return grupo;
        }

        //Método para autoregistrar un alumno en un grupo a partir de un password
        public void VincularAlumnoConPassword(int grupoId, string alumno, string pass)
        {
            try
            {
                SessionInitializeTransaction();

                //Comprobar que existe el alumno
                AlumnoCAD aluCad = new AlumnoCAD(session);
                AlumnoCEN aluCen = new AlumnoCEN(aluCad);
                if (aluCen.ReadOID(alumno) == null)
                    throw new Exception("El alumno no existe");

                GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
                GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);
                GrupoTrabajoEN en = cen.ReadOID(grupoId);

                //Comprobar si existe el grupo de trabajo
                if (en == null)
                    throw new Exception("El grupo de trabajo no existe");

                //Comprobar si la capacidad del grupo es suficiente

                List<string> emails = new List<string>();

                if (Auxiliar.Encrypter.Verificar(pass, en.Password))
                {
                    emails.Add(alumno);
                    cen.Relationer_alumnos(grupoId, emails);
                }
                else
                    throw new Exception("Contraseña incorrecta");

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

        //Modificar grupo de trabajo
        public void ModificarGrupoTrabajo(int id, string cod, string nombre, string descripcion,
            string password, int capacidad)
        {
            try
            {
                SessionInitializeTransaction();

                //Comprobar que la capacidad no sea negativa
                if (capacidad < 0)
                    throw new Exception("La capacidad no puede ser un número negativo");

                GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
                GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);
                GrupoTrabajoEN en = cen.ReadOID(id);

                //Comprobar si existe el grupo de trabajo
                if (en == null)
                    throw new Exception("El grupo de trabajo no existe");

                //Comprobar capacidad
                if (en.Alumnos.Count >= en.Capacidad)
                    throw new Exception("El grupo ya está completo");

                //Comprobar si el código cambia y ya está registrado
                if (cod != en.Cod_grupo && cen.ReadCod(cod) != null)
                    throw new Exception("El código ya está registrado");

                //Ejecutar la modificación
                cen.Modify(id,cod,nombre,descripcion,password,capacidad);

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

        //Borrar grupo de trabajo a partir de su id
        public void BorrarGrupoTrabajo(int id)
        {
            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
                GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);

                //Comprobar su existencia
                if (cen.ReadOID(id) == null)
                    throw new Exception("El grupo de trabajo no existe");

                //Ejecutar el borrado
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

        //Desvincular alumnos de un grupo de trabajo
        public void DesvincularAlumnos(int id, IList<string> emails)
        {
            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
                GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);

                //Comprobar su existencia
                if (cen.ReadOID(id) == null)
                    throw new Exception("El grupo de trabajo no existe");

                //Ejecutar la desvinculación
                cen.Unrelationer_alumnos(id, emails);

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

        //Vincular alumnos a un grupo de trabajo
        public void VincularAlumnos(int id, IList<string> emails)
        {
            try
            {
                SessionInitializeTransaction();

                GrupoTrabajoCAD cad = new GrupoTrabajoCAD(session);
                GrupoTrabajoCEN cen = new GrupoTrabajoCEN(cad);
                GrupoTrabajoEN en = cen.ReadOID(id);

                //Comprobar su existencia
                if (cen.ReadOID(id) == null)
                    throw new Exception("El grupo de trabajo no existe");

                //Comprobar tamaño
                if ((en.Alumnos.Count + emails.Count) > en.Capacidad)
                    throw new Exception("El tamaño del grupo es insuficiente");

                //Ejecutar la relación
                cen.Relationer_alumnos(id, emails);

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
