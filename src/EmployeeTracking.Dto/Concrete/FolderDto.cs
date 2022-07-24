using EmployeeTracking.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Dto.Concrete
{
    public class FolderDto:BaseDto
    {
        public string AccessType { get; set; }
        public int EmployeeId { get; set; }
    }
}
