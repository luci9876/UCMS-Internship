using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrApi.Models;
using Microsoft.AspNetCore.Authorization;
using HrApi.Pagination;
using Newtonsoft.Json;
using HrApi.Sorting;
using HrApi.Services.Interfaces;
using HrApi.Services;
using AutoMapper;
using HrApi.DTO;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly HrContext _context;
        private readonly SortingCompanies _sorting;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(HrContext context, ICompanyService companyService, IMapper mapper)
        {
            _context = context;
            _sorting = new SortingCompanies();
            _companyService = companyService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            if (!companyParameters.ValidYearRange)
            {
                return BadRequest($"Founding Year can't be bigger than {DateTime.Now.Year} ");
            }
            _companyService.GetCompanies(companyParameters);
            var companies = _companyService.GetCompanies(companyParameters).AsQueryable();

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

        public ActionResult<CompanyDTO> GetCompany(int id)
        {
            var company= _companyService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDTO);
        }


        [HttpPut("{id}")]
        public IActionResult PutCompany(int id, CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);
            var c = _companyService.PutCompany(id,company);
            if (c == null)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpPost]
        public ActionResult<Company> PostCompany(CompanyDTO companyDTO)
        {
            var company= _mapper.Map<Company>(companyDTO);
            var result=_companyService.AddCompany(company);
           
            if (!result)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var result =  _companyService.DeleteCompany(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("division-by-zero")]
        public IActionResult DivisionByzero()
        {

            throw new DivideByZeroException();
        }
        [Authorize]
        [HttpGet("unauth")]
        public IActionResult Unauth()
        {
            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
