using EmployeeTracking.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Dto.Concrete
{
    public class CountryDto:BaseDto
    {
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }
        public int DepartmentId { get; set; }
    }
}
