using EmployeeTracking.Base.Response;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private IValidator<CountryDto> _validator;

        public CountryController(ICountryService countryService, IValidator<CountryDto> validator)
        {
            _validator = validator;
            _countryService = countryService;
        }
        // GET: api/<CountryController>
        [HttpGet]
        public async Task<BaseResponse<IEnumerable<CountryDto>>> Get()
        {
            return await _countryService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse<CountryDto>> Get(int id)
        {
            return await _countryService.GetByIdAsync(id);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<BaseResponse<CountryDto>> Post([FromBody] CountryDto countryDto)
        {
            return await _countryService.InsertAsync(countryDto);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<BaseResponse<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
        {
            return await _countryService.UpdateAsync(id, countryDto);
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<CountryDto>> Delete(int id)
        {
            return await _countryService.RemoveAsync(id);
        }
    }
}
