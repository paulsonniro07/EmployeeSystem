using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Infrastructure.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Include(x=>x.Department).ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null) return false;

            _context.Employees.Update(employee);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmployeeExistsAsync(employee.DepartmentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteEmployeeAsync(Employee employee)
        {
            if (employee == null) return false;

            _context.Employees.Remove(employee);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmployeeExistsAsync(employee.DepartmentId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task<bool> EmployeeExistsAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeId == employeeId);
        }

    }
}
