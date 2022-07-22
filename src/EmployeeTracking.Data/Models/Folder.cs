using EmployeeTracking.Base.BaseModel;

namespace EmployeeTracking.Data.Models
{
    public class Folder : BaseEntity
    {
        public string AccessType { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
