using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrApi.Models;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Company_EmployeeController : ControllerBase
    {
        private readonly HrContext _context;

        public Company_EmployeeController(HrContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company_Employee>>> GetCompany_Employee()
        {
            return await _context.Company_Employee.Include(x=>x.Companies).Include(x=>x.Employees).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company_Employee>> GetCompany_Employee(int id)
        {
            var company_Employee = await _context.Company_Employee.Include(x => x.Companies).Include(x => x.Employees).FirstOrDefaultAsync(c => c.id == id);

            if (company_Employee == null)
            {
                return NotFound();
            }

            return Ok(company_Employee);
        }

        [HttpGet("company/{id}")]
        public async Task<ActionResult<Company_Employee>> GetCompany_Employee_ByCompany(int id)
        {
            var company_Employee = await _context.Company_Employee.Include(x => x.Employees).FirstOrDefaultAsync(c => c.Company_id == id);

            if (company_Employee == null)
            {
                return NotFound();
            }

            return Ok(company_Employee);
        }

        [HttpGet("employee/{id}")]
        public async Task<ActionResult<Company_Employee>> GetCompany_Employee_ByEmployee(int id)
        {
            var company_Employee = await _context.Company_Employee.Include(x => x.Companies).FirstOrDefaultAsync(c => c.Employee_id == id);

            if (company_Employee == null)
            {
                return NotFound();
            }

            return Ok(company_Employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany_Employee(int id, Company_Employee company_Employee)
        {
            if (id != company_Employee.id)
            {
                return BadRequest("Parameter id doesn't match with current id ");
            }

            _context.Entry(company_Employee).State = EntityState.Modified;

          //  try
            //{
                await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
                if (!Company_EmployeeExists(id))
                {
                    return NotFound();
                }
              //  else
                //{
              //      throw;
                //}
            //}

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<Company_Employee>> PostCompany_Employee(Company_Employee company_Employee)
        {
            await _context.Company_Employee.AddAsync(company_Employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany_Employee", new { id = company_Employee.id }, company_Employee);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany_Employee(int id)
        {
            var company_Employee = await _context.Company_Employee.FindAsync(id);
            if (company_Employee == null)
            {
                return NotFound();
            }

            _context.Company_Employee.Remove(company_Employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Company_EmployeeExists(int id)
        {
            return _context.Company_Employee.Any(e => e.id == id);
        }
    }
}
