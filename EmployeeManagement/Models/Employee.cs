using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee: User
    {
        public int Id_Employee { get; set; }
        public int PhoneNumber { get; set; }
        public string Specialization { get; set; }

    }
}
