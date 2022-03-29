using EmployeePractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePractice.Models
{
    class Employee : IPerson
    {
        private static int _idCounter;
        private double _salary;
        public int Id { get; }
        public double Salary { get { return _salary; } set { if (value > 0) _salary = value; } }

        public string Name { get; set; }
        public int Age { get; set; }
        static Employee()
        {
            _idCounter = 0;
        }
        private Employee()
        {
            Id = ++_idCounter;
        }
        public Employee(string name, int age, double salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }
        public string ShowInfo()
        {
            return $"ID:{Id}\nName:{Name}\nAge:{Age}\nSalary: {Salary}$\n";
        }
        public override string ToString()
        {
            return ShowInfo();
        }
    }
}
