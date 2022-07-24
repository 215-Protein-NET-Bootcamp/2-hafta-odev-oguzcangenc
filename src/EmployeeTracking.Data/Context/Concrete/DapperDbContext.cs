using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace EmployeeTracking.Data.Context.Concrete
{
    public class DapperDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection(IWebHostBuilder webHostBuilder)
        {
            if (webHostBuilder.GetSetting("Environment") == "Testing")
            {
                return new NpgsqlConnection(connectionString);
            }
            else
            {
                return new NpgsqlConnection(connectionString);
            }
        }
    }
}
