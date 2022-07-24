using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _departmentService.GetAllAsync();

            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _departmentService.GetByIdAsync(id);
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentDto departmentDto)
        {
            var response = await _departmentService.InsertAsync(departmentDto);

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentDto departmentDto)
        {
            var response = await _departmentService.UpdateAsync(id, departmentDto);
            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _departmentService.RemoveAsync(id);
            if (!response.Success)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
