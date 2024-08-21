using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Services
{
    public class AttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceByIdAsync(id);
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task<bool> UpdateAttendanceAsync(Attendance attendance)
        {
            return await _attendanceRepository.UpdateAttendanceAsync(attendance);
        }

        public async Task<bool> DeleteAttendanceAsync(Attendance attendance)
        {
            return await _attendanceRepository.DeleteAttendanceAsync(attendance);
        }
    }
}
