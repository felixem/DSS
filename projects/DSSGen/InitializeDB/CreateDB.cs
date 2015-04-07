
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
                AlumnoEN usuario = new AlumnoEN();
                usuario.Cod_alumno = 1;
                usuario.Baneado = false;
                usuario.Email = "felix@felix.es";
                usuario.Dni = "48627745H";
                usuario.Apellidos = "Escalona";
                usuario.Fecha_nacimiento = DateTime.Parse("28/01/1994");
                usuario.Nombre = "Félix";
                usuario.Password = "1234";
                AlumnoCEN aluCen = new AlumnoCEN();
                aluCen.New_(usuario.Cod_alumno, usuario.Baneado, usuario.Email, usuario.Dni, usuario.Password,
                    usuario.Nombre, usuario.Apellidos, usuario.Fecha_nacimiento, new ExpedienteEN());

                AsignaturaEN asignatura = new AsignaturaEN();
                AsignaturaCEN asigCen = new AsignaturaCEN();
                asignatura.Cod_asignatura = 1;
                asignatura.Nombre = "Asignatura One";
                asignatura.Descripcion = "Asignatura de prueba";
                asignatura.Optativa = false;
                asignatura.Vigente = true;
                int asig = asigCen.New_(asignatura.Cod_asignatura, asignatura.Nombre, asignatura.Descripcion, asignatura.Optativa, asignatura.Vigente);

                asignatura = new AsignaturaEN();
                asigCen = new AsignaturaCEN();
                asignatura.Cod_asignatura = 1;
                asignatura.Nombre = "Asignatura Dos";
                asignatura.Descripcion = "Asignatura Dos de prueba";
                asignatura.Optativa = false;
                asignatura.Vigente = true;
                asigCen.New_(asignatura.Cod_asignatura, asignatura.Nombre, asignatura.Descripcion, asignatura.Optativa, asignatura.Vigente);

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
