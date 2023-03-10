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
        // Print Person list from Database.
        public static List<PersonModel> ReadPersonList()
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfPerson = connectionWithServer.Query<PersonModel>($" SELECT * FROM kha_person", new DynamicParameters());
                return listOfPerson.ToList();
            }
        }

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
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

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
        public static void EditPersonList(string name, int id)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_person SET person_name = '{name}' WHERE id = {id} ");
            }
        }

        // Delete query have method. Havn't done yet.
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
                var listOfProject = connectionWithServer.Query<ProjectModel>($"SELECT * FROM kha_project");//, new DynamicParameters());
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

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
        public static ProjectModel ReadProject(string name)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfProject = connectionWithServer.Query<ProjectModel>($"SELECT * FROM kha_project WHERE project_name = '{name}'", new DynamicParameters());
                return listOfProject.FirstOrDefault();
            }
        }

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
        public static void EditProjectList(String name, int id)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_project SET project_name = '{name}' WHERE id = {id} ");
            }
        }

        // Delete query have method. Havn't done yet.
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
                //var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * From kha_project_person");//, new DynamicParameters());
                //var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT *, project_id AS project_name , person_id AS person_name From kha_project_person ");//, new DynamicParameters());
                var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT *, kha_project.project_name , kha_person.person_name From kha_project, kha_person, kha_project_person WHERE project_id = kha_project.id AND person_id = kha_person.id  ");//, new DynamicParameters());
                return listOfRegistrationList.ToList();
            }
        }

        //public static List<AllRegistrationInfor> ReadRegistrationList()
        //{
        //    var result = new List<AllRegistrationInfor>();
        //    using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
        //    {
        //        var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * From kha_project_person").ToList();//, new DynamicParameters());
        //        var listOfRegistrationPersonList = connectionWithServer.Query<PersonModel>($"SELECT * From kha_person").ToList();//, new DynamicParameters());
        //        var listOfRegistrationProjectList = connectionWithServer.Query<ProjectModel>($"SELECT * From kha_project").ToList();//, new DynamicParameters());
        //        var listOfAllInformation = listOfRegistrationList.Select(r => r.Hours);
        //        var prInfo = listOfRegistrationPersonList.Select(r => new { r.Person_Name, r.Id });
        //        var pjInfo = listOfRegistrationProjectList.Select(r => new { r.Project_Name, r.Id });
        //        foreach (var hr in listOfAllInformation)
        //        {
        //            foreach (var pn in prInfo)
        //            {
        //                foreach (var pj in pjInfo)
        //                {
        //                    var all = new AllRegistrationInfor()
        //                    {
        //                        Hours = hr,
        //                        PersonName = pn.Person_Name,
        //                        ProjectName = pj.Project_Name,
        //                        PersonId = pn.Id,
        //                        ProjectId = pj.Id,
        //                    };
        //                    result.Add(all);
        //                }
        //            }

        //        }
        //    }
        //    return result;
        //}

        public static void SaveRegistrationList(RegistrationModel registration)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"INSERT INTO kha_project_person (project_id, person_id, hours) VALUES ('{registration.Project_Id}','{registration.Person_Id}',{registration.Hours})", registration);
            }
        }

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
        public static void SaveRegistration(int id, int id1, int hour)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"INSERT INTO kha_project_person (project_id, person_id, hours) VALUES ( {id}, {id1}, {hour}) ");
            }
        }

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
        public static RegistrationModel ReadRegistration(int hour)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * FROM kha_project_person WHERE hours = {hour}"); //, new DynamicParameters());
                return listOfRegistrationList.FirstOrDefault();
            }
        }

        // parameter has been decleare because of read the list find out the name and give me the ID or other column.
        public static void EditRegistrationList(int hour, int id1, int id2)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_project_person SET hours = {hour} WHERE project_id = {id1} AND person_id = {id2}");
            }
        }

        // Delete query have method. Havn't done yet.
        public static void DeleteRegistrationList(RegistrationModel registration)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute("DELETE FROM kha_project_person WHERE hours = @Hours", registration);
            }
        }

        // Method has been decleare for connect with database.
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
