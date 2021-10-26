using HrApi.Models;
using HrApi.Pagination;
using HrApi.Repositories.Interfaces;
using HrApi.Services.Interfaces;
using System;
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
        public void AddCompany(Company company)
        {
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) throw new Exception();
            _companyRepository.PostCompany(company);
           

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
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) throw new Exception();
            _companyRepository.PutCompany(id, company);
            return _companyRepository.GetCompany(id).Result;


        }
        public void DeleteCompany(int id)
        {
            try
            {
                _companyRepository.DeleteCompany(id);
            }
            catch(Exception)
            {
                throw new Exception();
            }

        }

    }
}
