using Dapper;
using MiniProjectSQLEntityFrameWork.ClassModel;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectSQLEntityFrameWork.MethodModel
{
    public class ConsoleMethod
    {
        // I want to decleare globally.
        public static void CreatePersonlFile()
        {
            try
            {
                Console.WriteLine("Welcome to registration Department." +
                "\nWe need some information from you. Please follow Belows Information.");

                Console.WriteLine("Please Enter your Full Name.");
                string fullPersonlName = Console.ReadLine().ToUpper();

                PersonModel person = new PersonModel();
                person.Person_Name = fullPersonlName;

                PostGresDataAccess.SavePersonList(person);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{fullPersonlName} Succeefully Registered in our system.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                // Invalid method has been called.
                InvalidInput();
            }
        }

        public static void CreateProjectFile()
        {

            try
            {
                Console.WriteLine("Welcome to registration Department." +
                "\nWe need some information from you. Please follow Belows Information.\n");

                Console.WriteLine("Please Enter your Project Name.");
                string fullProjectName = Console.ReadLine().ToUpper();

                ProjectModel project = new ProjectModel();
                project.Project_Name = fullProjectName;

                PostGresDataAccess.SaveProjectList(project);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{fullProjectName} Succeefully Registered in our system.");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                InvalidInput();
            }

        }

        public static void CreateSalary() // problem with Query
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to Salary Department." +
                "\nWe need some information from you. Please follow Belows Information.\n");


            // Input Project information
            // Read project list
            foreach (var item in PostGresDataAccess.ReadProjectList())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("ID : {0}  |  Name: {1}|", item.Id, item.Project_Name);
                Console.ResetColor();
            }

            Console.WriteLine("Please put project ID Number");
            var inputProjectIdConverted = int.TryParse(Console.ReadLine(), out var inputProjectId);
            if (!inputProjectIdConverted)
            {
                InvalidInput();
            }

            //validation of ID //Probelm
            //foreach (var item in PostGresDataAccess.ReadProjectList())
            //{
            //    if (item.Id == inputProjectId)
            //    {
            //        //IdDontExit();
            //        //goto inputProjectId;
            //    }
            //}

            RegistrationModel registration = new RegistrationModel();
            registration.Project_Id = inputProjectId;
            PostGresDataAccess.SaveRegistrationList(registration);

            // Input Person information
            // Read person List.
            foreach (var list in PostGresDataAccess.ReadPersonList())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("ID : {0}  |  Name: {1}|", list.Id, list.Person_Name);
                Console.ResetColor();
            }

            Console.WriteLine("Please put your ID number.");
            var inputPersonIdConverted = int.TryParse(Console.ReadLine(), out var inputPersonId);
            if (!inputPersonIdConverted)
            {
                InvalidInput();
            }

            // validation of ID   // Problem
            // Able to take Name instead of ID. Then I need to foreign of DB.
            //foreach (var list in PostGresDataAccess.ReadPersonList())
            //{
            //    if (list.Id == inputProjectId)
            //    {
            //        //IdDontExit();
            //        //goto inputPersonId;
            //    }
            //}

            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.Person_Id = inputPersonId;
            PostGresDataAccess.SaveRegistrationList(registration);

            Console.WriteLine("How much hour did you work?");
            var inputHourConverted = int.TryParse(Console.ReadLine(), out var inputHour);
            if (!inputHourConverted)
            {
                InvalidInput();
            }

            RegistrationModel registrationModel1 = new RegistrationModel();
            registrationModel1.Hours = inputHour;
            PostGresDataAccess.SaveRegistrationList(registration);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n Successfully Updated {inputProjectId} no project with {inputPersonId} no person {inputHour} hours has been registered in our System.");
            Console.ResetColor();

        }

        public static void EditPerson() // problem with Query
        {
            Console.WriteLine("WelCome to Hasan's IT Corporation's List.");

            Console.WriteLine("Which person would you like to change the NAME?");
            string oldName = Console.ReadLine().ToUpper();

            PersonModel person = PostGresDataAccess.ReadPerson(oldName); 

            Console.WriteLine("Write the new name of the person.");
            string newPersonName = Console.ReadLine().ToUpper();

            PostGresDataAccess.EditPersonList(newPersonName, person.Id);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Changed.");
            Console.WriteLine($"We will continue with {newPersonName} instead of {oldName} in our system.");
            Console.ResetColor();

            Console.ReadKey();
        }

        public static void EditProject()
        {
            Console.WriteLine("WelCome to Hasan's IT Corporation's List.");

            foreach (var item in PostGresDataAccess.ReadProjectList())
            {
                Console.WriteLine("ID : {0}  |  Name: {1}| ", item.Id, item.Project_Name);
            }

            Console.WriteLine("Write the ID number");
            int inputId = int.Parse(Console.ReadLine());

            Console.WriteLine("Which project would you like to chnage?");
            string oldProjectName = Console.ReadLine().ToUpper();

            //int count = 0;
            foreach (var list in PostGresDataAccess.ReadProjectList())
            {
                if (list.Project_Name == oldProjectName && list.Id == inputId)
                {
                    Console.WriteLine("Perfect!");
                    //count++;
                }
            }

            Console.WriteLine("Write the new name of the project.");
            string newProjectName = Console.ReadLine().ToUpper();

            ProjectModel project = new ProjectModel();
            //project.Project_Name = oldProjectName;
            project.Project_Name = newProjectName;

            PostGresDataAccess.EditProjectList(project);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Changed.");
            Console.WriteLine($"We will continue with {newProjectName} instead of {oldProjectName} in our system.");
            Console.ResetColor();

            Console.ReadKey();
        }

        public static void DeletePerson()
        {

            Console.WriteLine("WelCome to Hasan's IT Corporation's List List.");

            //var listOfPerson = connectionWithServer.Query<PersonModel>($"SELECT * FROM kha_person", new DynamicParameters());

            foreach (var item in PostGresDataAccess.ReadPersonList())
            {
                Console.WriteLine("ID : {0}  |  Name: {1}| ", item.Id, item.Person_Name);
            }

            Console.WriteLine("Write the ID number");
            int inputId = int.Parse(Console.ReadLine());

            Console.WriteLine("Which Person would you like to Delete?");
            string deletedPersonName = Console.ReadLine().ToUpper();

            //int count = 0;
            foreach (var list in PostGresDataAccess.ReadPersonList())
            {
                if (list.Person_Name == deletedPersonName && list.Id == inputId)
                {
                    Console.WriteLine("Perfect!");
                    //count++;
                }
            }

            PersonModel person = new PersonModel();
            person.Person_Name = deletedPersonName;

            PostGresDataAccess.DeletePersonList(person);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Deleted.");
            Console.WriteLine($"Our System will not recognized {deletedPersonName} anymore.");
            Console.ResetColor();

            Console.ReadKey();

        }

        public static void InvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Invalid input!. Please put spacific information.");
            Console.ResetColor();
        }

        public static void IdDontExit()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("ID Doesn't exit in the system");
            Console.ResetColor();
        }
    }
}
