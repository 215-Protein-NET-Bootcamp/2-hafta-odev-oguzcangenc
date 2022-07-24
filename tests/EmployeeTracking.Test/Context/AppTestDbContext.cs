using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EmployeeTracking.Test.Context
{
    public class AppTestDbContext : AppDbContext
    {
        public AppTestDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            seedData<Employee>(modelBuilder, "../../../TestData/employees.json");
            seedData<Folder>(modelBuilder, "../../../TestData/folders.json");
            seedData<Country>(modelBuilder, "../../../TestData/countries.json");
            seedData<Department>(modelBuilder, "../../../TestData/departments.json");

        }
        private void seedData<T>(ModelBuilder modelBuilder, string file) where T : class
        {
            using (StreamReader reader = new StreamReader(file))
            {
                var json = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<T[]>(json);
                modelBuilder.Entity<T>().HasData(data);
            }

        }
    }
}
