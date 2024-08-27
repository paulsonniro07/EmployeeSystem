using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public string? AttendanceNo { get; set; }

        public DateTime? AttendanceDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public List<EmployeeAttendance> EmployeeAttendances { get; set; }


    }
}
