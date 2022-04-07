using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.DTO
{
    public class RegisterBossDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; } = 2;
        public string UniqueCode { get; set; }
        public string NIP { get; set; }
        public string CompanyName { get; set; }
        public string Code { get; set; }
    }
}
