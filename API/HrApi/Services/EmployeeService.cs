using HrApi.Models;
using HrApi.Repositories.Interfaces;
using HrApi.Services.Interfaces;
using System.Collections.Generic;


namespace HrApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool AddEmployee(Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FirstName)) return false;
            _employeeRepository.PostEmployee(employee);
            return true;

        }
        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id).Result;

        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees().Result;
        }
        public Employee PutEmployee(int id, Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FirstName)) return null;
            _employeeRepository.PutEmployee(id, employee);
            return _employeeRepository.GetEmployee(id).Result;


        }
        public bool DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id).Result;

        }
    }
}
