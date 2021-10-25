using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApi.Models;
using HrApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeRepository>, IEmployeeRepository
    {
        public EmployeeRepository(HrContext dBContext) : base(dBContext)
        {

        }

        public HrContext HrContext
        {
            get { return Context as HrContext; }
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {

            return await HrContext.Employees.ToListAsync(); ;


        }
        public async Task<Employee> GetEmployee(int id)
        {
            return await HrContext.Employees.FindAsync(id);
        }
        public async Task PutEmployee(int id, Employee employee)
        {

            var entry = HrContext.Employees.First(e => e.Id == id);
            HrContext.Entry(entry).CurrentValues.SetValues(employee);
            await HrContext.SaveChangesAsync();

        }
        public async Task<Employee> PostEmployee(Employee employee)
        {
            await HrContext.Employees.AddAsync(employee);
            await HrContext.SaveChangesAsync();
            return employee;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var entry = HrContext.Employees.First(e => e.Id == id);
            if (entry == null) return false ;
            HrContext.Employees.Remove(entry);
            await HrContext.SaveChangesAsync();
            return true;
        }

    }
}
