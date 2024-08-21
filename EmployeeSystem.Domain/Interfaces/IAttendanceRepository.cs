using EmployeeSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task AddAttendanceAsync(Attendance attendance);
        Task<bool> UpdateAttendanceAsync(Attendance attendance);
        Task<bool> DeleteAttendanceAsync(Attendance attendance);
    }
}
