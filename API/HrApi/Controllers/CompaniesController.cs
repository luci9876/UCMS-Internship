using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrApi.Models;
using Microsoft.AspNetCore.Authorization;
using HrApi.Pagination;
using Newtonsoft.Json;
using System.Diagnostics;
using HrApi.Sorting;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly HrContext _context;
        private readonly SortingCompanies _sorting;

        public CompaniesController(HrContext context)
        {
            _context = context;
            _sorting = new SortingCompanies();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            if (!companyParameters.ValidYearRange)
            {
                return BadRequest($"Founding Year can't be bigger than {DateTime.Now.Year} ");
            }

            var companies = _context.Companies.Where(c => c.Founded >= companyParameters.MinFounded && c.Founded <= companyParameters.MaxFounded).OrderBy(c => c.Name)
                 .Skip((companyParameters.PageNumber - 1) * companyParameters.PageSize)
                 .Take(companyParameters.PageSize);

            _sorting.SearchByName(ref companies, companyParameters.Name);
            _sorting.ApplySort(ref companies, companyParameters.OrderBy);
            var companiesPagination = PagedList<Company>.ToPagedList(companies, companyParameters.PageNumber, companyParameters.PageSize);
            var metadata = new
            {
                companiesPagination.TotalCount,
                companiesPagination.PageSize,
                companiesPagination.CurrentPage,
                companiesPagination.TotalPages,
                companiesPagination.HasNext,
                companiesPagination.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(companiesPagination);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest("Id's are not matching!");
            }
            //try
            //{
            if (!CompanyExists(id))
            {
                return NotFound();
            }
            var entry = _context.Companies.First(e => e.Id == company.Id);
            _context.Entry(entry).CurrentValues.SetValues(company);
            await _context.SaveChangesAsync();

            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //  throw;
            //}

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            if (company == null || string.IsNullOrWhiteSpace(company.Name)) return BadRequest("Invalid object!");
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("division-by-zero")]
        public async Task<IActionResult> DivisionByzero()
        {

            throw new DivideByZeroException();
        }
        [Authorize]
        [HttpGet("unauth")]
        public async Task<IActionResult> Unauth()
        {
            return NoContent();

        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
