using HrApi.Models;
using HrApi.Repositories.Interfaces;
using HrApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task AddEmployee(Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FirstName)) throw new Exception();
            await _employeeRepository.PostEmployee(employee);
          

        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);

        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }
        public async  Task<Employee> PutEmployee(int id, Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FirstName)) throw new Exception();
            await _employeeRepository.PutEmployee(id, employee);
            return _employeeRepository.GetEmployee(id).Result;


        }
        public async Task DeleteEmployee(int id)
        {
            try
            {
                await _employeeRepository.DeleteEmployee(id);
            }
            catch(Exception)
            {
                throw new Exception();
            }

        }
    }
}
