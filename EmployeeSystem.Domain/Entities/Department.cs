using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Code is required")]
        public string DepartmentCode { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }
    }
}
