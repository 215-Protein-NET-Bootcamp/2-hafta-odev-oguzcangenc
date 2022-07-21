

using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Repositories.Abstarct;
using EmployeeTracking.Data.Repositories.Concrete;
using EmployeeTracking.Service.Abstract;
using EmployeeTracking.Service.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTracking.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSingleton<DapperDbContext>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}