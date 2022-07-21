using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
