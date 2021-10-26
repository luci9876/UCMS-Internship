using HrApi.Models;
using HrApi.Repositories.Interfaces;
using HrApi.Services.Interfaces;
using System;
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
        public void AddEmployee(Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.FirstName)) throw new Exception();
            _employeeRepository.PostEmployee(employee);
          

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
            if (employee == null || string.IsNullOrWhiteSpace(employee.FirstName)) throw new Exception();
            _employeeRepository.PutEmployee(id, employee);
            return _employeeRepository.GetEmployee(id).Result;


        }
        public void DeleteEmployee(int id)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
            }
            catch(Exception)
            {
                throw new Exception();
            }

        }
    }
}
