
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
                ExpedienteEN expediente = new ExpedienteEN();
                ExpedienteCEN expCen = new ExpedienteCEN();
                expediente.Cod_expediente = "EX1";
                expediente.Nota_media = 0;
                expediente.Abierto = true;

                AlumnoEN usuario = new AlumnoEN();
                usuario.Cod_alumno = 1;
                usuario.Baneado = false;
                usuario.Email = "felix@felix.es";
                usuario.Dni = "48627745H";
                usuario.Apellidos = "Escalona";
                usuario.Fecha_nacimiento = DateTime.Parse("28/01/1994");
                usuario.Nombre = "Felix";
                usuario.Password = "1234";
                AlumnoCEN aluCen = new AlumnoCEN();
                aluCen.New_(usuario.Cod_alumno, usuario.Baneado, usuario.Email, usuario.Dni, usuario.Password,
                        usuario.Nombre, usuario.Apellidos, usuario.Fecha_nacimiento, expediente);

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
                asignaturaAnyoCen.New_(idAnyo, asig1);
                asignaturaAnyoCen.New_(idAnyo, asig2);
                asignaturaAnyoCen.New_(idAnyo2, asig3);


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
