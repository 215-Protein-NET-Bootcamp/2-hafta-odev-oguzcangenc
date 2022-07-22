using EmployeeTracking.Data.Models;
using EmployeeTracking.Dto.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories.Abstarct
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<Employee> GetByIdEmployeeDetailAsync(int entityId);

    }
}
