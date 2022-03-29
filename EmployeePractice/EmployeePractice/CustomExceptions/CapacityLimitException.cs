using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePractice.CustomExceptions
{
    public class CapacityLimitException : Exception
    {
        public CapacityLimitException(string message) : base()
        {

        }
    }
}
