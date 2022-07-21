using EmployeeTracking.Base.Response;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<DepartmentDto>>> Get()
        {
            return await _departmentService.GetAllAsync();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<DepartmentDto>> Get(int id)
        {
           return await _departmentService.GetByIdAsync(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<BaseResponse<DepartmentDto>> Post([FromBody] DepartmentDto departmentDto)
        {
            return await _departmentService.InsertAsync(departmentDto);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<DepartmentDto>> Put(int id, [FromBody] DepartmentDto departmentDto)
        {
            var response = await _departmentService.UpdateAsync(id, departmentDto);
            return response;
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<DepartmentDto>> Delete(int id)
        {
          return  await _departmentService.RemoveAsync(id);
        }
    }
}
