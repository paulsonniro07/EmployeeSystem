using EmployeeSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EmployeeSystem.Infrastructure.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateDepartmentAsync(Department? department)
        {
            if (department == null) return false;

            _context.Departments.Update(department);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentExistsAsync(department.DepartmentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteDepartmentAsync(Department? department)
        {
            if (department == null) return false;

            _context.Departments.Remove(department);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DepartmentExistsAsync(department.DepartmentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await _context.Departments.AnyAsync(e => e.DepartmentId == departmentId);
        }

    }
}
