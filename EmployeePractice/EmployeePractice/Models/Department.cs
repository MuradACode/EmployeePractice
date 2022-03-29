using EmployeePractice.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePractice.Models
{
    class Department
    {
        public string Name { get; set; }
        public int EmployeeLimit { get; set; }
        private static Employee[] _employees = new Employee[0];
        public static Department[] department = new Department[0];
        public Employee this[int index]
        {
            get { return _employees[index]; }
            set { _employees[index] = value; }
        }
        private Department()
        {
            Array.Resize(ref department, department.Length + 1);
            department[^1] = this;
        }
        public Department(string name, int employeeLimit) : this()
        {
            Name = name;
            EmployeeLimit = employeeLimit;
        }
        public void AddEmployee(Employee employee)
        {
            if (EmployeeLimit < _employees.Length)
            {
                throw new CapacityLimitException("Limit exceeded");
            }
            Array.Resize(ref _employees, _employees.Length + 1);
            _employees[^1] = employee;
        }
        public static void CreateDepartmentFromConsole()
        {
            Console.Clear();
            Console.WriteLine(@"
   ______                __                       __                      __                       __ 
  / ____/_______  ____ _/ /____     ____ _   ____/ /__  ____  ____ ______/ /_____ ___  ___  ____  / /_
 / /   / ___/ _ \/ __ `/ __/ _ \   / __ `/  / __  / _ \/ __ \/ __ `/ ___/ __/ __ `__ \/ _ \/ __ \/ __/
/ /___/ /  /  __/ /_/ / /_/  __/  / /_/ /  / /_/ /  __/ /_/ / /_/ / /  / /_/ / / / / /  __/ / / / /_  
\____/_/   \___/\__,_/\__/\___/   \__,_/   \__,_/\___/ .___/\__,_/_/   \__/_/ /_/ /_/\___/_/ /_/\__/  
                                                    /_/                                               
");
        TryDepartmentName:
            Console.Write("Type the name of department: ");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryDepartmentName;
            }
        TryEmployeeLimit:
            Console.Write("What is the employee limit? : ");
            int employeeLimit;
            try
            {
                employeeLimit = Convert.ToInt32(Console.ReadLine().Trim());
                if (employeeLimit < 1)
                {
                    Console.WriteLine("It's impossible try again!");
                    goto TryEmployeeLimit;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TryEmployeeLimit;
            }
            Department department = new Department(name, employeeLimit);

            Console.WriteLine("----------------------------------------\nDepartment created successfully\n----------------------------------------");
        }
        public static void PrintDepartment()
        {
            Console.Clear();
            Console.WriteLine(@"
    ____                        __                       __      
   / __ \___  ____  ____ ______/ /_____ ___  ___  ____  / /______
  / / / / _ \/ __ \/ __ `/ ___/ __/ __ `__ \/ _ \/ __ \/ __/ ___/
 / /_/ /  __/ /_/ / /_/ / /  / /_/ / / / / /  __/ / / / /_(__  ) 
/_____/\___/ .___/\__,_/_/   \__/_/ /_/ /_/\___/_/ /_/\__/____/  
          /_/                                                    
");
            for (int i = 0; i < department.Length; i++)
            {
                Console.WriteLine(i + 1 + ")\nDepartment's name: " + department[i].Name + "\nEmployee limit:" + department[i].EmployeeLimit);
            }
        }
        public static void AddEmployeeToSelectedDepartment()
        {
        DepartmentTry:
            PrintDepartment();
            Console.WriteLine("\nSelect a department:");
            string input = Console.ReadLine().Trim();
            int select = 0;
            for (int i = 0; i < department.Length; i++)
            {
                if (input == department[i].Name)
                {
                    Console.WriteLine("Department selected");
                    select = i;
                    break;
                }
                else
                {
                    Console.WriteLine("This Department does not exist\nTry again!");
                    goto DepartmentTry;
                }
            }
        TryEmployeeName:
            Console.Write("Type the name of the employee: ");
            string employeeName = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(employeeName))
            {
                Console.Clear();
                Console.WriteLine("Name can't be empty!");
                goto TryEmployeeName;
            }
        TryAge:
            Console.Write("How old is the employee : ");
            int age;
            try
            {
                age = Convert.ToInt32(Console.ReadLine().Trim());
                if (age > 150 || age < 1)
                {
                    Console.WriteLine("It's impossible try again!");
                    goto TryAge;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TryAge;
            }
        TrySalary:
            Console.Write("How much is the salary of employee?: ");
            int salary;
            try
            {
                salary = Convert.ToInt32(Console.ReadLine().Trim());
                if (salary < 1)
                {
                    Console.WriteLine("It's impossible try again!");
                    goto TrySalary;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input try again!");
                goto TrySalary;
            }
            Employee employee = new Employee(employeeName, age, salary);
            department[select].AddEmployee(employee);
            Console.WriteLine("----------------------------------------\nEmployee created successfully\n----------------------------------------");
        }
        public static void SeeEmployeesOfDepartment()
        {
            PrintDepartment();
        DepartmentSelectTry:
            Console.WriteLine("\nSelect the department:");
            string input = Console.ReadLine();
            for (int i = 0; i < department.Length; i++)
            {
                if (input == department[i].Name)
                {
                    for (int n = 0; n < _employees.Length; n++)
                    {
                        Console.WriteLine("Employees:\n" + _employees[n].ToString() + "\n");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("This department does not exist\nTry again!");
                    goto DepartmentSelectTry;
                }
            }
        }
    }
}
