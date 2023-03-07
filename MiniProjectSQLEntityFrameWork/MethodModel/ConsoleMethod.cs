using Dapper;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
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

                foreach (var item in PostGresDataAccess.ReadPersonList())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(" Name: {0}|", item.Person_Name);
                    Console.ResetColor();

                    if (item.Person_Name == fullPersonlName)
                    {
                        InPutNameExit();
                    }
                }

                Console.ReadKey();

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

                foreach (var item in PostGresDataAccess.ReadProjectList())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(" Name: {0}|", item.Project_Name);
                    Console.ResetColor();

                    if (item.Project_Name == fullProjectName)
                    {
                        InPutNameExit();
                    }
                }

                Console.ReadKey();

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

        public static void CreateHour() // problem with Query
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("Welcome to Salary Department." +
                "\nWe need some information from you. Please follow Belows Information.\n");

            ReadProjectListFromConsoleMethod();

            Console.WriteLine("Write the PROJECT NAME. Existing Project names are above.");
            string existingProjectName = Console.ReadLine().ToUpper();

            ProjectModel project = PostGresDataAccess.ReadProject(existingProjectName);

            ReadPersonListFromConsoleMethod();

            Console.WriteLine("Write the Name. Existing NAME are above.");
            string existingPersonName = Console.ReadLine().ToUpper();

            PersonModel person = PostGresDataAccess.ReadPerson(existingPersonName);

            Console.WriteLine("Put Desire Hour.");
            var inputHourConverted = int.TryParse(Console.ReadLine(), out var inputHour);
            if (!inputHourConverted)
            {
                InvalidInput();
            }

            RegistrationModel registration = new RegistrationModel();
            registration.Project_Id = project.Id;
            registration.Person_Id = person.Id;
            registration.Hours = inputHour;

            PostGresDataAccess.SaveRegistration(registration.Project_Id, registration.Person_Id, registration.Hours);
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\n Successfully Updated {existingProjectName} no project with {existingPersonName} no person {inputHour} hours has been registered in our System.");
            Console.ResetColor();
        }

        public static void EditPerson()
        {
            Console.WriteLine("WelCome to Hasan's IT Corporation's List.");

            ReadPersonListFromConsoleMethod();

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

            ReadProjectListFromConsoleMethod();

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

            ReadProjectListFromConsoleMethod();

            Console.WriteLine("Which PROJECT would you like to change the Hour?");
            string existingProjectname = Console.ReadLine();

            ProjectModel project = PostGresDataAccess.ReadProject(existingProjectname);

            ReadPersonListFromConsoleMethod()

            Console.WriteLine("Which NAME would you like to change the Hour?");
            string existingPersonaName = Console.ReadLine();

            PersonModel person = PostGresDataAccess.ReadPerson(existingPersonaName);

            Console.WriteLine("Please put Old Hour.");
            int inputOldHour = int.Parse(Console.ReadLine());

            RegistrationModel registration = PostGresDataAccess.ReadRegistration(inputOldHour);

            Console.WriteLine("Write the new Hours.");
            int inputNewHour = int.Parse(Console.ReadLine());

            PostGresDataAccess.EditRegistrationList(inputNewHour, registration.Id, registration.Project_Id, registration.Person_Id);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Changed.");
            Console.WriteLine($"We will count {inputNewHour} instead of {inputOldHour} in our system.");
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
        public static void InPutNameExit()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This name exit in the system. Please use extra alfabet with your name.");
            Console.ResetColor();
        }
        public static void ReadProjectListFromConsoleMethod()
        {
            foreach (var item in PostGresDataAccess.ReadProjectList())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Name: {0}|", item.Project_Name);
                Console.ResetColor();
            }
        }
        public static void ReadPersonListFromConsoleMethod()
        {
            foreach (var list in PostGresDataAccess.ReadPersonList())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" Name: {0}|", list.Person_Name);
                Console.ResetColor();
            }
        }
    }
}
