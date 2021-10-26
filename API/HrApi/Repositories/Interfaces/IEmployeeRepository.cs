using HrApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> PostEmployee(Employee employee);
        Task DeleteEmployee(int id);
        Task PutEmployee(int id, Employee employee);
    }
}
