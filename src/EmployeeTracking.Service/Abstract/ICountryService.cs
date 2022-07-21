using EmployeeTracking.Data.Models;
using EmployeeTracking.Dto.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Service.Abstract
{
    public interface ICountryService:IBaseService<CountryDto,Country>
    {
    }
}
