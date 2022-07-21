using EmployeeTracking.Base.Response;
using EmployeeTracking.Service.Abstract;
using EmployeeTrancking.Dto;
using Microsoft.AspNetCore.Mvc;

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
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<EmployeeDto>>> Get()
        {
            return await _employeeService.GetAllAsync();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<BaseResponse<EmployeeDto>> Post([FromBody] EmployeeDto dto)
        {
           return await _employeeService.InsertAsync(dto);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
