using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SPROUTEXAM.Domain.Enums;

namespace SPROUTEXAM.Application.Employee.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public EmployeeType Type { get; set; }
    }
}