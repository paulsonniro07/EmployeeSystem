using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infrastructure.Data
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances.Include(e => e.EmployeeAttendances).ThenInclude(ea => ea.Employee).FirstOrDefaultAsync(e => e.AttendanceId == id);
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances.ToListAsync();        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance)
        {
            _context.EmployeeAttendances.Add(employeeAttendance);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAttendanceAsync(Attendance attendance)
        {
            if (attendance == null) return false;

            _context.Attendances.Update(attendance);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AttendanceExistsAsync(attendance.AttendanceId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteAttendanceAsync(Attendance attendance)
        {
            if (attendance == null) return false;

            _context.Attendances.Remove(attendance);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AttendanceExistsAsync(attendance.AttendanceId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<bool> AttendanceExistsAsync(int attendanceId)
        {
            return await _context.Attendances.AnyAsync(e => e.AttendanceId == attendanceId);
        }

    }
}
