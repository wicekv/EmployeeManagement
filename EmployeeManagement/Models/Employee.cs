﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee: User
    {
        public int EmployeeId { get; set; }
        public int PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public List<LevelSpecializationOfAdvance> LevelSpecializationOfAdvances { get; set; }
    }
}
