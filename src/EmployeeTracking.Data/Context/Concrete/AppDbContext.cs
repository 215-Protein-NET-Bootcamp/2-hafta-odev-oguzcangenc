using EmployeeTracking.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EmployeeTracking.Data.Context.Concrete
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .Property(b => b.CreatedAt)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Employee>()
                      .Property(b => b.IsDeleted)
                      .HasDefaultValue(false);
            modelBuilder.Entity<Country>()
                       .Property(b => b.CreatedAt)
                       .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Country>()
                     .Property(b => b.IsDeleted)
                     .HasDefaultValue(false);
            modelBuilder.Entity<Department>()
                       .Property(b => b.CreatedAt)
                       .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Department>()
                     .Property(b => b.IsDeleted)
                     .HasDefaultValue(false);
            modelBuilder.Entity<Folder>()
                       .Property(b => b.CreatedAt)
                       .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Folder>()
                     .Property(b => b.IsDeleted)
                     .HasDefaultValue(false);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
