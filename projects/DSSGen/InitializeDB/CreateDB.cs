
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSSGenNHibernate.EN.Moodle;
using DSSGenNHibernate.CEN.Moodle;
using DSSGenNHibernate.CAD.Moodle;

/*PROTECTED REGION END*/
namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\SQLEXPRESS; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
            //Order create databas
            string createBD = "CREATE DATABASE " + database;
            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
            try
            {
                AdministradorEN admin = new AdministradorEN();
                admin.Cod_administrador = 0;
                admin.Ocupacion = "Administrador";
                admin.Email = "admin@admin.com";
                admin.Dni = "48627742H";
                admin.Apellidos = "admin";
                admin.Fecha_nacimiento = DateTime.Parse("08/08/1994");
                admin.Nombre = "admin";
                admin.Password = "1234";
                AdministradorCEN adminCen = new AdministradorCEN();
                string admin1 = adminCen.New_(admin.Cod_administrador, admin.Ocupacion, admin.Email, admin.Dni, admin.Password, admin.Nombre, admin.Apellidos, admin.Fecha_nacimiento);

                ProfesorEN prof = new ProfesorEN();
                prof.Cod_profesor = 3;
                prof.Email = "jacv050@jacv050.com";
                prof.Dni = "48627746H";
                prof.Apellidos = "jacv050";
                prof.Fecha_nacimiento = DateTime.Parse("08/01/1994");
                prof.Nombre = "jacv050";
                prof.Password = "1234";
                ProfesorCEN profCen = new ProfesorCEN();
                string profesor1 = profCen.New_(prof.Cod_profesor, prof.Email, prof.Dni, prof.Password, prof.Nombre, prof.Apellidos, prof.Fecha_nacimiento);

                prof.Cod_profesor = 11;
                prof.Email = "profesor@profesor.com";
                prof.Dni = "3335556V";
                prof.Apellidos = "Profesor";
                prof.Fecha_nacimiento = DateTime.Parse("08/01/1960");
                prof.Nombre = "Don";
                prof.Password = "1234";
                string profesor2 = profCen.New_(prof.Cod_profesor, prof.Email, prof.Dni, prof.Password, prof.Nombre, prof.Apellidos, prof.Fecha_nacimiento);

                ExpedienteEN expediente = new ExpedienteEN();
                ExpedienteCEN expCen = new ExpedienteCEN();
                expediente.Cod_expediente = "EX1";
                expediente.Nota_media = 0;
                expediente.Abierto = true;

                AlumnoEN alumno = new AlumnoEN();
                alumno.Cod_alumno = 1;
                alumno.Baneado = false;
                alumno.Email = "felix@felix.es";
                alumno.Dni = "48627745H";
                alumno.Apellidos = "Escalona";
                alumno.Fecha_nacimiento = DateTime.Parse("08/11/1994");
                alumno.Nombre = "Felix";
                alumno.Password = "1234";
                AlumnoCEN aluCen = new AlumnoCEN();
                string alumno1 = aluCen.New_(alumno.Cod_alumno, alumno.Baneado, alumno.Email, alumno.Dni, alumno.Password,
                        alumno.Nombre, alumno.Apellidos, alumno.Fecha_nacimiento, expediente);

                CursoEN curso = new CursoEN();
                CursoCEN cursoCen = new CursoCEN();
                curso.Nombre = "Primer Curso";
                curso.Cod_curso = "CS1";
                int curso1 = cursoCen.New_(curso.Cod_curso, curso.Nombre);

                curso.Nombre = "Segundo Curso";
                curso.Cod_curso = "CS2";
                int curso2 = cursoCen.New_(curso.Cod_curso, curso.Nombre);

                AsignaturaEN asignatura = new AsignaturaEN();
                AsignaturaCEN asigCen = new AsignaturaCEN();
                asignatura.Cod_asignatura = "AS1";
                asignatura.Nombre = "Asignatura One";
                asignatura.Descripcion = "Asignatura de prueba";
                asignatura.Optativa = false;
                asignatura.Vigente = true;
                int asig1 = asigCen.New_(asignatura.Cod_asignatura, asignatura.Nombre, asignatura.Descripcion, asignatura.Optativa, asignatura.Vigente, curso1);

                asignatura.Cod_asignatura = "AS2";
                asignatura.Nombre = "Asignatura Dos";
                asignatura.Descripcion = "Asignatura Dos de prueba";
                asignatura.Optativa = false;
                asignatura.Vigente = true;
                int asig2 = asigCen.New_(asignatura.Cod_asignatura, asignatura.Nombre, asignatura.Descripcion, asignatura.Optativa, asignatura.Vigente, curso1);

                asignatura.Cod_asignatura = "AS3";
                asignatura.Nombre = "Asignatura Tres";
                asignatura.Descripcion = "Asignatura Tres de prueba";
                asignatura.Optativa = true;
                asignatura.Vigente = true;
                int asig3 = asigCen.New_(asignatura.Cod_asignatura, asignatura.Nombre, asignatura.Descripcion, asignatura.Optativa, asignatura.Vigente, curso2);

                AnyoAcademicoEN anyo = new AnyoAcademicoEN();
                AnyoAcademicoCEN anyoCen = new AnyoAcademicoCEN();
                anyo.Anyo = "2015/2016";
                anyo.Fecha_inicio = DateTime.Now;
                anyo.Fecha_fin = DateTime.Now;
                anyo.Finalizado = false;
                int idAnyo = anyoCen.New_(anyo.Anyo, anyo.Fecha_inicio, anyo.Fecha_fin, anyo.Finalizado);

                anyo.Anyo = "2016/2017";
                anyo.Fecha_inicio = DateTime.Now;
                anyo.Fecha_fin = DateTime.Now;
                anyo.Finalizado = false;
                int idAnyo2 = anyoCen.New_(anyo.Anyo, anyo.Fecha_inicio, anyo.Fecha_fin, anyo.Finalizado);

                AsignaturaAnyoEN asignaturaAnyo = new AsignaturaAnyoEN();
                AsignaturaAnyoCEN asignaturaAnyoCen = new AsignaturaAnyoCEN();
                int as_anyo1 = asignaturaAnyoCen.New_(idAnyo, asig1);
                int as_anyo2 = asignaturaAnyoCen.New_(idAnyo, asig2);
                int as_anyo3 = asignaturaAnyoCen.New_(idAnyo2, asig3);

                //Vincular profesores con asignaturas
                List<String> profesores = new List<String>();
                profesores.Add(profesor1);
                profesores.Add(profesor2);

                asignaturaAnyoCen.Relationer_profesores(as_anyo1, profesores);
                asignaturaAnyoCen.Relationer_profesores(as_anyo3, profesores);

                GrupoTrabajoEN grupo = new GrupoTrabajoEN();
                GrupoTrabajoCEN grupoCen = new GrupoTrabajoCEN();
                grupo.Cod_grupo = "G1";
                grupo.Nombre = "Grupako";
                grupo.Descripcion = "Gran grupo";
                grupo.Password = "pass";
                grupo.Capacidad = 2;
                int grupo1 = grupoCen.New_(grupo.Cod_grupo, grupo.Nombre, grupo.Descripcion, grupo.Password, grupo.Capacidad, as_anyo1);

                EvaluacionEN eval = new EvaluacionEN();
                EvaluacionCEN evalCen = new EvaluacionCEN();
                eval.Nombre = "Primera Evaluacion";
                eval.Fecha_inicio = DateTime.Now;
                eval.Fecha_fin = DateTime.Now;
                eval.Abierta = true;
                int eval1 = evalCen.New_(eval.Nombre, eval.Fecha_inicio, eval.Fecha_fin, eval.Abierta, idAnyo);

                alumno = aluCen.ReadOID(alumno1);
                int expediente1 = alumno.Expediente.Id;

                ExpedienteAnyoCEN expAnyoCen = new ExpedienteAnyoCEN();
                ExpedienteAnyoEN expAnyo = new ExpedienteAnyoEN();
                expAnyo.Abierto = true;
                int expAnyo1 = expAnyoCen.New_(expAnyo.Nota_media, expAnyo.Abierto, expediente1, idAnyo);

                ExpedienteAsignaturaCEN expAsigCen = new ExpedienteAsignaturaCEN();
                ExpedienteAsignaturaEN expAsig = new ExpedienteAsignaturaEN();
                int expAsig1 = expAsigCen.New_(expAsig.Nota_media, expAsig.Abierto, expAnyo1, as_anyo1);


                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
    }
}
