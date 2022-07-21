using System.ComponentModel.DataAnnotations;

namespace EmployeeTracking.Base.BaseModel
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }


        [MaxLength(500)]
        [Display(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        public bool Available { get; set; }
    }
}
