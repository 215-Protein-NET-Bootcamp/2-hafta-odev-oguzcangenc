using AutoMapper;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories;
using EmployeeTracking.Data.Repositories.Abstarct;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Service.Concrete
{
    public class CountryService : BaseService<CountryDto, Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(countryRepository, mapper, unitOfWork)
        {
        }
    }


}
