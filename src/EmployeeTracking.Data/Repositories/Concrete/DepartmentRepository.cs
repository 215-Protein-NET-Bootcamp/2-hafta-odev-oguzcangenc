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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
