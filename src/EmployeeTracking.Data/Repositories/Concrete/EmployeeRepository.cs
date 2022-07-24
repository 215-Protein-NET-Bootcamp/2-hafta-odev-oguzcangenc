using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetByIdEmployeeDetailAsync(int entityId)
        {
            var response = await _context.Employees.Where(e => e.Id == entityId)
                                                  .Include(employee => employee.Folders)
                                                  .Include(employee => employee.Department)
                                                  .ThenInclude(employee => employee.Country)
                                                  .FirstOrDefaultAsync();
            return response;
        }
    }

}
