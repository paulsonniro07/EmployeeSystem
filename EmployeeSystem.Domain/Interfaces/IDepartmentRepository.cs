using EmployeeSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllDepartmentsByAsync();
        Task AddDepartment(Department department);
    }
}
