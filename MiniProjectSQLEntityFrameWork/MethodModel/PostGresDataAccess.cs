using Dapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using MiniProjectSQLEntityFrameWork.ClassModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectSQLEntityFrameWork.MethodModel
{
    public class PostGresDataAccess
    {
        public static List<PersonModel> ReadPersonList()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfPerson = connectionWithServer.Query<PersonModel>($" SELECT * FROM kha_person", new DynamicParameters());
                return listOfPerson.ToList();
            }
        }

        public static PersonModel ReadPerson(string name)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfPerson = connectionWithServer.Query<PersonModel>($"SELECT * FROM kha_person WHERE person_name = '{name}'", new DynamicParameters());
                return listOfPerson.FirstOrDefault();
            }
        }

        public static void SavePersonList(PersonModel person)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("INSERT INTO kha_person(person_name) VALUES (@Person_Name)", person);
            }
        }

        public static void EditPersonList(string name, int id)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_person SET person_name = '{name}' WHERE id = {id} ");
            }
        }

        public static void DeletePersonList(PersonModel person)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("DELETE FROM kha_person WHERE person_name = @Person_Name", person);
            }
        }

        public static List<ProjectModel> ReadProjectList()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfProject = connectionWithServer.Query<ProjectModel>($"SELECT * FROM kha_project", new DynamicParameters());
                return listOfProject.ToList();
            }
        }

        public static void SaveProjectList(ProjectModel project)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("INSERT INTO kha_project(project_name) VALUES (@Project_Name)", project);    
            }
        }

        public static ProjectModel ReadProject(string name)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfProject = connectionWithServer.Query<ProjectModel>($"SELECT * FROM kha_project WHERE project_name = '{name}'", new DynamicParameters());
                return listOfProject.FirstOrDefault();
            }
        }

        public static void EditProjectList(String name, int id)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_project SET project_name = '{name}' WHERE id = {id} ");
            }
        }

        public static void DeleteProjectList(ProjectModel project)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("DELETE FROM kha_project WHERE project_name = @Project_Name", project);
            }
        }

        public static List<RegistrationModel> ReadRegistrationList()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * From kha_project_person", new DynamicParameters());
                return listOfRegistrationList.ToList();
            }
        }

        public static void SaveRegistrationList(RegistrationModel registration)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("INSERT INTO kha_project_person(project_id, person_id, hours) VALUES (@Project_Id, @Person_Id, @Hours)", registration);
            }
        }

        public static RegistrationModel ReadRegistration(int hour)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * FROM kha_project_person WHERE hours = {hour}", new DynamicParameters());
                return listOfRegistrationList.FirstOrDefault();
            }
        }

        public static void EditRegistrationList(int hour, int Id, int Id1, int Id2)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_project_person SET hours = {hour} WHERE id = {Id} AND project_id = {Id1} AND person_id = {Id2}");
            }
        }

        public static void DeleteRegistrationList(RegistrationModel registration)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("DELETE FROM kha_project_person WHERE hours = @Hours", registration);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
