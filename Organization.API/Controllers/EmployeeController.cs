using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Organization.Core.DTOs;
using Organization.Core.Entity;
using Organization.Core.Service;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Organization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var list = await _employeeService.GetAsync();
            return Ok(list);
        }
        // GET: api/<ValuesController>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _employeeService.GetAsync(id);
            return Ok(employee);
        }
        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee value)
        {
            var employee = _mapper.Map<Employee>(value);
            await _employeeService.PostAsync(employee);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employee value)
        {
            ActionResult<Employee> existEmployee = await _employeeService.GetAsync(id);

            if (existEmployee.Value is null)
            {
                return NotFound();
            }

            return Ok(existEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _employeeService.DeleteAsync(id);
        }
    }
}
