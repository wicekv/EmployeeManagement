using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class RegisterEmployeeDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; } = 1;
        public int PhoneNumber { get; set; }
        public int CompanyId { get; set; }
    }
}
