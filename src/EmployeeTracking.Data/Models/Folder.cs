using EmployeeTracking.Base.BaseModel;

namespace EmployeeTracking.Data.Models
{
    public class Folder : BaseEntity
    {
        public string AccessType { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
