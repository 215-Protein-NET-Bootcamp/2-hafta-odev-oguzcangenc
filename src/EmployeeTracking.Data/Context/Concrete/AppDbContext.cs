using EmployeeTracking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeTracking.Data.Context.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
