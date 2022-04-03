using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Specialization
    { 
        public int SpecializationId { get; set; }
        public string Name { get; set; }
        public List<LevelSpecializationOfAdvance> LevelSpecializationOfAdvances { get; set; }

    }
}
