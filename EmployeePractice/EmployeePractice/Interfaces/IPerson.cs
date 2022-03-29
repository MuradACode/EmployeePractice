using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePractice.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
        public string ShowInfo();
    }
}
