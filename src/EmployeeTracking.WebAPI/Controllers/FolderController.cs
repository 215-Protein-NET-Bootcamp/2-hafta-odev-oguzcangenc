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
        // GET: api/<FolderController>
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<FolderDto>>> Get()
        {
            return await _folderService.GetAllAsync();
        }

        // GET api/<FolderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FolderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FolderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FolderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
