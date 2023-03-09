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
                //var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * From kha_project_person");//, new DynamicParameters());
                //var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT *, project_id AS project_name , person_id AS person_name From kha_project_person ");//, new DynamicParameters());
                var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT *, kha_project.project_name , kha_person.person_name From kha_project, kha_person, kha_project_person WHERE project_id = kha_project.id AND person_id = kha_person.id  ");//, new DynamicParameters());
                return listOfRegistrationList.ToList();
            }
        }

        //public static List<RegistrationModel> ReadRegistrationList()
        //{
        //    using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
        //    {
        //        var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * From kha_project_person");//, new DynamicParameters());
        //        var listOfRegistrationList1 = connectionWithServer.Query<PersonModel>($"SELECT * From kha_person");//, new DynamicParameters());
        //        var listOfRegistrationList2 = connectionWithServer.Query<ProjectModel>($"SELECT * From kha_project");//, new DynamicParameters());
        //        var allList = connectionWithServer.Query
        //        //var allList = (listOfRegistrationList + listOfRegistrationList1 + listOfRegistrationList2).Tolist();

        //        return listOfRegistrationList.ToList();
        //        listOfRegistrationList1.ToList();
        //        listOfRegistrationList2.ToList();

        //        //return ReadRegistrationList();
        //    }
        //}

        //      SELECT*
        //FROM table1
        //INNER JOIN table2
        //ON table1.id = table2.id
        //INNER JOIN table3
        //ON table2.id = table3.id;

        //"SELECT p.project_name, pp.hours " +
        //                         "FROM mra_project p " +
        //                         "JOIN mra_project_person pp(varible) ON pp.project_id = p.id " +
        //                         "JOIN mra_person pe ON pp.person_id = pe.id " +
        //                         "WHERE pe.person_name = @personName";

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

        public static void SaveRegistration(int id, int id1, int hour)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"INSERT INTO kha_project_person (project_id, person_id, hours) VALUES ( {id}, {id1}, {hour}) ");
            }
        }

        public static RegistrationModel ReadRegistration(int hour)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                var listOfRegistrationList = connectionWithServer.Query<RegistrationModel>($"SELECT * FROM kha_project_person WHERE hours = {hour}"); //, new DynamicParameters());
                return listOfRegistrationList.FirstOrDefault();
            }
        }

        public static void EditRegistrationList(int hour, int id1, int id2)
        {
            using (NpgsqlConnection connectionWithServer = new NpgsqlConnection(LoadConnectionString()))
            {
                connectionWithServer.Execute($"UPDATE kha_project_person SET hours = {hour} WHERE project_id = {id1} AND person_id = {id2}");
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
