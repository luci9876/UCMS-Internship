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
using AutoMapper;
using HrApi.DTO;
using HrApi.Sorting.Interfaces;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        
        private readonly ISortingCompanies _sorting;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ISortingCompanies sorting,ICompanyService companyService, IMapper mapper)
        {
           
            _sorting = sorting;
            _companyService = companyService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies([FromQuery] CompanyParameters companyParameters)
        {
            if (!companyParameters.ValidYearRange)
            {
                return BadRequest($"Founding Year can't be bigger than {DateTime.Now.Year} ");
            }
           
            var companies = await _companyService.GetCompanies(companyParameters);
            var metadata = new
            {
                companies.TotalCount,
                companies.PageSize,
                companies.CurrentPage,
                companies.TotalPages,
                companies.HasNext,
                companies.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(companies);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var company=await _companyService.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            var companyDTO = _mapper.Map<CompanyDTO>(company);
            return Ok(companyDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, CompanyDTO companyDTO)
        {
            var company = _mapper.Map<Company>(companyDTO);

            try
            {
               await _companyService.PutCompany(id, company);
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyDTO companyDTO)
        {
            var company= _mapper.Map<Company>(companyDTO);
            try
            {
               await _companyService.AddCompany(company);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
           
            
            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                await _companyService.DeleteCompany(id);
            }
            catch (Exception) 
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("employees-by-company/{id}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetCompanyEmployee(int id)
        {
            try
            {
                var results =await  _companyService.GetEmployeesByCompany(id);
                return Ok(results);
            }
            catch (Exception) 
            {
                return BadRequest();
            }
            
        }
        [HttpPost("employees-at-company")]
        public async Task<ActionResult<Company>> PostCompany(CompanyEmployeeDTO companyEmployeeDTO)
        {
            
            try
            {
               await _companyService.PostCompanyEmployee(companyEmployeeDTO.Company,companyEmployeeDTO.Employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }


            return CreatedAtAction("Company&Employee", new { companyId = companyEmployeeDTO.Company.Id , employeeId = companyEmployeeDTO.Employee.Id} );
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
    }
}
