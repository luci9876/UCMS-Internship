﻿using System.Collections.Generic;
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

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
           
            _employeeService = employeeService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
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
        public async  Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);

            try
            {
                _employeeService.PutEmployee(id, employee);
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
                _employeeService.AddEmployee(employee);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEmployee(int id)
        {

            try {
                _employeeService.DeleteEmployee(id);
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

       
    }
}
