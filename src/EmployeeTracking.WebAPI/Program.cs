using AutoMapper;
using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Repositories;
using EmployeeTracking.Data.Repositories.Abstarct;
using EmployeeTracking.Data.Repositories.Concrete;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using EmployeeTracking.Service.Concrete;
using EmployeeTracking.Service.MapperProfile;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;

namespace EmployeeTracking.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog((ctx, lc) => lc
                        .WriteTo.Console()
                        .WriteTo.File(@"logs\log.txt", rollingInterval: RollingInterval.Day));
            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            builder.Services.AddSingleton(mapperConfig.CreateMapper());

            builder.Services.AddControllers()
                .AddJsonOptions(x =>
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles).
          AddFluentValidation(c =>
                c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));




            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Dapper
            builder.Services.AddSingleton<DapperDbContext>();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            builder.Services.AddScoped<IFolderRepository, FolderRepository>();
            builder.Services.AddScoped<IFolderService, FolderService>();

            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddScoped<ICountryService, CountryService>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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