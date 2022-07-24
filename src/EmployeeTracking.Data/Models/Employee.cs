using EmployeeTracking.Base.BaseModel;

namespace EmployeeTracking.Data.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<Folder> Folders { get; set; }
    }
}
