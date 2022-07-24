using EmployeeTracking.Base.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }
        public ICollection<Department>  Departments { get; set; }

    }
}
