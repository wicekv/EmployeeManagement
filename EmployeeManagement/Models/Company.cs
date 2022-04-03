using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string NIP { get; set; }
        public string CompanyName { get; set; }
        public string Code { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public int BossId { get; set; }
        public Boss Boss { get; set; }
    }
}
