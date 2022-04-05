using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee: User
    {
        public int PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public List<LevelSpecializationOfAdvance> LevelSpecializationOfAdvances { get; set; }
    }
}
