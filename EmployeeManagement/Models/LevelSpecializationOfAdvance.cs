using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class LevelSpecializationOfAdvance
    {
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public int LevelOfAdvanceId { get; set; }
        public LevelOfAdvance LevelOfAdvance { get; set; }
        public int UserId { get; set; }
        public Employee Employee { get; set; }

    }
}
