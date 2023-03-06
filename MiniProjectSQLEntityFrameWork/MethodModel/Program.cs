
using MiniProjectSQLEntityFrameWork.ClassModel;
using System;

namespace MiniProjectSQLEntityFrameWork.MethodModel
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] menuOptions = new string[] { "CreatePersonlFile\t", "CreateProjectFile\t", "CreateSalary\t", "EditPersonList\t", "EditProject\t", "EditHour\t" };
            //{ "CreatePersonlFile\t", "New staff\t", "Serivce\t", "Reparation\t", "Garantie\t" };
            int menuSelect = 0;
            
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("Hello and welcome! Please choose type of registration:");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine((i == menuSelect ? "* " : "") + menuOptions[i] + (i == menuSelect ? "<--" : ""));
                }

                var keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                {
                    menuSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            ConsoleMethod.CreatePersonlFile();
                            break;
                        case 1:
                            ConsoleMethod.CreateProjectFile();
                            break;
                        case 2:
                            ConsoleMethod.CreateSalary();
                            break;
                        case 3:
                            ConsoleMethod.EditPerson();
                            break;
                        case 4:
                            ConsoleMethod.EditProject();
                            break;
                        case 5:
                            ConsoleMethod.EditHour();
                            break;
                    }
                }
            }
        }
    }
}