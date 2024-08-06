using EmployeeSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(Employee employee);

    }
}
