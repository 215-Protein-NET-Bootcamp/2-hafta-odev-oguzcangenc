using EmployeeTracking.Base.BaseModel;
using EmployeeTracking.Dto.Concrete;

namespace EmployeeTrancking.Dto
{
    public class EmployeeDto:BaseDto
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}
