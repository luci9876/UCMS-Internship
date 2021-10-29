using HrApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployee(int id);
        Task<Employee> PutEmployee(int id, Employee company);
        Task<IEnumerable<Employee>> GetEmployees();
        Task DeleteEmployee(int id);
    }
}
