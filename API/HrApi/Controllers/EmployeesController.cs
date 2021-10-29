using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HrApi.Models;
using Microsoft.AspNetCore.Authorization;
using HrApi.Services.Interfaces;
using HrApi.DTO;
using AutoMapper;
using System.Threading.Tasks;
using System;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
       
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IMail _mail;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper, IMail mail)
        {
           
            _employeeService = employeeService;
            _mapper = mapper;
            _mail = mail;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployee(id);
            
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }


        [HttpPut("{id}")]
        public async  Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            try
            {
               await  _employeeService.PutEmployee(id, employee);
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            try
            {
                await _employeeService.AddEmployee(employee);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            await _mail.SendWelcomeMail(employee.Email);
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            try {
                await _employeeService.DeleteEmployee(id);
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

       
    }
}
