using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            return await _departmentRepository.UpdateDepartmentAsync(department);
        }

        public async Task<bool> DeleteDepartmentAsync(Department department)
        {
            return await _departmentRepository.DeleteDepartmentAsync(department);
        }

    }
}
