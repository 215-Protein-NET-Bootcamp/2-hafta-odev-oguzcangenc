using EmployeeTracking.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Dto.Concrete
{
    public class EmployeeDetailDto:BaseDto
    {
        public int Name { get; set; }
        public DepartmentDto Department { get; set; }
        public ICollection<CountryDto> Countries { get; set; }
        public ICollection<FolderDto> Folders { get; set; }
    }
}
