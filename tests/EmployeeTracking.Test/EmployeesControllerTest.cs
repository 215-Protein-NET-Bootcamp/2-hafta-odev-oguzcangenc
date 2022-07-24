using EmployeeTracking.Data.Models;
using EmployeeTracking.Test.Context;
using EmployeeTracking.WebAPI;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;

namespace EmployeeTracking.Test
{
    public class EmployeesControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> factory;

        public EmployeesControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_All_Employees()
        {
            var client = factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/employee");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_By_Id_Employee()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("/api/employee/2");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Post_New_Employee()
        {
            Employee newEmployee = new()
            {

                Name = "Test User",
                CreatedAt = DateTime.UtcNow,
                DepartmentId = 1,
                IsDeleted = false,

            };

            var client = factory.CreateClient();
            var json = JsonSerializer.Serialize(newEmployee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("/api/employee", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Put_New_Employee()
        {
            Employee putEmployee = new()
            {
                Id = 1,
                Name = $"Test User Update",
                CreatedAt = DateTime.UtcNow,
                DepartmentId = 1,
                IsDeleted = false
            };

            var client = factory.CreateClient();
            var json = JsonSerializer.Serialize(putEmployee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync($"/api/employee/{putEmployee.Id}", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Remove_By_Id_Employee()
        {
            var client = factory.CreateClient();
            var response = await client.DeleteAsync("/api/employee/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
    public class DepartmentsControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> factory;

        public DepartmentsControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task Get_All_Departments()
        {
            var client = factory.CreateClient();
            HttpResponseMessage response = await client.GetAsync("/api/department");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Get_By_Id_Department()
        {
            var client = factory.CreateClient();
            var response = await client.GetAsync("/api/department/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Post_New_Department()
        {
            Department newDepartment = new()
            {

                Name = "Test Department",
                CountryId = 1,
                CreatedAt = DateTime.UtcNow,
                IsDeleted = false,

            };

            var client = factory.CreateClient();
            var json = JsonSerializer.Serialize(newDepartment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("/api/department", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Put_New_Employee()
        {
            Employee putEmployee = new()
            {
                Id = 1,
                Name = $"Test User Update",
                CreatedAt = DateTime.UtcNow,
                DepartmentId = 1,
                IsDeleted = false
            };

            var client = factory.CreateClient();
            var json = JsonSerializer.Serialize(putEmployee);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PutAsync($"/api/employee/{putEmployee.Id}", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Remove_By_Id_Employee()
        {
            var client = factory.CreateClient();
            var response = await client.DeleteAsync("/api/employee/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
