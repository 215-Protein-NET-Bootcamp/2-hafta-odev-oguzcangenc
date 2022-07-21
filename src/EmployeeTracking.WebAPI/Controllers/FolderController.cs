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
        public async Task<BaseResponse<IEnumerable<FolderDto>>> Get()
        {
            return await _folderService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<FolderDto>> Get(int id)
        {
            return await _folderService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<BaseResponse<FolderDto>> Post([FromBody] FolderDto folderDto)
        {
            return await _folderService.InsertAsync(folderDto);
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<FolderDto>> Put(int id, [FromBody] FolderDto folderDto)
        {
            return await _folderService.UpdateAsync(id, folderDto);
        }

      
        [HttpDelete("{id}")]
        public async Task<BaseResponse<FolderDto>> Delete(int id)
        {
            return await _folderService.RemoveAsync(id);
        }
    }
}
