using EmployeeTracking.Base.Response;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _folderService.GetAllAsync();

            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _folderService.GetByIdAsync(id);

            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FolderDto folderDto)
        {
            var response = await _folderService.InsertAsync(folderDto);

            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FolderDto folderDto)
        {
            var response = await _folderService.UpdateAsync(id, folderDto);

            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _folderService.RemoveAsync(id);

            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
