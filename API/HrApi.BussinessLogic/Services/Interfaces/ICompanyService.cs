using HrApi.Data.Models;
using HrApi.Models;
using HrApi.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HrApi.Services.Interfaces
{
    public interface ICompanyService
    {
        Task AddCompany(Company company);
        Task<Company> GetCompany(int id);
        Task <Company> PutCompany(int id, Company company);
        Task<PagedList<Entity>> GetCompanies(CompanyParameters companyParameters);
        Task DeleteCompany(int id);
        Task<IEnumerable<Employee>> GetEmployeesByCompany(int id);
        Task<CompanyEmployee> PostCompanyEmployee(Company company, Employee employee);
    }
}
