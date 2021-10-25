using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HrApi.Models;
using HrApi.Pagination;
using HrApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(HrContext dBContext) : base(dBContext)
        {

        }

        public HrContext HrContext
        {
            get { return Context as HrContext; }
        }
        public async Task<IEnumerable<Company>> GetCompanies(CompanyParameters companyParameters)
        {

            return await HrContext.Companies.
                Where(c => c.Founded >= companyParameters.MinFounded && c.Founded <= companyParameters.MaxFounded).OrderBy(c => c.Name)
                .Skip((companyParameters.PageNumber - 1) * companyParameters.PageSize)
                .Take(companyParameters.PageSize).ToListAsync();


        }
        public async Task<Company> GetCompany(int id)
        {
            return await HrContext.Companies.FindAsync(id);
        }
        public async Task PutCompany(int id, Company company)
        {

            var entry = HrContext.Companies.First(e => e.Id == id);
            HrContext.Entry(entry).CurrentValues.SetValues(company);
            await HrContext.SaveChangesAsync();

        }
        public async Task<Company> PostCompany(Company company)
        {
            await HrContext.Companies.AddAsync(company);
            await HrContext.SaveChangesAsync();
            return company;

        }

        public async Task<bool> DeleteCompany(int id)
        {
            var entry = HrContext.Companies.First(e => e.Id == id);
            if (entry == null) return false;
            HrContext.Companies.Remove(entry);
            await HrContext.SaveChangesAsync();
            return true;

        }

    }
}
