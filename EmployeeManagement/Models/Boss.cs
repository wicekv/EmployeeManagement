using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Boss : User
    {
        public string UniqueCode { get; set; }
        public Company Company { get; set; }
    }
}
