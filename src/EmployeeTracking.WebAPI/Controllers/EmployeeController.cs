using EmployeeTracking.Base.Response;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Service.Abstract;
using EmployeeTrancking.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _employeeService.GetAllAsync();
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var res = await _employeeService.GetEmployeeDetail(id);
            if (!res.Success)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto dto)
        {

            var response = await _employeeService.InsertAsync(dto);

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDto employeeDto)
        {
            var response = await _employeeService.UpdateAsync(id, employeeDto);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _employeeService.RemoveAsync(id);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
