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

        public static void EditHour() //Problem
        {
            Console.WriteLine("WelCome to Hasan's IT Corporation's List.");

            Console.WriteLine("Please follow below name as it is(List of Project Name).");
            ReadProjectListFromConsoleMethod();
            Console.WriteLine("----------------------------");

            Console.WriteLine("Please follow below name as it is(List of Person Name).");
            ReadPersonListFromConsoleMethod();
            Console.WriteLine("----------------------------");

            Console.WriteLine("Please follow below name as it is(List of Hours).");
            ReadRegistrationListFromConsoleMethod();
            Console.WriteLine("----------------------------");
            //ReadRegistrationListFromConsoleMethod2();

            Console.WriteLine("Which PROJECT would you like to change the Hour?");
            string existingProjectname = Console.ReadLine().ToUpper();

            ProjectModel project = PostGresDataAccess.ReadProject(existingProjectname);

            //ReadRegistrationListFromConsoleMethod();

            Console.WriteLine("Which NAME would you like to change the Hour?");
            string existingPersonaName = Console.ReadLine().ToUpper();

            PersonModel person = PostGresDataAccess.ReadPerson(existingPersonaName);

            Console.WriteLine("Please put Old Hour.");
            var inputHourConverted = int.TryParse(Console.ReadLine(), out var inputOldHour);
            if (!inputHourConverted)
            {
                InvalidInput();
            }

            //RegistrationModel registration = PostGresDataAccess.ReadRegistration(inputOldHour);

            Console.WriteLine("Write the new Hours.");
            var inputNewHourConvereted = int.TryParse(Console.ReadLine(), out var inputNewHour);
            if (!inputNewHourConvereted)
            {
                InvalidInput();
            }

            PostGresDataAccess.EditRegistrationList(inputNewHour, project.Id, person.Id);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Successfully Changed.");
            Console.WriteLine($"{existingPersonaName} hour has been changed from {inputOldHour} instead of {inputNewHour} in our system.");
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

        //public static void ReadRegistrationListFromConsoleMethod()
        //{
        //    foreach (var list in PostGresDataAccess.ReadRegistrationList())
        //    {
        //        Console.ForegroundColor = ConsoleColor.DarkGreen;
        //        Console.WriteLine("Hour : {0}   |", list.Hours);
        //        Console.ResetColor();
        //    }
        //}
        public static void ReadRegistrationListFromConsoleMethod()
        {
            foreach (var list in PostGresDataAccess.ReadRegistrationList())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                //Console.WriteLine("ID : {0} | Project ID : {1} |  Person ID : {2}  |   Hour : {3}   |", list.Id, list.Project_Id, list.Person_Id, list.Hours);
                Console.WriteLine("ID : {0} | Project Name : {1} |  Person Name : {2}  |   Hour : {3}   |", list.Id, list.Project_Name, list.Person_Name, list.Hours);
                //Console.WriteLine(" Project Name : {0} |  Person Name : {1}  |   Hour : {2}   |", list.ProjectName, list.PersonName, list.Hours);
                Console.ResetColor();
            }
        }

        //public static void ReadRegistrationListFromConsoleMethod3()
        //{
        //    for (int i = 0; i < PostGresDataAccess. length; i++)
        //    {

        //    }
        //}


        public static void ReadRegistrationListFromConsoleMethod2()
        {
            foreach (var list in PostGresDataAccess.ReadRegistrationList())
            {
                foreach (var list1 in PostGresDataAccess.ReadPersonList())
                {
                    foreach (var list2 in PostGresDataAccess.ReadProjectList())
                    {
                        //Console.ForegroundColor = ConsoleColor.DarkGreen;
                        //Console.WriteLine("This person ID {0} has been worked  on {1} project for {2} hours.", list.Person_Id, list.Project_Id, list.Hours);
                        //Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("ID : {0}  | Person ID : {1} | Person Name : {2} |   Project ID : {3}  |  Project Name : {4}  |    Hour : {5}   |", list.Id, list1.Id, list1.Person_Name, list2.Id, list2.Project_Name, list.Hours);
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}
