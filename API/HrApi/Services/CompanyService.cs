using HrApi.Models;
using HrApi.Pagination;
using HrApi.Repositories.Interfaces;
using HrApi.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public bool AddCompany(Company company)
        {
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) return false;
            _companyRepository.PostCompany(company);
            return true;

        }
        public Company GetCompany(int id)
        {  
            return  _companyRepository.GetCompany(id).Result;

        }
        public IEnumerable<Company> GetCompanies(CompanyParameters companyParameters)
        {
            return _companyRepository.GetCompanies(companyParameters).Result;
        }
        public Company PutCompany(int id, Company company)
        {
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) return null;
            _companyRepository.PutCompany(id, company);
            return _companyRepository.GetCompany(id).Result;


        }
        public bool DeleteCompany(int id)
        {
            return _companyRepository.DeleteCompany(id).Result;

        }

    }
}
