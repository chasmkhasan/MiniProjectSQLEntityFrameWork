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

        public static void EditPerson()
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

            Console.WriteLine("Write Old Project Name");
            string oldProjectName = Console.ReadLine().ToUpper();

            ProjectModel project = PostGresDataAccess.ReadProject(oldProjectName);

            Console.WriteLine("Write the new name of the project.");
            string newProjectName = Console.ReadLine().ToUpper();

            PostGresDataAccess.EditProjectList(newProjectName, project.Id);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Changed.");
            Console.WriteLine($"We will continue with {newProjectName} instead of {oldProjectName} in our system.");
            Console.ResetColor();

            Console.ReadKey();
        }

        public static void EditHour()
        {
            Console.WriteLine("WelCome to Hasan's IT Corporation's List.");

            foreach (var item in PostGresDataAccess.ReadRegistrationList())
            {
                Console.WriteLine("ID : {0}  |  Project ID : {1}  |  Person ID : {2}  |  Hour : {3}   |", item.Id, item.Id, item.Id, item.Hours);
            }

            Console.WriteLine("Write the ID number.");
            int inputId = int.Parse(Console.ReadLine());

            Console.WriteLine("Please put Old Hour.");
            int inputOldHour = int.Parse(Console.ReadLine());

            //int count = 0;
            foreach (var list in PostGresDataAccess.ReadRegistrationList())
            {
                if (list.Id == inputId && list.Hours == inputOldHour)
                {
                    Console.WriteLine("Perfect!");
                    //count++;
                }
            }

            Console.WriteLine("Write the new Hours.");
            int inputNewHour = int.Parse(Console.ReadLine());

            RegistrationModel registration = new RegistrationModel();
            registration.Hours = inputNewHour;

            PostGresDataAccess.EditRegistrationList(registration);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Changed.");
            Console.WriteLine($"We will count {inputNewHour} instead of {inputOldHour} in our system.");
            Console.ResetColor();

            Console.ReadKey();

            foreach (var item in PostGresDataAccess.ReadRegistrationList())
            {
                Console.WriteLine("ID : {0}  |  Project ID : {1}  |  Person ID : {2}  |  Hour : {3}   |", item.Id, item.Id, item.Id, item.Hours);
            }

            Console.WriteLine("Please cross check with above information.");
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
