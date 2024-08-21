using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Entities
{
    public enum AttendanceStatus
    {
        Present = 1,
        Absent = 2,
        Leave = 3
    }
    public class EmployeeAttendance
    {
        public int EmployeeAttendanceId { get; set; }
        public int AttendanceId { get; set; }
        public int EmployeeId {  get; set; }
        public Employee Employee {  get; set; }

        public AttendanceStatus AttendanceStatus { get; set; } = AttendanceStatus.Present;

        public string? AttendanceNotes { get; set; }

    }
}
