using EmployeeTracking.Base.BaseModel;

namespace EmployeeTracking.Data.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Country> Countries { get; set; }

    }
}
