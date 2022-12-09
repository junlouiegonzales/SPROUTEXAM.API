using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUTEXAM.Domain.Enums;

namespace SPROUTEXAM.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public EmployeeType Type { get; set; }
    }
}