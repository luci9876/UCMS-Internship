using HrApi.Data.Models;
using HrApi.Models;
using HrApi.Pagination;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApi.Repositories.Interfaces
{
   public interface ICompanyRepository
    {
        Task<PagedList<Entity>> GetCompanies(CompanyParameters companyParameters);
        Task<Entity> GetCompanyById(Guid ownerId, string fields);
        Task<Company> GetCompany(int id);
        Task<Company> PostCompany(Company company);
        Task DeleteCompany(int id);
        Task PutCompany(int id, Company company);
        Task<IEnumerable<Employee>> GetEmployeesByCompany(int id);
        Task<CompanyEmployee> PostCompanyEmployee(Company company, Employee employee);
    }
}
