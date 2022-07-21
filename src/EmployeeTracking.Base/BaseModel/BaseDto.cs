using System.ComponentModel.DataAnnotations;

namespace EmployeeTracking.Base.BaseModel
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
