using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Context.Concrete
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EmployeeTracking.WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");
            DbContextOptionsBuilder<AppDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection"));
            return new AppDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
