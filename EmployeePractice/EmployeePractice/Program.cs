using EmployeePractice.Models;
using System;

namespace EmployeePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        public static void Menu()
        {
            {
                string commands = "-----------------------------\n1: Create a department\n2: See all departments\n3: Add an employee to selected department\n4: See employees of department\n5: Exit\n-----------------------------";
                Console.WriteLine(@"
 ___       __   _______   ___       ________  ________  _____ ______   _______      
|\  \     |\  \|\  ___ \ |\  \     |\   ____\|\   __  \|\   _ \  _   \|\  ___ \     
\ \  \    \ \  \ \   __/|\ \  \    \ \  \___|\ \  \|\  \ \  \\\__\ \  \ \   __/|    
 \ \  \  __\ \  \ \  \_|/_\ \  \    \ \  \    \ \  \\\  \ \  \\|__| \  \ \  \_|/__  
  \ \  \|\__\_\  \ \  \_|\ \ \  \____\ \  \____\ \  \\\  \ \  \    \ \  \ \  \_|\ \ 
   \ \____________\ \_______\ \_______\ \_______\ \_______\ \__\    \ \__\ \_______\
    \|____________|\|_______|\|_______|\|_______|\|_______|\|__|     \|__|\|_______|
                                                                              
");
            Menu:
                Console.WriteLine("\n----------------------------------------\nChoose the command\nType 0 to get information about commands\n----------------------------------------");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine(commands);
                        goto Menu;
                    case "1":
                        Department.CreateDepartmentFromConsole();
                        goto Menu;
                    case "2":
                        if (Department.department.Length is 0)
                        {
                            Console.WriteLine("There aren't any departments");
                            goto Menu;
                        }
                        Department.PrintDepartment();
                        goto Menu;
                    case "3":
                        if (Department.department.Length is 0)
                        {
                            Console.WriteLine("There aren't any departments");
                            goto Menu;
                        }
                        Department.AddEmployeeToSelectedDepartment();
                        goto Menu;
                    case "4":
                        if (Department.department.Length is 0)
                        {
                            Console.WriteLine("There aren't any departments");
                            goto Menu;
                        }
                        Department.SeeEmployeesOfDepartment();
                        goto Menu;
                    case "5":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input try again!");
                        goto Menu;
                }
            }
        }
    }
}
