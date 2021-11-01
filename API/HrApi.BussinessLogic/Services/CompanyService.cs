using HrApi.Data.Models;
using HrApi.Models;
using HrApi.Pagination;
using HrApi.Repositories.Interfaces;
using HrApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddCompany(Company company)
        {
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) throw new Exception();
            await _companyRepository.PostCompany(company);
           

        }
        public async Task< Company> GetCompany(int id)
        {  
            return  await _companyRepository.GetCompany(id);

        }
        public async Task<PagedList<Entity>> GetCompanies(CompanyParameters companyParameters)
        {
            return await _companyRepository.GetCompanies(companyParameters);
        }
        public async Task<Company> PutCompany(int id, Company company)
        {
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) throw new Exception();
            await _companyRepository.PutCompany(id, company);
            return await _companyRepository.GetCompany(id);


        }
        public async Task DeleteCompany(int id)
        {
            try
            {
                await _companyRepository.DeleteCompany(id);
            }
            catch(Exception)
            {
                throw new Exception();
            }

        }
        public async Task< IEnumerable<Employee>> GetEmployeesByCompany(int id) 
        {
            
            try
            {
                var employees= await  _companyRepository.GetEmployeesByCompany(id);
                return employees;
            }
            catch (Exception)
            {
                throw new Exception();
            }
           
        }
        public async Task<CompanyEmployee> PostCompanyEmployee(Company company, Employee employee) 
        {
            try
            {
                var result=await _companyRepository.PostCompanyEmployee(company,employee);
                return result;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

    }
}
