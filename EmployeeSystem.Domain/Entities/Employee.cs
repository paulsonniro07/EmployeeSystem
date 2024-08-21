using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Entities
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        NonBinary = 3,
        Other = 4
    }

    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee No is required")]
        public string EmployeeNo { get; set; }


        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; } = Gender.Other;

        public string? Email { get; set; }


        [Required(ErrorMessage = "Contact No is required")]
        public string ContactNo { get; set; }


        public string? EmployeeAddress { get; set; }


        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }


        [Required(ErrorMessage = "Department is required")]
        public int DepartmentId { get; set; } = 1;
        public Department Department { get; set; }
    }
}
