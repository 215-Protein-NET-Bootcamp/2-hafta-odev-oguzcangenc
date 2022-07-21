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
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<EmployeeDto>>> Get()
        {
            return await _employeeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<EmployeeDto>> Get(int id)
        {
            return await _employeeService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<BaseResponse<EmployeeDto>> Post([FromBody] EmployeeDto dto)
        {
            return await _employeeService.InsertAsync(dto);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<EmployeeDto>> Put(int id, [FromBody] EmployeeDto employeeDto)
        {
            return await _employeeService.UpdateAsync(id, employeeDto);
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<EmployeeDto>> Delete(int id)
        {
            return await _employeeService.RemoveAsync(id);
        }
    }
}
