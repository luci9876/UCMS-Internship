using HrApi.Models;
using HrApi.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApi.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies(CompanyParameters companyParameters);
        Task<Company> GetCompany(int id);
        Task<Company> PostCompany(Company company);
        Task<bool> DeleteCompany(int id);
        Task PutCompany(int id, Company company);
    }
}
