using System;
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
            return await HrContext.Employees.Where(x => x.Id == id).Include(x => x.Image).FirstOrDefaultAsync();
        }
        public async Task PutEmployee(int id, Employee employee)
        {

            var entry = HrContext.Employees.FirstAsync(e => e.Id == id);
            if (entry == null) throw new Exception();
            entry.Result.FirstName = employee.FirstName;
            entry.Result.LastName = employee.LastName;
            if (employee.Image != null && employee.Image.Id != 0) { entry.Result.Image = employee.Image; }
            await HrContext.SaveChangesAsync();

        }
        public async Task<Employee> PostEmployee(Employee employee)
        {
            await HrContext.Employees.AddAsync(employee);
            await HrContext.SaveChangesAsync();
            return employee;

        }

        public async Task DeleteEmployee(int id)
        {
            var entry = HrContext.Employees.FirstAsync(e => e.Id == id);
            if (entry == null) throw new Exception();
            HrContext.Employees.Remove(entry.Result);
            await HrContext.SaveChangesAsync();
        }

    }
}
