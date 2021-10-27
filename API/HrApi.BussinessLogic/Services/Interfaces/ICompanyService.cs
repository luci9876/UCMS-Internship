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
        void AddCompany(Company company);
        Company GetCompany(int id);
        Company PutCompany(int id, Company company);
        PagedList<Entity> GetCompanies(CompanyParameters companyParameters);
        void DeleteCompany(int id);
        IEnumerable<Employee> GetEmployeesByCompany(int id);
        CompanyEmployee PostCompanyEmployee(Company company, Employee employee);
    }
}
