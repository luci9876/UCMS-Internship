using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using HrApi.Data.Models.Helpers.Interfaces;
using HrApi.Data.Models.Interfaces;
using HrApi.Models;
using HrApi.Pagination;
using HrApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using HrApi.Data.Models;

namespace HrApi.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private ISortHelper<Company> _sortHelper;
        private IDataShaper<Company> _dataShaper;
        public CompanyRepository(HrContext dBContext, ISortHelper<Company> sortHelper, IDataShaper<Company> dataShaper) : base(dBContext)
        {
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }

        public HrContext HrContext
        {
            get { return Context; }
        }
        public async Task<PagedList<Entity>> GetCompanies(CompanyParameters companyParameters)
        {

            var companies= (await HrContext.Companies.
                Where(c => c.Founded >= companyParameters.MinFounded && c.Founded <= companyParameters.MaxFounded).OrderBy(c => c.Name)
                .Skip((companyParameters.PageNumber - 1) * companyParameters.PageSize)
                .Take(companyParameters.PageSize).ToListAsync()).AsQueryable();
            
            SearchByName(ref companies, companyParameters.Name);

            var sortedCompanies = _sortHelper.ApplySort(companies, companyParameters.OrderBy);
            var shapedCompanies = _dataShaper.ShapeData(sortedCompanies, companyParameters.Fields);

            return PagedList<Entity>.ToPagedList(shapedCompanies,companyParameters.PageNumber,companyParameters.PageSize);
        }
        public async Task<Entity> GetCompanyById(Guid companyId, string fields)
        {
            var company = await HrContext.Companies.Where(c => c.Id.Equals(companyId)).DefaultIfEmpty(new Company()).FirstOrDefaultAsync();

            return _dataShaper.ShapeData(company, fields);
        }
        private void SearchByName(ref IQueryable<Company> company, string companyName)
        {
            if (!company.Any() || string.IsNullOrWhiteSpace(companyName))
                return;

            if (string.IsNullOrEmpty(companyName))
                return;

            company = company.Where(o => o.Name.ToLowerInvariant().Contains(companyName.Trim().ToLowerInvariant()));
        }
        public async Task<Company> GetCompany(int id)
        {
            return await HrContext.Companies.FindAsync(id);
        }
        public async Task PutCompany(int id, Company company)
        {

            var entry = HrContext.Companies.FirstAsync(e => e.Id == id);
            if (entry == null) throw new Exception();
            entry.Result.Name = company.Name;
            entry.Result.Description = company.Description;
            if (company.Image!=null && company.Image.Id != 0) { entry.Result.Image = company.Image; }
            await HrContext.SaveChangesAsync();

        }
        public async Task<Company> PostCompany(Company company)
        {
            await HrContext.Companies.AddAsync(company);
            await HrContext.SaveChangesAsync();
            return company;

        }

        public async Task DeleteCompany(int id)
        {
            var entry = HrContext.Companies.FirstAsync(e => e.Id == id);
            if (entry == null) throw new Exception();
            HrContext.Companies.Remove(entry.Result);
            await HrContext.SaveChangesAsync();


        }
        public async Task<IEnumerable<Employee>> GetEmployeesByCompany(int id)
        {
            var results =await  HrContext.CompanyEmployee.Where(x => x.Company.Id == id).ToListAsync();
            var employees = new List<Employee>();
            foreach (var result in results) 
            {
                employees.Add(result.Employee);
            }
            return  employees;


        }
        public async Task<CompanyEmployee> PostCompanyEmployee(Company company,Employee employee)
        {
            var companyEmployee = new CompanyEmployee
            {
                Employee = employee,
                Company = company
            };
            await HrContext.CompanyEmployee.AddAsync(companyEmployee);
            await HrContext.SaveChangesAsync();
            return companyEmployee;
            

        }

    }
}
