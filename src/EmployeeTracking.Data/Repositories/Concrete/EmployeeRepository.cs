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
                                                  .ThenInclude(department => department.Countries.Where(countries => countries.IsDeleted == false)).Select(e => new Employee
                                                  {
                                                      Name = e.Name,
                                                      Available = e.Available,
                                                      CreatedAt = e.CreatedAt,
                                                      Department = e.Department.IsDeleted==false ? e.Department:null,
                                                      DepartmentId = e.DepartmentId,
                                                      Folders = e.Folders.Where(f=>f.IsDeleted ==false).ToList(),
                                                      Id = e.Id,
                                                      IsDeleted = e.IsDeleted
                                                  }).FirstOrDefaultAsync();
            return response;
        }
    }

}
