using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HrApi.Models;
using Microsoft.AspNetCore.Authorization;
using HrApi.Services.Interfaces;
using HrApi.DTO;
using AutoMapper;

namespace HrApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly HrContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(HrContext context,IEmployeeService employeeService, IMapper mapper)
        {
            _context = context;
            _employeeService = employeeService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }


        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            var c = _employeeService.PutEmployee(id, employee);
            if (c == null)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpPost]
        public ActionResult<Employee> PostEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            var result = _employeeService.AddEmployee(employee);
            if (!result)
            {
                return BadRequest();
            }
            
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employeeService.DeleteEmployee(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
