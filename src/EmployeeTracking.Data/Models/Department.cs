using EmployeeTracking.Base.BaseModel;

namespace EmployeeTracking.Data.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
